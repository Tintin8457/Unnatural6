using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGoal : MonoBehaviour
{
    [SerializeField]
    LevelHealth health;
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
            Destroy(collision.gameObject);
            print("u eeffed up");
            player.HurtPlayerColor();
            StartCoroutine(WaitToReset());
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //Destroy(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Note>().hold == true)
        {
            health.damage(-1 * Time.deltaTime);

            print("u eeffed up");
        }
    }
    IEnumerator WaitToReset()
    {
        yield return new WaitForSeconds(1.5f);
        player.ResetPlayerColor();
    }
}
