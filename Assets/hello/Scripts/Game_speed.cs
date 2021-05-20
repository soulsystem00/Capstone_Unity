using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_speed : MonoBehaviour
{
    public List<GameSpeedOnOff> onoffBtnList = new List<GameSpeedOnOff>();

    public void BtnInit()
    {
        int tmp = GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed;
        for (int i = 0; i < 3; i++)
        {
            //Debug.Log(tmp == i + 1);
            if (tmp == i + 1)
            {
                onoffBtnList[i].BtnReset_Enable();
                //Debug.Log("1");
            }
            else
            {
                onoffBtnList[i].BtnReset();
                //Debug.Log("2");
            }
        }
    }

    public void BtnReset()
    {
        foreach (var item in onoffBtnList)
        {
            item.BtnReset();
        }
    }
}
