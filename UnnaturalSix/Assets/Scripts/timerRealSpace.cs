using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timerRealSpace : timerUI
{


    // public float currentTime;

    [SerializeField]
    TextMeshPro textReal;


    // Start is called before the first frame update
    void Start()
    {
        textReal = this.GetComponent<TextMeshPro>();
        maxTime = FindObjectOfType<AudioSource>().clip.length+5f;
        currentTime = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
       // text.text = currentTime.ToString();
        string minutes =Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        textReal.text = minutes + ":" + seconds;

    }
}
