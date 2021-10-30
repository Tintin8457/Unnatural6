using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCatcher : MonoBehaviour
{


    [SerializeField] float maxBound;
    float minBound;
    [SerializeField] float paddleSpeed=1;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

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
            Destroy(collision.gameObject);
        }
       
      
    }



}


