using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteCatcher : MonoBehaviour
{
    [SerializeField] float maxBound;
    float minBound;
    [SerializeField] float paddleSpeed=1;
    Camera cam;
    [SerializeField]
    LevelHealth health;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI keyFeedbackText;

    public SpriteRenderer playerColor;

    public AudioSource music;
    public AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health.getPlayerHealth().ToString();
        keyFeedbackText.text = "";
        music.clip = musicClip;
        music.Play();

        Cursor.visible = false;
        //maxBound = this.transform.parent.GetComponent<Collider2D>().bounds.size.x;
        minBound = -maxBound;
        cam = Camera.main;
    }


  
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health.getPlayerHealth().ToString();

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
            health.damage(1*Time.deltaTime);
            RewardPlayerColor();

            if (collision.GetComponent<Note>().hold == false)
            {
                Destroy(collision.gameObject);
            }
        }

        else
        {
            print("wong key");
            health.damage(-1 * Time.deltaTime);
            HurtPlayerColor();

            if (collision.GetComponent<Note>().hold == false)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void ResetPlayerColor()
    {
        keyFeedbackText.text = "";
        playerColor.color = new Color(1f, 1f, 1f, 1f);
    }

    public void RewardPlayerColor()
    {
        keyFeedbackText.text = "Key has been hit!";
        playerColor.color = new Color(0.02277458f, 1f, 0f, 1f);
    }

    public void HurtPlayerColor()
    {
        keyFeedbackText.text = "You missed the key!";
        playerColor.color = new Color(1f, 0f, 0f, 1f);
    }
}


