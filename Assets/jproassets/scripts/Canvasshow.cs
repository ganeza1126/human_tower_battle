using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasshow : MonoBehaviour {

    [SerializeField] private CanvasGroup cg;
    private int count;
    // Update is called once per frame
    void Update()
    {
        count = Checkunityspawn.count;
        if (count == 1)
        {
            cg.alpha = 1;
        }
        else { cg.alpha = 0; }
    }
}
