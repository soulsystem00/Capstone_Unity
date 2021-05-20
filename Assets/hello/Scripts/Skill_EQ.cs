using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_EQ : MonoBehaviour
{
    //public Text acc;
    public TextMeshProUGUI acc;
    Transform camera;
    public bool mover;

    public float loLim = 0.005f;
    public float hiLim = 0.1f;
    public int steps = 0;
    bool stateH = false;

    public float fHigh = 10.0f;
    public float curAcc = 0f;
    public float fLow = 0.1f;
    float avgAcc = 0f;

    public int wait_time = 30;
    private int old_steps;
    private int counter = 30;

    int index = 0;
    Vector3[] varr = { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 1, 0), new Vector3(0, 0, 0) };

    float tmp_time;
    private void OnEnable()
    {
        Time.timeScale = 1f;
        tmp_time = GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed;
        //Time.timeScale = 0.3f;
        steps = 0;
        //stateH = false;
        //avgAcc = 0f;
        curAcc = 0f;
        acc = gameObject.FindChild("Steps", true).GetComponent<TextMeshProUGUI>();
        acc.text = steps.ToString();
        avgAcc = Input.acceleration.magnitude;
        old_steps = steps;
        Debug.Log("Awake");
        Debug.Log("avrAcc : " + avgAcc);
        Debug.Log("old_steps : " + old_steps);
        Invoke("disableThis", 3f);
        InvokeRepeating("CameraMove", 0f, 0.1f);
        index = 0;
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    void CameraMove()
    {
        if (index < 5)
        {
            camera.position += varr[index] * 0.3f;
            index++;
        }
        else
        {
            CancelInvoke("CameraMove");
        }

    }
    private void Awake()
    {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //var hello = Input.
    }

    // Update is called once per frame
    void Update()
    {
        
        if(counter > 0)
        {
            counter--;
            return;
        }
        counter = wait_time;
        if (steps != old_steps)
            mover = true;
        else
            mover = false;

        old_steps = steps;
    }
    private void FixedUpdate()
    {
        curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
        avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
        //Debug.Log("FixedUpdate");
        //Debug.Log("curAcc : " + curAcc);
        //Debug.Log("avrAcc : " + avgAcc);

        float delta = curAcc - avgAcc;
        //Debug.Log("delta : " + delta);
        if (!stateH)
        {
            if(delta > hiLim)
            {
                stateH = true;
                steps++;
                acc.text = steps.ToString();
                //Debug.Log(steps);
            }
        }
        else
        {
            if(delta < loLim)
            {
                stateH = false;
            }
        }
    }

    private void OnDisable()
    {
        Time.timeScale = tmp_time;
        GameObject point2 = GameObject.Find("point2");
        for(int i =0;i < point2.transform.childCount; i++)
        {
            point2.transform.GetChild(i).GetComponent<UnitMove>().setHealth(steps * 10);
            //Debug.Log(point2.transform.GetChild(i).name +  " " + point2.transform.GetChild(i).GetComponent<UnitMove>().Health.ToString());
        }
    }

    void disableThis()
    {
        Debug.Log("SKill Disabled");
        gameObject.SetActive(false);
        GameObject.Find("Btn_earthqueke").SetActive(false);
        //Time.timeScale = 1f;
    }
}
