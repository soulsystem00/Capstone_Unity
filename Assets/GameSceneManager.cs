using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public GameObject point1;
    public static GameSceneManager instance;
    [Header("최대 골드 설정")]
    public int maxGold;
    [Header("추가 골드 설정")]
    public int addGold;
    [Header("골드 추가 시간 설정")]
    public int addGoldToSec;

    public Slider slider_Cost;
    public Text text_Cost;

    public Transform topEnemyPos;
    public Transform bottomEnemyPos;
    public Transform m_ingameUI;
    int currentGold;
    
    //골드에 변화가 생길때 마다 슬라이더와, Text에 반영
    int CurrentGold
    {
        get
        {
            return currentGold;
        }
        set
        {
            currentGold = value;
            if(currentGold >= maxGold)
            {
                currentGold = maxGold;
            }

            text_Cost.text = currentGold.ToString() + " / " + maxGold.ToString();
            slider_Cost.value = Util.PercentReturn2(value, maxGold);
        }
    }

    private void Awake()
    {
        instance = this;
        m_ingameUI = GameObject.Find("InGameUI").transform;
        //Util.Instantiate("BackGround" + GameManager.instance.selectStageNum);
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "Multi")
        {
            Transform ui = Util.Instantiate("UI_GameSpeed").transform;
            ui.transform.SetParent(m_ingameUI);
            ui.transform.localScale = new Vector3(1, 1, 1);
            ui.GetComponent<RectTransform>().offsetMin = Vector3.zero;
            ui.GetComponent<RectTransform>().offsetMax = new Vector3(1, 1);
        }

        //StartCoroutine(AddGoldCo());
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Multi")
        {
            CurrentGold = Convert.ToInt32(point1.GetComponent<Sowhan_Multi>().Cost);
        }
        else
        {
            CurrentGold = Convert.ToInt32(point1.GetComponent<Sowhan>().Cost);
        }
        
    }

    //addGoldToSec 설정된 초 마다 addGold만큼 현재 골드에 추가해줌
    IEnumerator AddGoldCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(addGoldToSec);
            
        }
    }
}
