using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointBar : MonoBehaviour
{
    [SerializeField]
    Image bar1, bar2;
    [SerializeField]
    LevelHealth points;
    // Start is called before the first frame update
    void Start()
    {
        bar1 = this.transform.GetChild(0).GetComponent<Image>();
        bar2 = this.transform.GetChild(1).GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        bar1.fillAmount = points.getEnemyHealth()/100;
        bar2.fillAmount = points.getPlayerHealth()/100;



    }
}
