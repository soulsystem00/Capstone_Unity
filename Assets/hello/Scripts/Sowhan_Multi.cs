using DevionGames;
using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Sowhan_Multi : MonoBehaviour
{
    public Transform spawnPoints;
    public Transform[] test_1 = new Transform[5];
    public GameObject[] unit = new GameObject[5];
    public Button btn;
    public int TeamNum;
    public GameManager gm;
    public GameObject dd;
    public GameObject test;
    
    public float Cost;
    float Cost_Increase;

    public TcpClient tcpClient;
    Thread thread2;

    public UdpClient UdpClient;
    public GameObject tower;
    public Text state;

    private float Health;

    public GameObject exit;

    private GameObject[] gm_unit_list;

    int unit_num;
    bool sowhan_Checker;
    public bool cost_holder;


    public GameObject point1;
    public GameObject point2;

    public GameObject mgr;

    string unit_info;


    public TowerScript asdfasdf;
    bool connect_checker;
    bool disconnect_checker;
    int unit_count;
    Thread thread3;
    Thread thread_tmp;

    NetworkStream ns;
    StreamReader sr;
    StreamWriter sw;
    private void Awake()
    {


        //tcpClient.Connect("192.168.35.62", 1234);


        
        //thread2 = new Thread(new ThreadStart(getStream));
        //thread2.Start();

    }
    private void Start()
    {

        //NetworkStream ns = new NetworkStream(tcpClient.Client);
        //StreamWriter sw = new StreamWriter(ns);
        //sw.Write(point1);
        //sw.Flush();

        connect_checker = false;
        disconnect_checker = false;
        dd = GameObject.Find("GameManager");
        //Debug.Log(dd.name);
        unit = dd.GetComponent<GameManager>().unit;
        gm = dd.GetComponent<GameManager>();
        Cost_Increase = dd.GetComponent<GameManager>().Cost_Increase;
        spawnPoints = GetComponent<Transform>();
        btn = GetComponent<Button>();
        test = Resources.Load<GameObject>("test");
        asdfasdf = tower.GetComponent<TowerScript>();
        gm_unit_list = dd.GetComponent<GameManager>().unitlist;
        thread3 = new Thread(new ThreadStart(point2.GetComponent<EnemySowhan_Multi>().check_Start));
        thread_tmp = new Thread(new ThreadStart(Connect));
        thread_tmp.Start();

        //InvokeRepeating("point_checker", 0f, 0.4f);
    }
    private void FixedUpdate()
    {
        //Debug.Log("fixed" + connect_checker);
        if(disconnect_checker)
        {
            state.text = "Disconnected";
            disconnect_checker = false;
        }
        if (connect_checker)
        {
            ns = new NetworkStream(tcpClient.Client);
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
            //Debug.Log("connect_checker");
            //tcpClient.NoDelay = true;
            ////tcpClient.ReceiveBufferSize = 1024;
            ////tcpClient.SendBufferSize = 2048;
            point2.GetComponent<EnemySowhan_Multi>().tcpClient = tcpClient;
            mgr.GetComponent<mgr>().tcpClient = tcpClient;
            Health = tower.GetComponent<TowerScript>().Health;
            string mmr = gm.GetComponent<GameManager>().MMR.ToString();
            /*서버에 mmr 전달*/
            sendStream(mmr);

            //Thread thread1 = new Thread(new ThreadStart(Check_Fail));
            //if (tcpClient != null)
            //    thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(sendStream));
            //if (tcpClient != null)
            thread2.Start();

            point2.GetComponent<EnemySowhan_Multi>().ns = ns;
            point2.GetComponent<EnemySowhan_Multi>().sr = sr;
            point2.GetComponent<EnemySowhan_Multi>().sw = sw;
            thread3.Start();
            InvokeRepeating("point_checker", 0f, 0.2f);
            //Debug.Log("Check Start thread start");
            connect_checker = false;
        }

        if (cost_holder)
        {
            Cost = 0;
        }
        Health = tower.GetComponent<TowerScript>().Health;
        Cost = Cost + Cost_Increase;
        if(Cost > 100)
        {
            Cost = 100;
        }
        //Debug.Log("Cost : " + Cost);

    }
    private void Update()
    {
        
    }
    public void UnitSowhan(int num)
    {
        if(unit[num] != null)
        {
            GameObject game = Instantiate(unit[num], spawnPoints);
            if (Cost < game.GetComponent<UnitMove>().Cost)
                Destroy(game);
            else
            {
                //Debug.Log("소환");
                //var ns = tcpClient.GetStream();
                //NetworkStream ns = new NetworkStream(tcpClient.Client);
                //StreamWriter sw = new StreamWriter(ns);
                //sw.Write(num.ToString());
                //sw.Write(num.ToString());
                //sw.Flush();
                //object tmptmp = num.ToString();
                //Thread thread = new Thread(new ParameterizedThreadStart(sendStream));
                //thread.Start(tmptmp);
                int send_num = 0;
                for (int i = 0; i < gm_unit_list.Length; i++)
                {
                    if (unit[num] == gm_unit_list[i])
                        send_num = i;
                }
                unit_count++;
                sowhan_Checker = true;
                unit_num = send_num;
                game.layer = TeamNum + 8;
                game.GetComponent<UnitMove>().TeamNum = TeamNum;
                game.name = unit_count.ToString();
                
                Instantiate(test, test_1[num]).GetComponent<Sohawn_CoolTIme>().s = game.GetComponent<UnitMove>().second;
                //var ns = tcpClient.GetStream();

                Cost -= game.GetComponent<UnitMove>().Cost;
                if (Cost < 0)
                    Cost = 0;
            }
        }
        //Debug.Log(btn.name);
    }

    void Connect()
    {
        try
        {
            unit_count = 0;
            cost_holder = true;
            unit_num = -1;
            sowhan_Checker = false;
            tcpClient = new TcpClient();
            tcpClient.Connect("211.201.211.147", 1234);
            //Debug.Log("connected");
            connect_checker = true;
            //Debug.Log(connect_checker);
            //thread_tmp.Join();

        }
        catch (Exception e)
        {
            //Debug.Log(e);
            disconnect_checker = true;
            //state.text = "Disconnected";
            //exit.SetActive(true);
        }
    }

    void getStream()
    {
        while(true)
        {
            //var tmp = tcpClient.GetStream();

            //byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
            //tmp.Read(bytes, 0, bytes.Length);
            //string info = Encoding.ASCII.GetString(bytes);
            //Debug.Log(info);
            //if(info == "HeroKnight_8(Clone)")
            //{

            //}
                //StreamReader sr = new StreamReader(tmp);
                //Debug.Log(sr.ReadLine());HeroKnight_8(Clone)



        }

    }
    void Check_Fail()
    {
        while(true)
        {
            try
            {
                if (Health <= 0)
                {
                    if(tcpClient.Connected)
                    {
                        NetworkStream ns = new NetworkStream(tcpClient.Client);
                        StreamWriter sw = new StreamWriter(ns);
                        sw.Write("lose");
                        sw.Flush();
                    }

                }
            }
            catch (Exception e)
            {
                /*판넬 활성화*/
                throw;
            }

        }
    }
    void point_checker()
    {
        unit_info = "";
        unit_info += asdfasdf.Health + " ";
        int unit_count = point1.transform.childCount;
        if (unit_count != 0)
        {
            for (int i = 0; i < unit_count; i++)
            {
                var hello = point1.transform.GetChild(i);
                float health = hello.GetComponent<UnitMove>().Health;
                string name = hello.name;
                unit_info += name + " " + health.ToString() + " ";
                //Debug.Log(point2.transform.GetChild(i).name +  " " + point2.transform.GetChild(i).GetComponent<UnitMove>().Health.ToString());
            }
            send_Unit_info(unit_info);
        }
    }
    public void sendStream(string str)
    {
        
        NetworkStream ns = new NetworkStream(tcpClient.Client);
        StreamWriter sw = new StreamWriter(ns);
        sw.Write(str);
        sw.Flush();
        
    }

    void sendStream()
    {
        while (true)
        {
            try
            {
                if (sowhan_Checker)
                {
                    string tmp = unit_num.ToString();
                    string message = unit_num.ToString() + " " + unit_count.ToString(); //소환 유닛과 이름 넘겨줌
                    //byte[] transferStr = Encoding.Default.GetBytes(message);
                    //tcpClient.Client.BeginSend(transferStr, 0, transferStr.Length, SocketFlags.None,
                    //                        new AsyncCallback(sendStr), tcpClient.Client);
                    sw.Write(message);
                    sw.Flush();
                    //Debug.Log(unit_num.ToString() + " 전송");
                    ////sw.Write(tmp);
                    //sw.WriteAsync(tmp).ConfigureAwait(false);
                    //sw.Flush();
                    sowhan_Checker = false;
                }

                if (Health <= 0)
                {
                    if (tcpClient.Connected)
                    {
                        sw.Write("lose");
                        sw.Flush();
                    }
                }
            }
            catch (Exception)
            {
                break;
            }
            

        }
    }
    static void sendStr(IAsyncResult ar)
    {
        Socket transferSock = (Socket)ar.AsyncState;
        int strLength = transferSock.EndSend(ar);
    }

    void send_Unit_info(string unit_info)
    {
        NetworkStream ns = new NetworkStream(tcpClient.Client);
        StreamWriter sw = new StreamWriter(ns);
        sw.Write("units " + unit_info);
        sw.Flush();
    }
    private void OnApplicationQuit()
    {
        //Debug.Log("close");
        sendStream("close");
    }
}
