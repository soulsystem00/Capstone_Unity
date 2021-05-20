using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodingEvent : MonoBehaviour
{
    public GameObject startPanel;
    public Slider slider;
    public TextMeshProUGUI text;
    AsyncOperation op;
    private void Awake()
    {
        op = SceneManager.LoadSceneAsync("main");
        op.allowSceneActivation = false;
    }
    private void OnEnable()
    {
         
        //StartCoroutine(ActiveOffCo());
    }

    private void Update()
    {
        if(op.progress >= 0.9f)
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
        //float startValue = 0;
        //while (startValue < 100)
        //{
        //    slider.value = Util.PercentReturn2(startValue, 100);
        //    text.text = startValue.ToNumber0() + " / " + "100" + "(" + slider.value.ToNumber0() + "%)";
        //    yield return new WaitForFixedUpdate();
        //    startValue += 100 * Time.deltaTime;

        //}

        ////startPanel.SetActive(false);
        ////gameObject.SetActive(false);
        //op.allowSceneActivation = true;
        //Debug.Log("hello2");
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
