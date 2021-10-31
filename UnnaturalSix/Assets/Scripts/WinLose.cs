using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinLose : MonoBehaviour
{

    [SerializeField]
    LevelHealth health;
    [SerializeField]
    timerUI timer;

    [SerializeField]
    string win, lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health.getPlayerHealth() < 0)
        {
            //lose
            SceneManager.LoadScene(lose, LoadSceneMode.Single);
            health.resetBonusPoints();
        }
        if (timer.currentTime <= 0)
        {
            if (health.getPlayerHealth() > 50)
            {
                health.giveBonusPoints();
                SceneManager.LoadScene(win, LoadSceneMode.Single);

            }
            else
            {
                SceneManager.LoadScene(lose, LoadSceneMode.Single);
                health.resetBonusPoints();
            }
           
        }

    }
}
