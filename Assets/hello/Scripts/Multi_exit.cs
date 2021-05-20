using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Multi_exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void asdfasdfasdf(string tmp)
    {
        var tcpClient = GameObject.Find("point1").GetComponent<Sowhan_Multi>().tcpClient;
        
        if (tcpClient.Connected)
        {
            NetworkStream ns = new NetworkStream(tcpClient.Client);
            StreamWriter sw = new StreamWriter(ns);
            sw.Write(tmp);
            sw.Flush();
        }
        if(tmp == "close")
        {
            tcpClient.Close();
        }
    }
}
