using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Touch : MonoBehaviour
{
    public GameObject Circle;
    float steps;
    float tmp_time;
    private void OnEnable()
    {
        Time.timeScale = 1f;
        tmp_time = GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed;
        InvokeRepeating("Make_Circle", 0f, 0.5f);
        Invoke("disableThis", 5f);
        Invoke("tmptmp", 10f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() // 화면 비활성화 되면서 스킬 발동
    {
        GameObject.Find("Btn_Stun").SetActive(false);
    }
    void tmptmp()
    {
        Image image = GetComponent<Image>();
        image.enabled = true;
        gameObject.FindChild("Text (TMP)", true).SetActive(true);
        gameObject.FindChild("Steps", true).SetActive(true);
        gameObject.SetActive(false);
    }
    void disableThis()
    {
        steps = Convert.ToSingle(GameObject.Find("Steps").GetComponent<TextMeshProUGUI>().text);
        GameObject point2 = GameObject.Find("point2");
        for (int i = 0; i < point2.transform.childCount; i++)
        {
            Debug.Log(steps / 3);
            StartCoroutine(get_Back(steps / 3, point2.transform.GetChild(i).GetComponent<Rigidbody2D>()));
            //Debug.Log(point2.transform.GetChild(i).name + " " + point2.transform.GetChild(i).GetComponent<UnitMove>().Health.ToString());
        }
        CancelInvoke("Make_Circle");
        Image image = GetComponent<Image>();
        image.enabled = false;
        gameObject.FindChild("Text (TMP)", true).SetActive(false);
        gameObject.FindChild("Steps", true).SetActive(false);
        Time.timeScale = tmp_time;
    }
    IEnumerator get_Back(float num, Rigidbody2D rigid)
    {
        Debug.Log("Start Function");
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(num);
        //yield return new WaitForFixedUpdate();
        rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        Debug.Log("returned");
    }


    // -885 ~ 885
    // -360 ~ 360
    void Make_Circle()
    {
        Transform transform = GetComponent<Transform>();
        GameObject _Circle = Instantiate(Circle, transform);

        var curPosition = _Circle.GetComponent<RectTransform>();

        float cur_X = UnityEngine.Random.Range(-885f, 885f);
        float cur_Y = UnityEngine.Random.Range(-360f, 360f);

        Debug.Log("X : " + cur_X + " Y : " + cur_Y);
        //curPosition.position = new Vector3(cur_X, cur_Y, curPosition.position.z);
        curPosition.localPosition = new Vector3(cur_X, cur_Y, curPosition.localPosition.z);
    }
}
