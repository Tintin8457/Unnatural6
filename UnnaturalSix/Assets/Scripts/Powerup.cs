using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    NoteCatcher player2;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject nC = GameObject.FindGameObjectWithTag("Player");

        if (nC != null)
        {
            player2 = nC.GetComponent<NoteCatcher>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
