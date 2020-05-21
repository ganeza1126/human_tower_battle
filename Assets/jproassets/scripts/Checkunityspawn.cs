using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkunityspawn : MonoBehaviour {
    [SerializeField] private GameObject mainman;
    private float speed = 5.0f;
    private float hight;
    private GameObject newcubeman;
    private int playernumber;//koreha start scene kara tottekuru yatu
    Vector3 spawnpoint;
    private float theta = Mathf.PI*3/2;
    private float phi = 0.0f;//0~pi
    private float psi = 0.0f;
    private int radius = 10;
    private float omega = 3.0f;
    Vector3 look_at;
    Vector3 look_up;

    //public variable
    public static int count = 0;//used at Cameracubeman
    public static bool issleep = true;//used at Solvemaxhight
    public static int sup = 0; //used at solvemaxhight
    public static int playercounter = 1;//used at player displayer

    //count == 0,3 -> 0(main), count == 1,2 -> 1(other)
    /*
    camera: main overlook other
        count 0 -> watch model falling (main):donothing
        count 1 -> choise pose (other & main)
        count 2 -> spawn model (main)
        count 3 -> choise fall spot (main & overlook)
        count 4 -> add gravity (main) & if(issleep){go to count0}
    */

    private void Awake()
    {
        hight = Solvemaxhight.hight + 4.0f;
        Vector3 spawnpoint = new Vector3(0f, hight, 0f);
        playernumber = 2;
        count = 0;
        issleep = true;
        sup = 0;
        playercounter = 1;

        look_at = new Vector3(radius * Mathf.Cos(theta), 0, radius * Mathf.Sin(theta));
    }
    public void Onclick() {
        if (count != 0 || issleep)//count==0 notoki hannnousinaiyouni
        {
            count++;
            Spawn();
        }
    }

    void Spawn()
    {
        if (count == 2)
        {
            issleep = false;
            sup = 0;
            hight = Solvemaxhight.hight + 4.0f;
            spawnpoint = new Vector3(0f, hight, 0f);
            newcubeman = Instantiate(mainman, spawnpoint, Quaternion.Euler(0, 180, 0)) as GameObject;
            count++;
        }else if(count == 4){
            newcubeman.GetComponent<Rigidbody>().useGravity = true;
            count = 0;
        }

    }
    void Update()
    {
        Debug.Log("counter is : " + count);
        hight = Solvemaxhight.hight + 4.0f;
        spawnpoint.y = hight;
        if (count == 3 && Input.GetKey(KeyCode.LeftShift))//cameramainmove de mukouka gamenngaugokunowo mukouka
        {
            float rl = Input.GetAxisRaw("Horizontal");
            float ud = Input.GetAxisRaw("Vertical");
            spawnpoint += new Vector3(rl * speed * Time.fixedDeltaTime, 0, ud * speed * Time.fixedDeltaTime);
            newcubeman.transform.position = spawnpoint;
        }
        if (count == 3 && Input.GetKey(KeyCode.Tab))//cameramainmove de mukouka gamenngaugokunowo mukouka
        {
            float rlrot = Input.GetAxisRaw("Horizontal");
            float udrot = Input.GetAxisRaw("Vertical");
            theta += omega * Time.fixedDeltaTime * -rlrot;
            phi += omega * Time.fixedDeltaTime * udrot;
            if (phi < -Mathf.PI / 2 + 0.05f) { phi = -Mathf.PI / 2 + 0.05f; }
            if (phi >  Mathf.PI / 2 - 0.05f) { phi =  Mathf.PI / 2 - 0.05f; }
            look_at = new Vector3(radius * Mathf.Cos(theta) * Mathf.Cos(phi),
                radius * Mathf.Sin(phi), radius * Mathf.Sin(theta) * Mathf.Cos(phi));
            newcubeman.transform.LookAt(look_at + spawnpoint);
        }
        if (count == 3 && Input.GetKey(KeyCode.LeftControl))// && theta ==Mathf.PI*3/2)
        {
            float rlrot = Input.GetAxisRaw("Horizontal");
            psi = 50.0f *omega * Time.fixedDeltaTime * -rlrot;
            newcubeman.transform.Rotate(new Vector3(0,1,0), psi);
            look_up = new Vector3(Mathf.Cos(theta) * Mathf.Cos(phi+Mathf.PI/2.0f),
                 Mathf.Sin(phi+Mathf.PI/2.0f), Mathf.Sin(theta) * Mathf.Cos(phi+Mathf.PI/2.0f));
            newcubeman.transform.RotateAround(spawnpoint,look_up, psi);
        }
        if (count == 0 && newcubeman != null) {
            if (newcubeman.GetComponent<Rigidbody>().IsSleeping()) {
                issleep = true;
                if(sup == 0) { sup++; }
                count++;//if issleep go to nextscene
                if (playernumber == playercounter) {playercounter = 0; }
                playercounter++;
            }
        }
    }
}
