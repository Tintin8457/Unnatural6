using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene( levelName);
    }

    public void quit()
    {
        Application.Quit();
    }
}
