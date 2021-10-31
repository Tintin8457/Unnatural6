using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnValidate()
    {
        bonusPoints = 0;
        setPoints();
    }
    private void OnEnable()
    {
        power = maxPower;
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
}
