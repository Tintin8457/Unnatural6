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
    ParticleSystem particle;
    [SerializeField]
    SpriteRenderer playerColor;

    bool holding=false;

    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        Cursor.visible = false;
        //maxBound = this.transform.parent.GetComponent<Collider2D>().bounds.size.x;
        minBound = -maxBound;
        cam = Camera.main;

        playerColor = this.GetComponent<SpriteRenderer>();
    }


  
    // Update is called once per frame
    void Update()
    {


       float pos = Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x,minBound,maxBound) ;
        if (holding == false)
        {
            this.transform.position = new Vector2(pos, this.transform.position.y);
        }

        //Gizmos.DrawLine(this.transform.parent)

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("hit somthang");

        if (collision.GetComponent<Note>().dual)
        {
            if (Input.GetKey(collision.GetComponent<Note>().key)&&Input.GetMouseButton(collision.GetComponent<Note>().mouseKey))
            {
                hit(collision);


            }
            else if (Input.anyKey && !Input.GetMouseButton(collision.GetComponent<Note>().mouseKey)&&!Input.GetKey(KeyCode.Space))
            {
                miss(collision);

            }
            
        }
        else
        {
            if (Input.GetKey(collision.GetComponent<Note>().key))
            {

                hit(collision);

            }
            else if (Input.anyKey && !Input.GetKey(KeyCode.Space))
            {
                miss(collision);
            }
            
        }

        
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        holding = false;
    }

    void hit(Collider2D collider)
    {
        print("hitting it");
        RewardPlayerColor();
        if (collider.GetComponent<Note>().hold == false)
        {
            health.damage(1);
            Destroy(collider.gameObject);
            particle.Play();   
        }
        else
        {
            holding = true;
            collider.GetComponent<Note>().played = true;
            this.transform.position = new Vector2(collider.transform.position.x, this.transform.position.y);
            health.damage(1 * Time.deltaTime);
            particle.Play();
        }


    }


    void miss(Collider2D collider)
    {
        print("wong key");
        HurtPlayerColor();
        if (collider.GetComponent<Note>().hold == false)
        {
            health.damage(-4);

            Destroy(collider.gameObject);
        }
        else
        {
            health.damage(-4 * Time.deltaTime);
        }
    }

    public void ResetPlayerColor()
    {
       // keyFeedbackText.text = "";
        playerColor.color = new Color(1f, 1f, 1f, 1f);
    }

    public void RewardPlayerColor()
    {
       // keyFeedbackText.text = "Key has been hit!";
        playerColor.color = new Color(0.02277458f, 1f, 0f, 1f);
    }

    public void HurtPlayerColor()
    {
        //keyFeedbackText.text = "You missed the key!";
        playerColor.color = new Color(1f, 0f, 0f, 1f);
    }


}


