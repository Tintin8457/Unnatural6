using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLevelHealth : MonoBehaviour
{
    [SerializeField]
    LevelHealth helth;
    // Start is called before the first frame update
    void Start()
    {
        helth.resetBonusPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
