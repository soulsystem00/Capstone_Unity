using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserLevel : MonoBehaviour
{
    GameManager gm;
    public GameObject exp_string;
    public GameObject exp_bar;
    public GameObject Level;
    private void OnEnable()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int exp = gm.exp;
        int cur_level = exp / 500;
        int cur_remain_exp = exp % 500;
        float bar_length = (416 - ((float)cur_remain_exp / 500) * 416) + 13;
        //Debug.Log(bar_length);
        Level.GetComponent<TextMeshProUGUI>().text = cur_level.ToString();
        exp_bar.GetComponent<RectTransform>().offsetMax = new Vector2(-bar_length, exp_bar.GetComponent<RectTransform>().offsetMax.y);
        exp_string.GetComponent<TextMeshProUGUI>().text = cur_remain_exp + "/500";

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
