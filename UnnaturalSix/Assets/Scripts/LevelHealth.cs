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

    private void OnValidate()
    {
        setPoints();
    }
    private void OnEnable()
    {
        
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
        playerHealth += dam;
        enemyHealth -= dam;
    }
}
