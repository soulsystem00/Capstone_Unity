using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game_time : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject gm;
    public int time_m;
    public int time_s;
    public float time_score;
    //public int star;

    float deltaTime;
    void Start()
    {
        gm = GameObject.Find("GameManager");
        time_m = 0;
        time_s = 0;
        deltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime * 1;

        time_s = Convert.ToInt32(deltaTime);
        time_m = Convert.ToInt32(deltaTime / 60f);
        time_score  = gm.GetComponent<GameManager>().time_score_delay < time_s ? time_score + Time.deltaTime * 1 : 0;
        gm.GetComponent<GameManager>().time_score_s = Convert.ToInt32(time_score);
        gm.GetComponent<GameManager>().time_m = time_m;
        gm.GetComponent<GameManager>().time_total_s = time_s;

        //gm.GetComponent<GameManager>().star=star;
        //Debug.Log(time_m);
        //Debug.Log(time_score);
        //Debug.Log(time_s);
    }
}
