using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solvemaxhight : MonoBehaviour {
    //public variable
    public static float hight = 0.5f;//used at checkunityspawn, cameramainmove

    Vector3 sup = new Vector3(0, hight, 0);

    void Awake()
    {
        transform.position = sup;
    }

    void OnTriggerStay(Collider other)
    {
        if (Checkunityspawn.issleep)
        {
            Checkunityspawn.sup = 2;
            hight += 0.1f * Time.fixedDeltaTime;
            sup = new Vector3(0, hight, 0);
            transform.position = sup;
        }
    }

    private void Update()
    {
        if (Checkunityspawn.sup == 1 && Checkunityspawn.issleep)
        {
            hight -=  Time.fixedDeltaTime;
            sup.y = hight;
            transform.position = sup;
        }
//        if (hight < 0.5f) {
//            hight = 0.5f;
//            sup.y = hight;
//            transform.position = sup;
//        }
    }
}
