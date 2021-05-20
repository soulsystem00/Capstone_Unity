using DevionGames;
using DG.Tweening;
using PedometerU;
using PedometerU.Platforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class setGameUI_Multi : MonoBehaviour
{
    GameObject gm;
    public GameObject[] unitButtons = new GameObject[5];
    public GameObject[] SkillButtons = new GameObject[3];

    public Sprite null_btn;
    int step;

    Socket TcpClient;
    public Text state;
    public GameObject exit;
    public GameObject Connecting;

    Socket My_Client;
    // Start is called before the first frame update
    void Start()
    {
        //ConnectServer();
        gm = GameObject.Find("GameManager");
        for(int i =0;i<5;i++)
        {
            if(gm.GetComponent<GameManager>().unit[i] != null)
            {
                //Debug.Log("start change Image");
                unitButtons[i].FindChild("CharacterBg", true).FindChild("Character", true).GetComponent<Image>().sprite = gm.GetComponent<GameManager>().unit[i].GetComponent<SpriteRenderer>().sprite;
                unitButtons[i].FindChild("CharacterBg", true).FindChild("Character", true).GetComponent<Image>().color = gm.GetComponent<GameManager>().unit[i].GetComponent<SpriteRenderer>().color;
                unitButtons[i].FindChild("Cost", true).GetComponent<TextMeshProUGUI>().text = gm.GetComponent<GameManager>().unit[i].GetComponent<UnitMove>().Cost.ToString();
                //Debug.Log("Image changed");
            }
            else if(gm.GetComponent<GameManager>().unit[i] == null)
            {
                unitButtons[i].FindChild("CharacterBg", true).FindChild("Character", true).GetComponent<Image>().sprite = null_btn;
                unitButtons[i].FindChild("CharacterBg", true).FindChild("Character", true).GetComponent<Image>().color = new Color(1, 1, 1);
                unitButtons[i].FindChild("Cost", true).GetComponent<TextMeshProUGUI>().text = "0";
            }
            
        }
        //gm.GetComponent<GameManager>().unit;
        if(gm.GetComponent<GameManager>().current_Skill != -1)
        {
            SkillButtons[gm.GetComponent<GameManager>().current_Skill].SetActive(true);
        }
        //if (gm.GetComponent<GameManager>().current_Skill == 0)
        //{

        //    GameObject.Find("Btn_earthqueke").SetActive(true);
        //    GameObject.Find("Btn_Wind").SetActive(false);
        //    GameObject.Find("Btn_Heal").SetActive(false);
        //}
        //else if (gm.GetComponent<GameManager>().current_Skill == 1)
        //{
        //    GameObject.Find("Btn_earthqueke").SetActive(false);
        //    GameObject.Find("Btn_Wind").SetActive(true);
        //    GameObject.Find("Btn_Heal").SetActive(false);
        //}
        //else if (gm.GetComponent<GameManager>().current_Skill == 2)
        //{
        //    GameObject.Find("Btn_earthqueke").SetActive(false);
        //    GameObject.Find("Btn_Wind").SetActive(false);
        //    GameObject.Find("Btn_Heal").SetActive(true);
        //}

        
    }

    

    void ConnectServer()
    {
        //state.text = "Connecting...";
        
        //try
        //{
        //    IPAddress iPAddress = IPAddress.Parse("192.168.35.62");
        //    My_Client = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        //    My_Client.Connect("192.168.35.62", 1234);
        //    state.text = "Waiting";
        //    int user_count = 0;
        //    while(user_count < 2)
        //    {
        //        NetworkStream ns = new NetworkStream(My_Client);
        //        StreamReader sr = new StreamReader(ns);
        //        var tmp = sr.ReadLine();
        //        state.text = tmp;
        //        user_count = Convert.ToInt32(tmp);
        //    }
        //    //GameObject.Find("point2").GetComponent<EnemySowhan_Multi>().my_Client = My_Client;
        //    Invoke("DisableConnecting", 1f);
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e);
        //    state.text = "Server isn't Opened";
        //    Invoke("ShowExitButton", 1f);
        //    throw;
        //}
        
    }
    private void OnApplicationQuit()
    {
        //NetworkStream ns = new NetworkStream(My_Client);
        //StreamWriter sw = new StreamWriter(ns);
        ////StreamReader sr = new StreamReader(ns);
        //sw.WriteLine("quit");
    }
    void ShowExitButton()
    {
        exit.SetActive(true);
    }

    void DisableConnecting()
    {
        Connecting.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("point1").GetComponent<Sowhan_Multi>().tcpClient.Connected)
        //{
        //    state.text = "connected";
        //    Invoke("DisableConnecting", 1f);
        //}
        //else
        //{
        //    state.text = "disConnected";
        //}
        //var pedometer = new Pedometer(OnStep);

    }

    

    void OnStep(int steps, double distance)
    {
        // Display the values
        step = steps;
        // Display distance in feet
        //distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
    }
}
