using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using DevionGames;

public class shop : MonoBehaviour
{
    public static shop instance;
    public GameObject cost_I_cristal;
    public GameObject cost_my_cristal;
    public GameObject cost_I_money;
    public GameObject cost_my_money;
    public GameObject open_cr;
    public GameObject gm;
    public GameObject[] gmunitlist;
    TextMeshProUGUI cost_txt;
    int rnd;

    private void Start()
    {
        instance = this;
        gm = GameObject.Find("GameManager");
        gmunitlist = gm.GetComponent<GameManager>().unitlist;
        cost_I_cristal.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().cristal.ToString();
        cost_my_cristal.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().cristal.ToString();
        //cost_I_money.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().money.ToString();
        //cost_my_money.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().money.ToString();
        //cost_my.GetComponent<TextMeshProUGUI>().text=cost_I.GetComponent<TextMeshProUGUI>().text;
        //Debug.Log(cost_my_cristal.GetComponent<TextMeshProUGUI>().text);
        if (gm.GetComponent<GameManager>().stage_selector == "single")
        {
            GameObject.Find("Canvas").FindChild("HomeScene", true).SetActive(false);
            GameObject.Find("Canvas").FindChild("Panel_SelectStage", true).SetActive(true);
        }
        else if(gm.GetComponent<GameManager>().stage_selector == "multi")
        {
            GameObject.Find("Canvas").FindChild("HomeScene", true).SetActive(false);
            GameObject.Find("Canvas").FindChild("Stage_Multi", true).SetActive(true);
        }
    }
    public void BoxCost(int cost)
    {
        //cost_my.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().money.ToString();
        cost_my_cristal.GetComponent<TextMeshProUGUI>().text = cost_I_cristal.GetComponent<TextMeshProUGUI>().text;
        //Debug.Log(cost_my.GetComponent<TextMeshProUGUI>().text);
        int num;
        
        cost_txt = cost_my_cristal.GetComponent<TextMeshProUGUI>();
        string cost_tmpS = cost_txt.text;
        int cost_tmpI = int.Parse(cost_tmpS);

        if (cost_tmpI >= cost)
        {
            //GameObject.Find("ChestOpens").transform.Find("ChestOpen_" + num).gameObject.SetActive(true); //시발거 
            if (cost == 100)
            {
                num = 0;
                rnd = UnityEngine.Random.Range(0, 100);
                if (50 < rnd) { 
                    rnd = UnityEngine.Random.Range(0, 4) * 3;//normal
                }
                else if (20<rnd && rnd <= 50){
                    rnd = UnityEngine.Random.Range(0, 4) * 3 + 1;//blue
                }
                else
                {
                    rnd = UnityEngine.Random.Range(0, 4) * 3 + 2;//red
                }
                //set_img_with_Delay(rnd);
                GameObject.Find("ChestOpens").FindChild("ChestOpen_" + num, true).SetActive(true);
                
                if (gm.GetComponent<GameManager>().enableunit[rnd] == 1)
                {
                    cost_tmpI += cost / 10;
                }
                Invoke("set_img", 1f);
                //set_img();
            }
            else if (cost == 600)
            {
                num = 1;
                rnd = UnityEngine.Random.Range(0, 12);//all
                //set_img_with_Delay(rnd);
                GameObject.Find("ChestOpens").FindChild("ChestOpen_" + num, true).SetActive(true);
                
                if (gm.GetComponent<GameManager>().enableunit[rnd] == 1)
                {
                    cost_tmpI += cost / 10;
                }
                Invoke("set_img", 1f);
                //set_img();
            }
            else if (cost == 1000)
            {
                num = 2;
                rnd = UnityEngine.Random.Range(0, 4) * 3; //normal
                //set_img_with_Delay(rnd);
                GameObject.Find("ChestOpens").FindChild("ChestOpen_" + num, true).SetActive(true);
                
                if (gm.GetComponent<GameManager>().enableunit[rnd] == 1)
                {
                    cost_tmpI += cost / 10;
                }
                Invoke("set_img", 1f);
                //set_img();
            }
            else if (cost == 3000)
            {
                num = 3;
                rnd = UnityEngine.Random.Range(0, 4) * 3 + 1;//blue
                //set_img_with_Delay(rnd);
                GameObject.Find("ChestOpens").FindChild("ChestOpen_" + num, true).SetActive(true);
                
                if (gm.GetComponent<GameManager>().enableunit[rnd] == 1)
                {
                    cost_tmpI += cost / 10;
                }
                Invoke("set_img", 1f);
                //set_img();
            }
            else if (cost == 6000)
            {
                num = 4;
                rnd = UnityEngine.Random.Range(0, 4) * 3 + 2;//red
                //set_img_with_Delay(rnd);
                GameObject.Find("ChestOpens").FindChild("ChestOpen_" + num, true).SetActive(true);
                
                if (gm.GetComponent<GameManager>().enableunit[rnd] == 1)
                {
                    cost_tmpI += cost / 10;
                }
                Invoke("set_img", 1f);
                //set_img();
            }

            

            cost_tmpI = cost_tmpI - cost;
            cost_tmpS = cost_tmpI.ToString();
            cost_txt.text = cost_tmpS;
            
        }
        else
        {
            GameObject.Find("Canvas").FindChild("UI_IAP", true).SetActive(true);
        }

        cost_I_cristal.GetComponent<TextMeshProUGUI>().text = cost_my_cristal.GetComponent<TextMeshProUGUI>().text;
        gm.GetComponent<GameManager>().cristal = Convert.ToInt32(cost_I_cristal.GetComponent<TextMeshProUGUI>().text);
    }
    public void set_img()
    {
        open_cr.SetActive(true);
        open_cr.GetComponent<Image>().sprite = gmunitlist[rnd].GetComponent<SpriteRenderer>().sprite; //유닛
        open_cr.GetComponent<Image>().color = gmunitlist[rnd].GetComponent<SpriteRenderer>().color; //색
        gm.GetComponent<GameManager>().enableunit[rnd] = 1;//인벤
    }

    private void Update()
    {
        cost_I_cristal.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().cristal.ToString();
        cost_my_cristal.GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().cristal.ToString();
    }

    private void OnEnable()
    {

    }
}
