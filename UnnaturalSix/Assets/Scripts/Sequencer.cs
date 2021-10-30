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
    int index;
    private void OnEnable()
    {
        index = 0;
    }


    private void OnDisable()
    {
        index = 0;
    }

    public float getTimePerNote()
    {
        index++;
        return timePerNote[index-1];
    }

    public void writeSequence(float time)
    {
        timePerNote.Add(time);
    }
    public void setNoteLength(float length)
    {
        noteLength.Add(length);
    }
    public float getNoteLength()
    {
        return noteLength[index - 1];
    }

}
