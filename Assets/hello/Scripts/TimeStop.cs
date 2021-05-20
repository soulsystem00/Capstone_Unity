using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private GameObject gm;
    void Start()
    {
        gm = GameObject.Find("GameManager");
    }
    public void stop()
    {
        Time.timeScale = 0f;
    }

    public void Countinue()
    {
        Time.timeScale = gm.GetComponent<GameManager>().Gm_speed;
    }

    public void Set_TimeScale_1f()
    {
        Time.timeScale = 1f;
    }
}
