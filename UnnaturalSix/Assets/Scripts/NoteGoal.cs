using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class NoteGoal : MonoBehaviour
{
    [SerializeField]
    LevelHealth health;

    //public TextMeshProUGUI keyFeedbackText;
    [SerializeField]
    NoteCatcher player;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Note>().hold == false)
        {
            health.damage(-1);
            player.HurtPlayerColor();
            StartCoroutine("WaitToReset");
            Destroy(collision.gameObject);
            print("u eeffed up");
        }
    }

    IEnumerator WaitToReset()
    {
        yield return new WaitForSeconds(1.5f);
        player.ResetPlayerColor();
    }
}
