using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomain : MonoBehaviour {

    public void Onclick() {
        Gotomain.counter++;
        SceneManager.UnloadSceneAsync("additive");
    }
}
