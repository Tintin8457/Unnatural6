using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDelay : MonoBehaviour
{
    [SerializeField]
    float delay=10;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        audio.PlayDelayed(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
