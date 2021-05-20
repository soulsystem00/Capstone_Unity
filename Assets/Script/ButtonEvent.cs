using DevionGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonEvent : MonoBehaviour, IPointerClickHandler
{
    Transform canvas;
    private GameObject gm;
    public int stageNum;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").transform;
        gm = GameObject.Find("GameManager");
    }
    public enum ButtonType
    {
        Setting,
        GameStart,
        GameExit,
        MoveToMainScene,
        Crystal,
        Multiplay

    }

    public ButtonType buttonType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(buttonType == ButtonType.Setting)
        {
            Util.Instantiate("Popup_Option", canvas);
        }
        if(buttonType == ButtonType.Crystal)
        {
            GameObject.Find("Canvas").FindChild("UI_IAP", true).SetActive(true);
        }
        if (buttonType == ButtonType.GameStart)
        {
            GameManager gm;
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            int cnt = 0;
            for (int i =0;i<5;i++)
            {
                if(gm.unit[i] == null)
                {
                    cnt++;
                }
            }
            
            if(cnt != 5)
            {
                gm.selectStageNum = stageNum;
                //GameManager.instance.selectStageNum = stageNum;
                //SceneManager.LoadScene("game_" + stageNum);
                Instantiate(Resources.Load<GameObject>("Panel_Loading"),canvas);
            }
            else
            {
                GameObject.Find("Canvas").FindChild("Null_Unit_Alert", true).SetActive(true);
                Debug.Log("Unit Select");
            }
        }

        if (buttonType == ButtonType.GameExit)
        {
            if (SceneManager.GetActiveScene().name == "game_" + gm.GetComponent<GameManager>().selectStageNum)
            {
                PopupCommon.instance.Show(QuitMessage, "게임을 포기하시겠습니까?");
            }

            else
            {
                PopupCommon.instance.Show(QuitMessage, "게임을 종료하시겠습니까?");
            }
   
        }

        if (buttonType == ButtonType.MoveToMainScene)
        {
            GameObject.Find("Canvas").FindChild("Panel_Loading", true).SetActive(true);
            //SceneManager.LoadScene("main");
            //SceneManager.LoadSceneAsync("main");
        }

        if(buttonType == ButtonType.Multiplay)
        {
            GameManager gm;
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            int cnt = 0;
            for (int i = 0; i < 5; i++)
            {
                if (gm.unit[i] == null)
                {
                    cnt++;
                }
            }

            if (cnt != 5)
            {
                gm.selectStageNum = stageNum;
                //GameManager.instance.selectStageNum = stageNum;
                SceneManager.LoadScene("Multi");
                //Instantiate(Resources.Load<GameObject>("Panel_Loading"), canvas);

            }
            else
            {
                GameObject.Find("Canvas").FindChild("Null_Unit_Alert", true).SetActive(true);
                Debug.Log("Unit Select");
            }
        }
    }

    void QuitMessage(PopupCommon.QueryType result)
    {
        switch (result)
        {
            case PopupCommon.QueryType.Yes:
                if (SceneManager.GetActiveScene().name == "main")
                {
                    Application.Quit();
                }
                if (SceneManager.GetActiveScene().name == "game_" + gm.GetComponent<GameManager>().selectStageNum)
                {
                    gm.GetComponent<GameManager>().selectStageNum = 0;
                    Instantiate(Resources.Load<GameObject>("Panel_Loading"), canvas);
                }
                break;
            case PopupCommon.QueryType.No:
                //gameObject.SetActive(false);
                break;
        }
    }
}
