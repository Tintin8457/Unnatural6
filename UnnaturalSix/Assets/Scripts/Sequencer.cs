using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sequence", menuName = "Note Sequence", order = 1)]
public class Sequencer : ScriptableObject
{

    [SerializeField]
    List<float> timePerNote;
    [SerializeField]
    List<float> noteLength;
   
    private void OnEnable()
    {
       // index = 0;
    }


    private void OnDisable()
    {
        //index = 0;
    }

    public float getTimePerNote(int index)
    {
        
        if(index < timePerNote.Count)
        {
            return timePerNote[index];
        }
        return -1;
    }

    public void writeSequence(float time)
    {
        timePerNote.Add(time);
    }
    public void setNoteLength(float length)
    {
        noteLength.Add(length);
    }
    public float getNoteLength(int index)
    {
        if (index < noteLength.Count)
        {
            return noteLength[index];
        }
        return -1;
    }

}
