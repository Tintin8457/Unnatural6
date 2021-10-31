using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Note : MonoBehaviour
{
    [SerializeField]
    bool randomizedKeys=false;
    [SerializeField]
    public string key;
    [SerializeField]
    float speed;
    TextMeshPro text;
    [SerializeField]
    string possibleKeys = "asdf";

    public bool dual=false;
    public int mouseKey;
    public bool hold;
    public bool played;
    
    // Start is called before the first frame update
    EdgeCollider2D edgeCol ;
    LineRenderer line;
    List<Vector2> vect2List;

    void Start()
    {
        edgeCol = this.GetComponent<EdgeCollider2D>();
        line = this.GetComponent<LineRenderer>();
        vect2List = new List<Vector2>();
        if (randomizedKeys)
        {
            char c = possibleKeys[Random.Range(0, possibleKeys.Length)];
            key = "" + c;
        }

        if (key == "a")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.57f,0.89f,0.42f);
            
        }
        else if (key == "s")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.89f, 0.42f, 0.78f);
        }
        else if (key == "d")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.42f, 0.76f, 0.89f);
        }
        else if (key == "f")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.886f, 0.89f, 0.42f);
        }


        float rng = Random.value;
        


        //if (rng >= 0.5)
        //{
        //    dual = true;
        //}else
        //{
        //    dual = false;
        //}
        if (dual)
        {
            mouseKey = Random.Range(0,2);
          
            if (mouseKey == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }


        text = this.transform.GetComponentInChildren<TextMeshPro>();
       
        text.text = key;
        if (line != null)
        {
            if (key == "a")
            {
                this.GetComponent<LineRenderer>().startColor = new Color(0.57f, 0.89f, 0.42f);
                this.GetComponent<LineRenderer>().endColor = new Color(0.57f, 0.89f, 0.42f);

            }
            else if (key == "s")
            {
                this.GetComponent<LineRenderer>().startColor = new Color(0.89f, 0.42f, 0.78f);
                this.GetComponent<LineRenderer>().endColor = new Color(0.89f, 0.42f, 0.78f);
            }
            else if (key == "d")
            {
                this.GetComponent<LineRenderer>().startColor = new Color(0.42f, 0.76f, 0.89f);
                this.GetComponent<LineRenderer>().endColor = new Color(0.42f, 0.76f, 0.89f);
            }
            else if (key == "f")
            {
                this.GetComponent<LineRenderer>().startColor = new Color(0.886f, 0.89f, 0.42f);
                this.GetComponent<LineRenderer>().endColor = new Color(0.886f, 0.89f, 0.42f);
            }

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
    private void OnValidate()
    {
     
       
       


    }
    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector2.down * speed * Time.deltaTime);

    }
}
