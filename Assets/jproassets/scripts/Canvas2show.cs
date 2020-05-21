using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas2show : MonoBehaviour {

    [SerializeField] private CanvasGroup cg;
    private int count;
    private bool isactive = false;
    private bool hyouji = true;
    private float speed = 0.000001f;
    private float show_time = 1.0f;
    private float time = 0;
    private bool sleep;
    // Update is called once per frame
    void Update()
    {
        count = Checkunityspawn.count;
        sleep = Checkunityspawn.issleep;
        if(!isactive && count == 3) { isactive = true;}
        if (count == 1 && isactive && hyouji)// && sleep)
        {
            time += Time.deltaTime;
            cg.alpha = 1;
            if (time > show_time) {
                hyouji = false;
            }
        }
        else
        {
            cg.alpha = 0;
            if (!hyouji && count == 3)
            {
                hyouji = true;
                time = 0.0f;
            }
        }
    }
}
