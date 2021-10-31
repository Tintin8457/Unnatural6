using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDelay : MonoBehaviour
{
    [SerializeField]
    float delay=10;

    AudioSource[] audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponents<AudioSource>();
        for(int i = 0; i < audio.Length; i++)
        {
            audio[i].PlayDelayed(delay);
        }
      

       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].pitch = Time.timeScale;
        }
       
    }
}
