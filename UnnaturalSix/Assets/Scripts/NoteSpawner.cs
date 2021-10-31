using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    [SerializeField] Sequencer sequencer;
    [SerializeField] GameObject note;
    [SerializeField] GameObject longNote;
    [SerializeField] bool dualInput;
    GameObject _note;
    GameObject _longNote;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = this.GetComponent<Collider2D>();
        StartCoroutine(spawnTimer());


    }

    // Update is called once per frame
    void Update()
    {



        
    }

    IEnumerator spawnTimer()
    {

        yield return new WaitForSeconds(sequencer.getTimePerNote());
        if (sequencer.getNoteLength() > -1)
        {
            float noteLength = sequencer.getNoteLength();


            if (noteLength > 0.5)
            {
                _longNote = Instantiate(longNote, new Vector2(Random.Range(col.bounds.min.x, col.bounds.max.x), this.transform.position.y), this.transform.rotation);
                _longNote.GetComponent<Note>().dual = dualInput;
                _longNote.GetComponent<LineRenderer>().SetPosition(1, Vector3.up * noteLength);

            }
            else
            {
                _note = Instantiate(note, new Vector2((int)Random.Range(col.bounds.min.x, col.bounds.max.x), this.transform.position.y), this.transform.rotation);
                _note.GetComponent<Note>().dual = dualInput;
            }
        }

        if (sequencer.getTimePerNote() != -1)
        {
            StartCoroutine(spawnTimer());
        }
      
    }
}
