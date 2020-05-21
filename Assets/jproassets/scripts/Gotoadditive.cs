using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotoadditive : MonoBehaviour {

    public void Onclick()
    {
        SceneManager.LoadScene("additive", LoadSceneMode.Additive);
    }
}
