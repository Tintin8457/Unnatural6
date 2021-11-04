using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AccuracyText : MonoBehaviour
{
    TextMeshProUGUI text;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            text.text = " ";
        }
    }

    public void Text(string _text)
    {
        text.text = _text;
        Timer = 2;
    } 

}
