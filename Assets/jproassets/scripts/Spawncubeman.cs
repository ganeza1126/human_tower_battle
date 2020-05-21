using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawncubeman : MonoBehaviour {

    public GameObject cubeman;
    public Transform spawnpoint;

	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
	void Update () {
        if (Gotomain.counter== 1) {
            Spawn();
            Gotomain.counter = 0;
        }
	}
    void Spawn() {
        GameObject newcubeman =
            Instantiate(cubeman, spawnpoint.position, Quaternion.identity) as GameObject;
    }
}
