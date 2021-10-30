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

    public bool hold;
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
    private void OnValidate()
    {
        EdgeCollider2D edgeCol = this.GetComponent<EdgeCollider2D>();
        LineRenderer line = this.GetComponent<LineRenderer>();
        List<Vector2> vect2List= new List<Vector2>();
       
        if (line != null)
        {
            hold = true;
            for (int i = 0; i < line.positionCount; i++)
            {
                // print(new Vector2(line.GetPosition(i).x, line.GetPosition(i).y));
                vect2List.Add(new Vector2(line.GetPosition(i).x, line.GetPosition(i).y));
                // print(edgeCol.points[i]);
            }
            edgeCol.SetPoints(vect2List);

        }


    }
    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector2.down * speed * Time.deltaTime);

    }
}
