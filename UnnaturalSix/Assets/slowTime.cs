using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowTime : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    float slowSpeed;

    [SerializeField]
    LevelHealth health;

    [SerializeField]
    float powerUsage=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = slowSpeed;
            health.usePower(powerUsage * Time.deltaTime);

        }else 
        {
            Time.timeScale = 1;
            health.usePower(-powerUsage * Time.deltaTime);
            
        }


    }
}
