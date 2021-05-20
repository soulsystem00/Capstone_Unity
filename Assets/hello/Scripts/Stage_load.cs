using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stage_load : MonoBehaviour
{
    //public GameObject startPanel;
    public Slider slider;
    public TextMeshProUGUI text;
    AsyncOperation op;
    private GameObject gm;
    // Start is called before the first frame update
    private void Awake()
    {
        gm = GameObject.Find("GameManager");
        if (gm.GetComponent<GameManager>().selectStageNum == 0)
        {
            op = SceneManager.LoadSceneAsync("main");
        }
        else if(gm.GetComponent<GameManager>().selectStageNum == 19)
        {
            op = SceneManager.LoadSceneAsync("Multi");
        }
        else
        {
            op = SceneManager.LoadSceneAsync("game_" + gm.GetComponent<GameManager>().selectStageNum);
        }
        op.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (op.progress >= 0.9f)
        {
            //Debug.Log("hello");
            slider.value = 100;
            text.text = "100" + " / " + "100" + "(" + slider.value.ToNumber0() + "%)";
            Invoke("setSceneTrue", 0.5f);
            //op.allowSceneActivation = true;
        }
        else
        {
            slider.value = op.progress * 100;
            string tmp = string.Format("{0:0.00}", op.progress * 100);
            text.text = tmp + " / " + "100" + "(" + slider.value.ToNumber0() + "%)";
        }
    }
    IEnumerator ActiveOffCo()
    {
        slider.value = 100;
        text.text = 100 + " / " + "100" + "(" + slider.value.ToNumber0() + "%)";
        yield return new WaitForSeconds(0.5f);
        op.allowSceneActivation = true;
    }
    void setSceneTrue()
    {
        op.allowSceneActivation = true;
    }
}
