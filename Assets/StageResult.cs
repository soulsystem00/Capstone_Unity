using DevionGames;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageResult : MonoBehaviour
{

    public enum ResultType
    {
        CLEAR,
        FAILD,
    }
    public ResultType resultType;
    public int settingScoreStar1;
    public int settingScoreStar2;
    public int settingScoreStar3;

    public int clearScore;
    public List<GameObject> starList = new List<GameObject>();

    bool temp;
    bool temp2;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioClip resultBGM;

    bool sound_Effect;
    bool sound_BGM;

    private GameObject gm;
    Transform canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
        gm = GameObject.Find("GameManager");
    }
    private void OnEnable()
    {
        gm = GameObject.Find("GameManager");
        audioSource.clip = audioClip;
        temp = GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF;
        //GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF = true;

        temp2 = GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF;
        //GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF = true;

        sound_Effect = GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF;
        sound_BGM = GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF;
        GameObject.Find("GameManager").GetComponent<GameManager>().Game_Counter += 1;
        var result_audio = gameObject.AddComponent<AudioSource>();
        result_audio.clip = resultBGM;
        result_audio.volume = 0.3f;
        result_audio.playOnAwake = false;

        if (!sound_BGM)
        {
            result_audio.Play();
        }


        Time.timeScale = 1f;
        if (resultType != ResultType.CLEAR)
        {
            if (GameObject.Find("Canvas").FindChild("Connecting", true) == null)
                return;
            else
            {
                int dx = Cal_MMR(GameObject.Find("GameManager").GetComponent<GameManager>().Game_Counter);
                GameObject.Find("GameManager").GetComponent<GameManager>().MMR -= dx;
            }
            return;
        }
        else
        {
            int dx = Cal_MMR(GameObject.Find("GameManager").GetComponent<GameManager>().Game_Counter);
            GameObject.Find("GameManager").GetComponent<GameManager>().MMR += dx;
        }

        foreach (var item in starList)
        {
            item.transform.localScale = new Vector3(2, 2, 2);
            item.SetActive(false);
        }

        StartCoroutine(StarSettingCo());
    }
    //private void Update()
    //{
    //    if (Application.platform == RuntimePlatform.Android)
    //    {
    //        if (Input.GetKey(KeyCode.Escape))

    //        {
    //            GoMainScene();
    //        }
    //    }
    //}
    IEnumerator StarSettingCo()
    {


        yield return new WaitForSeconds(0.5f);
        if (settingScoreStar1 <= clearScore)
        {
            starList[0].gameObject.SetActive(true);
            starList[0].transform.DOScale(1, 0.25f);
            if(!sound_Effect)
            {
                audioSource.Play();
            }
            
        }

        yield return new WaitForSeconds(0.5f);
        if (settingScoreStar2 <= clearScore)
        {
            starList[1].gameObject.SetActive(true);
            starList[1].transform.DOScale(1, 0.25f);
            if (!sound_Effect)
            {
                audioSource.Play();
            }
        }

        yield return new WaitForSeconds(0.5f);
        if (settingScoreStar3 <= clearScore)
        {
            starList[2].gameObject.SetActive(true);
            starList[2].transform.DOScale(1, 0.25f);
            if (!sound_Effect)
            {
                audioSource.Play();
            }
        }
    }

    public void GoMainScene()
    {
        Debug.Log(GameObject.Find("Canvas").FindChild("Connecting", true) == null);
        if (GameObject.Find("Canvas").FindChild("Connecting", true) == null)
            GameObject.Find("GameManager").GetComponent<GameManager>().stage_selector = "single";
        else
            GameObject.Find("GameManager").GetComponent<GameManager>().stage_selector = "multi";

        GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF = temp;
        GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF = temp2;
        //SceneManager.LoadScene("main");

        GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed = 1;
        GameObject.Find("GameManager").GetComponent<GameManager>().selectStageNum = 0;
        Instantiate(Resources.Load<GameObject>("Panel_Loading"), canvas);

        //if(SceneManager.GetActiveScene().name == "main")
        //{
        //    GameObject.Find("Canvas").FindChild("HomeScene", true).SetActive(false);
        //    GameObject.Find("Canvas").FindChild("Panel_SelectStage", true).SetActive(true);
        //}
    }

    void asdf()
    {
        Debug.Log("hello");
        GameObject.Find("Canvas").FindChild("HomeScene", true).SetActive(false);
        GameObject.Find("Canvas").FindChild("Panel_SelectStage", true).SetActive(true);
    }

    int Cal_MMR(int num)
    {
        int random_num = UnityEngine.Random.Range(25, 35);
        int rate = Convert.ToInt32(100 * Math.Exp(-0.7 * Convert.ToDouble(num) / 30) + random_num);
        return rate;
    }
}
