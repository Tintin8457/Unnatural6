using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceWriter : MonoBehaviour
{

    [SerializeField]
    Sequencer sequence;

    float time;
    float length;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            setTime();
            length = 0;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            length += Time.deltaTime;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            setLength();
        }
    }


    void setTime()
    {

        sequence.writeSequence(time);
        time = 0;

    }
    void setLength()
    {
        sequence.setNoteLength(length);
    }

}
