using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro text;
    Transform side, bottom;

    [SerializeField]
    NoteSpawner spawner;

    void Start()
    {
        text = this.transform.GetChild(0).GetComponent<TextMeshPro>();
        StartCoroutine(dialog());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator dialog()
    {

        text.text = "hi Del Vi, i'm impicorn, i'm going to teach ya how to use music to convert the humies";

        yield return new WaitForSeconds(5);


        text.text = "The bar on the right is your conversion bar, try to keep it above the yellow line to win, and if you want to go above and beyond. you shall get more of their loyalty";
        //this.transform.position=side.position;



        yield return new WaitForSeconds(5);
        this.transform.position = new Vector2(0, 2);
        text.text = "here in the middle notes will fall down and you will need to use the paddel with your mouse and the right key combination to play it right. if you fail. you don't want to know what happens if that happens too much.";


        yield return new WaitForSeconds(5);
        this.transform.position = new Vector2(3, 2);
        spawner.gameObject.SetActive(true);
        text.text = "oh here comes ones now";
        yield return new WaitForSeconds(5);
        text.text = "and if you see on with a tail, you need to hold the key down.";
        yield return new WaitForSeconds(5);
        text.text = "perfect lets get onto your first vict... i mean soon to be follower";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("LevelOne");


    }





}
