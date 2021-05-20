using DevionGames;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StageLoad : MonoBehaviour
{
    public GameObject[] Stages;
    public int[] stage_info;
    public Sprite star_enable;
    public Sprite star_disable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        stage_info = GameObject.Find("GameManager").GetComponent<GameManager>().Stage_Info;
        for(int i =0;i<stage_info.Length;i++)
        {
            if(stage_info[i] == -1)
            {
                Stages[i].FindChild("StageLock",true).SetActive(true);
                Stages[i].FindChild("StageDefault", true).SetActive(false);
                Stages[i].FindChild("StageComplete", true).SetActive(false);
            }
            else if(stage_info[i] == 0)
            {
                Stages[i].FindChild("StageLock", true).SetActive(false);
                Stages[i].FindChild("StageDefault", true).SetActive(true);
                Stages[i].FindChild("StageComplete", true).SetActive(false);
            }
            else if(stage_info[i] == 1)
            {
                Stages[i].FindChild("StageLock", true).SetActive(false);
                Stages[i].FindChild("StageDefault", true).SetActive(false);
                Stages[i].FindChild("StageComplete", true).SetActive(true);

                Stages[i].FindChild("StageComplete", true).FindChild("Star_1", true).GetComponent<Image>().sprite = star_enable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_2", true).GetComponent<Image>().sprite = star_disable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_3", true).GetComponent<Image>().sprite = star_disable;
            }
            else if (stage_info[i] == 2)
            {
                Stages[i].FindChild("StageLock", true).SetActive(false);
                Stages[i].FindChild("StageDefault", true).SetActive(false);
                Stages[i].FindChild("StageComplete", true).SetActive(true);

                Stages[i].FindChild("StageComplete", true).FindChild("Star_1", true).GetComponent<Image>().sprite = star_enable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_2", true).GetComponent<Image>().sprite = star_enable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_3", true).GetComponent<Image>().sprite = star_disable;
            }
            else if (stage_info[i] == 3)
            {
                Stages[i].FindChild("StageLock", true).SetActive(false);
                Stages[i].FindChild("StageDefault", true).SetActive(false);
                Stages[i].FindChild("StageComplete", true).SetActive(true);

                Stages[i].FindChild("StageComplete", true).FindChild("Star_1", true).GetComponent<Image>().sprite = star_enable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_2", true).GetComponent<Image>().sprite = star_enable;
                Stages[i].FindChild("StageComplete", true).FindChild("Star_3", true).GetComponent<Image>().sprite = star_enable;
            }
        }
    }
}
