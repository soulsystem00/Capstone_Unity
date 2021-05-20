using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Game_score : MonoBehaviour
{
    private GameObject gm;
    private GameObject star;
    public float maxscore;
    float u = 0;
    bool zero_ck = false;
    public TextMeshProUGUI Reward_Crystal;
    public TextMeshProUGUI Reward_Exp;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        star = GameObject.Find("Play_Clear");

        if (gm.GetComponent<GameManager>().time_score_s > 100) zero_ck = true;
        u = zero_ck == true ?  0 : (maxscore *((100f-(gm.GetComponent<GameManager>().time_score_s)) / 100f));

        gm.GetComponent<GameManager>().score=Convert.ToInt32(u);
        gm.GetComponent<GameManager>().cristal += Convert.ToInt32(u / 100f);
        gm.GetComponent<GameManager>().exp += Convert.ToInt32(u / 150f);
        int time_m = gm.GetComponent<GameManager>().time_m;

        Reward_Crystal.text = "+ " + Convert.ToInt32(u / 100f).ToString();
        Reward_Exp.text = "+ " + Convert.ToInt32(u / 150f).ToString();
        //별 갯수
        if(gm.GetComponent<GameManager>().selectStageNum != 19)
        {
            if (time_m == 0)
            {
                star.GetComponent<StageResult>().clearScore = 30;
                gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum - 1] = 3;
                if (gm.GetComponent<GameManager>().selectStageNum != 18 && gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] == -1)
                {
                    gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] = 0;
                }
            }
            else if (time_m == 1)
            {
                star.GetComponent<StageResult>().clearScore = 20;
                if (gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum - 1] < 2)
                {
                    gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum - 1] = 2;
                }
                if (gm.GetComponent<GameManager>().selectStageNum != 18 && gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] == -1)
                {
                    gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] = 0;
                }
            }
            else
            {
                star.GetComponent<StageResult>().clearScore = 10;
                if (gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum - 1] < 1)
                {
                    gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum - 1] = 1;
                }
                if (gm.GetComponent<GameManager>().selectStageNum != 18 && gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] == -1)
                {
                    gm.GetComponent<GameManager>().Stage_Info[gm.GetComponent<GameManager>().selectStageNum] = 0;
                }
            }
        }
        


    }

    // Update is called once per frame
    void Update()
    {
    }
}
