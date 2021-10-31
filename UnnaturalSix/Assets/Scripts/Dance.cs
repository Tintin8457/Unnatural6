using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    Camera cam;
    bool rotate=false;
    float rot;
    [SerializeField]
    int numOfKeysForDnace=5;
    int currentKeys=0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
        
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x, -5, 5));

       //flip();

    }

    void flip()
    {
        if (Input.anyKeyDown)
        {

            if (currentKeys == numOfKeysForDnace)
            {
                rotate = true;
                currentKeys = 0;
            }
            else
            {
                rotate = false;
            }
            

          
            if (rot == 0)
            {
                rot += 180;
            }
            else
            {
                rot -= 180;
            }

            currentKeys += 1;
        }

        if (rotate)
        {
            this.transform.eulerAngles = Vector3.up * Mathf.Lerp(this.transform.eulerAngles.y, rot, 0.005f);
           // 
        }
       
    }

}
