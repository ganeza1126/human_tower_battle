using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerdisplayer : MonoBehaviour {

    private void Update()
    {
        GetComponent<Text>().text = "プレイヤー " + Checkunityspawn.playercounter;
        if (Checkunityspawn.playercounter == 1) {
            GetComponent<Text>().color = new Color(1, 1, 0, 0.8f);
        }
        if (Checkunityspawn.playercounter == 2) {
            GetComponent<Text>().color = new Color(1, 0, 1, 0.8f);
        }
    }
}
