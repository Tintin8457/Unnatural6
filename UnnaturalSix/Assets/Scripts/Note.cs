using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Note : MonoBehaviour
{
    [SerializeField]
    bool randomizedKeys=false;
    [SerializeField]
    public string key;
    [SerializeField]
    float speed;
    TextMeshPro text;
    string possibleKeys = "abcdefghijklmnopqrstuvwxyz";
    // Start is called before the first frame update
    void Start()
    {
        if (randomizedKeys)
        {
            char c = possibleKeys[Random.Range(0, possibleKeys.Length)];
            key = "" + c;
        }
        text = this.transform.GetComponentInChildren<TextMeshPro>();
       
        text.text = key;
       
       


    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector2.down * speed * Time.deltaTime);

    }
}
