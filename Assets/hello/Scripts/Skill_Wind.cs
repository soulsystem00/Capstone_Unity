using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Wind : MonoBehaviour
{
    int touchCount;
    public TextMeshProUGUI acc;

    bool checker;
    float tmp_time;
    private void OnEnable()
    {
        checker = true;
        Time.timeScale = 1f;
        tmp_time = GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed;
        Debug.Log("Wind Enable");
        touchCount = 0;
        Invoke("DisableThis", 3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        acc.text = touchCount.ToString();
        if(Input.touchCount == 1 && checker)
        {
            touchCount += 1;
            checker = false;
        }
        if(Input.touchCount == 0)
        {
            checker = true;
        }
        //Debug.Log(Input.touchCount);
    }

    private void OnDisable()
    {
        int touchcount_2 = touchCount;
        if(touchcount_2 > 30)
        {
            touchcount_2 = 30;
        }
        GameObject point2 = GameObject.Find("point2");
        for(int i =0;i<point2.transform.childCount;i++)
        {
            point2.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(new Vector2(touchcount_2, 0), ForceMode2D.Impulse);
        }
        //for (int i = 0; i < point2.transform.childCount; i++)
        //{
        //    Vector3 reach_point = new Vector3(point2.transform.GetChild(i).GetComponent<Transform>().position.x + touchCount, point2.transform.GetChild(i).GetComponent<Transform>().position.y, point2.transform.GetChild(i).GetComponent<Transform>().position.z);
        //    if (reach_point.x > 0)
        //        reach_point.x = 0;
        //    point2.transform.GetChild(i).GetComponent<Transform>().position = reach_point;
        //    Debug.Log(point2.transform.GetChild(i).name + " " + point2.transform.GetChild(i).GetComponent<UnitMove>().Health.ToString());
        //}
    }

    void DisableThis()
    {
        Time.timeScale = tmp_time;
        Debug.Log("SKill Disabled");
        gameObject.SetActive(false);
        GameObject.Find("Btn_Wind").SetActive(false);
    }

}
