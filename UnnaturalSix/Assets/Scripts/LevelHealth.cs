using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[CreateAssetMenu(fileName = "level Health", menuName = "Level Health", order = 1)]
public class LevelHealth : ScriptableObject
{
    [SerializeField]
    float maxPoints;
    [SerializeField]
    float playerHealth, enemyHealth;
    [SerializeField]
    float maxPower=100;
    [SerializeField]
    float power;
    [SerializeField]
    float damageMod=4;

    [SerializeField]
    float bonusPoints=0;
    string saveFile = "/highscore.json";
    [SerializeField]
    public Highscore score;
    private void OnValidate()
    {
        //bonusPoints = 0;
        setPoints();
    }
    private void OnEnable()
    {
        power = maxPower;  
    }
    private void Awake()
    {
        if (score == null)
        {
            score = new Highscore();
        }


    }
    void setPoints()
    {
        playerHealth = maxPoints / 2;
        enemyHealth = maxPoints / 2;
    }

 
    public float getPlayerHealth()
    {
        return playerHealth;
    }
    public float getEnemyHealth()
    {
        return enemyHealth;
    }
    public float getMaxPoints()
    {
        return playerHealth;
    }
    public void damage(float dam)
    {
        playerHealth += dam*damageMod;
        enemyHealth -= dam * damageMod;
        if (playerHealth > maxPoints)
        {
            bonusPoints += dam;
            playerHealth = maxPoints;
            enemyHealth = 0;
        }else
        if (enemyHealth > maxPoints)
        {
            enemyHealth = maxPoints;
           // playerHealth = 0;
        }

    }

    public void usePower(float amount)
    {
        power -= amount;

        if (power > maxPower)
        {
            power = maxPower;
        }
        else if(power < 0)
        {
            power = 0;
        }
    }
    public float getPower()
    {
        return power;
    }

    public void giveBonusPoints()
    {
        bonusPoints += (playerHealth - 50);
    }
    void resetBonusPoints()
    {
        bonusPoints = 0;
    }


    public void saveHighscore()
    {
        score.addNewScore(bonusPoints);
        score.reorderList();
    }


    public void Save()
    {
        Debug.Log("saving data");

        string saveData = JsonUtility.ToJson(score, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, saveFile));
        bf.Serialize(file, saveData);
        Debug.Log(saveData);

        file.Close();
    }
    public void load()
    {

        if (File.Exists(string.Concat(Application.persistentDataPath, saveFile)))
        {
            Debug.Log("loading data");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, saveFile), FileMode.Open);

            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), score);


            file.Close();
        }


    }





}
[System.Serializable]
public class Highscore
{
   [SerializeField]
   public List<float> highscores;

    public void addNewScore(float _score)
    {
        highscores.Add(_score);
    }
    public void reorderList()
    {
        highscores.Sort();

    }


}

