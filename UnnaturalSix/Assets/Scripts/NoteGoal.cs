using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class NoteGoal : MonoBehaviour
{
    [SerializeField]
    LevelHealth health;

    //public TextMeshProUGUI keyFeedbackText;

    // Start is called before the first frame update
    void Start()
    {
        //keyFeedbackText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Note>().hold == false)
        {
            //keyFeedbackText.text = "You missed the key!";
            health.damage(-1);
            Destroy(collision.gameObject);
            print("u eeffed up");
        }
     
    }
}
