using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramainmove : MonoBehaviour {

    private float radius = 16.0f;
    public float radiusg = 5.0f;
    public float speed = 3.0f;
    private float hight;
    private float ddo = Mathf.PI;
    private float ddog = Mathf.PI;
    Vector3 velocity;
    Vector3 selectg;
    Vector3 overlook;
    [SerializeField] private GameObject maincamera;
    [SerializeField] private GameObject overlookcamera;
    [SerializeField] private GameObject othercamera;
    private Camera mainc;
    private Camera overlookc;
    private Camera otherc;
    private Rect right = new Rect(0.65f, 0, 1, 1);
    private Rect left  = new Rect(0, 0, 0.65f, 1);
    private Rect full  = new Rect(0, 0, 1, 1);
    private bool camerais1 = true;

    [SerializeField] private GameObject background;
    private float size = 8.6f;

    //public variable

    // Use this for initialization
    //	void Start () {
    private void Awake()
    {
        hight = Solvemaxhight.hight + 4.0f;
        velocity = new Vector3(radius * Mathf.Sin(ddo), hight, radius * Mathf.Cos(ddo));
        selectg = new Vector3(radiusg * Mathf.Sin(ddog), -50f, radiusg * Mathf.Cos(ddog));
        overlook = new Vector3(0, hight+ 4.0f, 0);
        maincamera.transform.position = velocity;
        maincamera.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
        othercamera.transform.position = selectg;
        overlookcamera.transform.position = overlook;
        maincamera.SetActive(true);
        overlookcamera.SetActive(true);
        othercamera.SetActive(false);
        overlookc = overlookcamera.GetComponent<Camera>();
        mainc = maincamera.GetComponent<Camera>();
        otherc = othercamera.GetComponent<Camera>();
        mainc.rect = full;

        background.transform.position = new Vector3(radius * Mathf.Sin(ddo+Mathf.PI), hight-6.0f, radius * Mathf.Cos(ddo+Mathf.PI));
        background.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
    }

    // Update is called once per frame
    void Update () {
        size = Mathf.Sqrt(radius * radius + 9.0f) * 8.6f / Mathf.Sqrt(34.0f)/2.7f;
        background.transform.localScale = new Vector2(size, size);

        float rl = Input.GetAxisRaw("Horizontal");
        float ud = Input.GetAxisRaw("Vertical");
        int phase = Checkunityspawn.count;
        if (hight - Solvemaxhight.hight != 4.0f)
        {
            hight = Solvemaxhight.hight + 4.0f;
            velocity = new Vector3(radius * Mathf.Sin(ddo), hight, radius * Mathf.Cos(ddo));
            maincamera.transform.position = velocity;
            maincamera.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
            overlook.y = hight + 8.0f;
            overlookcamera.transform.position = overlook;


            background.transform.position = new Vector3(radius * Mathf.Sin(ddo+Mathf.PI), hight-6.0f, radius * Mathf.Cos(ddo+Mathf.PI));
            background.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
        }
        if (phase != 1)
        {//use maincamera(onoff = 0)
            Changecamera(0);
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftControl))
            {
                if (rl != 0)
                {
                    ddo += speed * Time.fixedDeltaTime * -rl;
                    velocity = new Vector3(radius * Mathf.Sin(ddo), hight, radius * Mathf.Cos(ddo));
                    maincamera.transform.position = velocity;
                    maincamera.transform.LookAt(new Vector3(0, hight-3.0f, 0));

                    background.transform.position = new Vector3(radius * Mathf.Sin(ddo+Mathf.PI), hight-6.0f, radius * Mathf.Cos(ddo+Mathf.PI));
                    background.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
                }
                else if (ud != 0)
                {
                    radius += speed* 4 * ud * Time.fixedDeltaTime;
                    velocity = new Vector3(radius * Mathf.Sin(ddo), hight, radius * Mathf.Cos(ddo));
                    maincamera.transform.position = velocity;
                    maincamera.transform.LookAt(new Vector3(0, hight-3.0f, 0));

                    background.transform.position = new Vector3(radius * Mathf.Sin(ddo+Mathf.PI), hight-6.0f, radius * Mathf.Cos(ddo+Mathf.PI));
                    background.transform.LookAt(new Vector3(0, hight - 3.0f, 0));
                }
            }
            if (phase == 3)
            {//right, left kirikae
                if (camerais1)
                {
                    Changecamera(2); camerais1 = false;
                }
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    Changecamera(2);
                }
            }
            else
            {//main ni modosu
                Changecamera(3);
            }
        }
        else if (phase == 1)
        {//use othercamera (onoff = 1)
            Changecamera(1);
            if (rl != 0)
            {
                ddog += speed * Time.fixedDeltaTime * -rl;
                selectg = new Vector3(radiusg * Mathf.Sin(ddog), -50.0f, radiusg * Mathf.Cos(ddog));
                othercamera.transform.position = selectg;
                othercamera.transform.LookAt(new Vector3(0f, -50f, 0f));
            }
        }
        }

    void Changecamera(int onoff) {
        if (onoff == 0 && !maincamera.activeSelf)
        {//use maincamera
            maincamera.SetActive(true);//!maincamera.activeSelf);
            othercamera.SetActive(false);//!othercamera.activeSelf);
        }
        else if (onoff == 1)// && !othercamera.activeSelf)
        {//use othercamera
         //            maincamera.SetActive(ncamera.activeSelf);
         //            othercamera.SetActive(!othercamera.activeSelf);
            othercamera.SetActive(true);
            mainc.rect = right;
            otherc.rect = left;
        }
        if (onoff == 2)
        {//change view point
            if (mainc.rect == right || mainc.rect == full)
            {
                mainc.rect = left;
                overlookc.rect = right;
            }
            else
            {
                mainc.rect = right;
                overlookc.rect = left;
            }
        }
        if(onoff == 3 && !camerais1)
        {
            mainc.rect = full;
            camerais1 = true;
        }
    }

}

