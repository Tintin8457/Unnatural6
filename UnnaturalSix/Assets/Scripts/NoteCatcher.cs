using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCatcher : MonoBehaviour
{


    [SerializeField] float maxBound;
    float minBound;
    [SerializeField] float paddleSpeed=1;
    Camera cam;
    [SerializeField]
    LevelHealth health;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        //maxBound = this.transform.parent.GetComponent<Collider2D>().bounds.size.x;
        minBound = -maxBound;
        cam = Camera.main;
    }


  
    // Update is called once per frame
    void Update()
    {


       float pos = Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x,minBound,maxBound)   ;
      
        this.transform.position = new Vector2(pos, this.transform.position.y);

       //Gizmos.DrawLine(this.transform.parent)

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("hit somthang");
        if (Input.GetKey(collision.GetComponent<Note>().key))
        {
            print("hitting it");
            
            if (collision.GetComponent<Note>().hold == false)
            {
                health.damage(1);
                Destroy(collision.gameObject);
            }
            else
            {
              
                health.damage(1 * Time.deltaTime);
            }
           

        }
        else if(Input.anyKey)
        {
            print("wong key");
           
            if (collision.GetComponent<Note>().hold == false)
            {
                health.damage(-1);
              
                Destroy(collision.gameObject);
            }
            else
            {
                health.damage(-1 * Time.deltaTime);
            }
          
        }
        
    }

       



}


