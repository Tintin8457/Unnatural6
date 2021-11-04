using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour
{

    [SerializeField]
    Sprite changeTo;

    float speed=1;
    bool slowdown = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 10000&& slowdown==false)
        {
            speed = Mathf.MoveTowards(speed, 10000, 5000 * Time.deltaTime);
          
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = changeTo;
            slowdown = true;
            speed = Mathf.MoveTowards(speed, 0, 5000 * Time.deltaTime);
           
        }
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
       if(speed==0 && slowdown == true)
        {
            this.transform.eulerAngles=Vector3.zero;
        }
        

    }




}
