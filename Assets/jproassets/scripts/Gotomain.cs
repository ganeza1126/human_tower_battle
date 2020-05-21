using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotomain : MonoBehaviour {

    public static int counter = 0;

    //public GameObject player;
    public void onclick() {
        //DontDestroyOnLoad(player);
//counter wo 1 nisinaito unitychan ga detekonai
//        counter++;
        SceneManager.LoadScene("main");
    }
}
