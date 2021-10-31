using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class highscoreUI : MonoBehaviour
{
    [SerializeField]
    LevelHealth health;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        health.load();
        health.saveHighscore();
        health.Save();
        text = this.GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < health.score.highscores.Count; i++)
        {
            text.text += "\n " + health.score.highscores[health.score.highscores.Count-i-1];


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
