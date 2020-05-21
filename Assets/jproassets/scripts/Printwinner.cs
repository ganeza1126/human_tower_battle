using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Printwinner : MonoBehaviour {

    private int t;
    private void Awake()
    {
        for (int i = 1; i < 2 + 1; i++)
        {
            if (Checkunityspawn.playercounter != i) { t = i; break; }
        }
        GetComponent<Text>().text = "Winner is Player " + t;
    }
}
