using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemySowhan_Multi : MonoBehaviour
{
    public Transform spawnPoints;
    public int TeamNum;
    public float[] delay = new float[13];
    public float[] speed = new float[13];
    public bool[] Unit_num = new bool[13];
   
    private GameObject dd;
    private GameObject[] unit = new GameObject[5];
    //public GameObject[] unit_list;
    // Start is called before the first frame update


    public TcpClient tcpClient;
    Thread thread;

    bool checker;
    int unit_num;
    string unit_name;
    bool start_checker;
    public GameObject Connecting_panel;
    public Text Connect_Text;
    string state_str;

    bool cost_holder;

    public GameObject Count_panel;
    bool count_panel_checker;
    public bool bot_checker;
    

    //string[] unit_info;
    List<string> unit_info;
    bool unit_info_checker;

    public GameObject point1;
    public GameObject point2;

    public GameObject tower1;
    public GameObject tower2;
    public TowerScript Enemy_tower;

    public NetworkStream ns;
    public StreamReader sr;
    public StreamWriter sw;

    public bool tower1_checker;
    public bool tower2_checker;
    private void Awake()
    {
        //unit_list = GameObject.Find("GameManager").GetComponent<GameManager>().EnemyUnitList;

    }
    void Start()
    {
        tower1_checker = false;
        tower2_checker = false;
        //unit_info = null;
        unit_info = new List<string>();
        unit_info_checker = false;
        bot_checker = false;
        count_panel_checker = false;
        cost_holder = GameObject.Find("point1").GetComponent<Sowhan_Multi>().cost_holder;
        start_checker = false;
        checker = false;
        unit_num = -1;
        dd = GameObject.Find("GameManager");
        //Debug.Log(dd.name);
        unit = dd.GetComponent<GameManager>().EnemyUnitList;
        spawnPoints = GetComponent<Transform>();
        state_str = "Connecting...";

        //thread = new Thread(new ThreadStart(check_Start));
        //if(tcpClient != null)
        //{
        //    thread.Start();
        //    Debug.Log("Check Start thread start");
        //}

        #region
        //for(int i = 0;i < 13;i++)
        //{
        //    delay[i] = UnityEngine.Random.Range(1, 15);
        //    speed[i] = UnityEngine.Random.Range(5, 11);
        //}

        //if (Unit_num[0] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_0", delay[0], speed[0]);//소환!
        //}
        //if (Unit_num[1] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_1", delay[1], speed[1]);//소환!
        //}
        //if (Unit_num[2] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_2", delay[2], speed[2]);//소환!
        //}
        //if (Unit_num[3] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_3", delay[3], speed[3]);//소환!
        //}
        //if (Unit_num[4] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_4", delay[4], speed[4]);//소환!
        //}
        //if (Unit_num[5] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_5", delay[5], speed[5]);//소환!
        //}
        //if (Unit_num[6] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_6", delay[6], speed[6]);//소환!
        //}
        //if (Unit_num[7] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_7", delay[7], speed[7]);//소환!
        //}
        //if (Unit_num[8] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_8", delay[8], speed[8]);//소환!
        //}
        //if (Unit_num[9] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_9", delay[9], speed[9]);//소환!
        //}
        //if (Unit_num[10] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_10", delay[10], speed[10]);//소환!
        //}
        //if (Unit_num[11] == true)
        //{
        //    InvokeRepeating("Enemy_Sowhan_11", delay[11], speed[11]);//소환!
        //}
        #endregion



    }

    // Update is called once per frame
    void Update()
    {
        //NetworkStream ns = new NetworkStream(tcpClient.Client);
        //StreamReader sn = new StreamReader(ns);
        //var asdf = sn.ReadLineAsync();
        //Debug.Log(asdf.Result);
    }
    private void FixedUpdate()
    {
        Connect_Text.text = state_str;
        //Debug.Log(state_str);
        if (checker)
        {
            enemy_Sowhan(unit_num);
        }

        if(start_checker)
        {
            Connecting_panel.SetActive(false);
            //start_checker = false;
        }
        else
        {
            Connecting_panel.SetActive(true);
        }

        if(count_panel_checker)
        {
            Count_panel.SetActive(true);
            count_panel_checker = false;
        }
        if(unit_info_checker)
        {
            changeUnits(unit_info);
            unit_info_checker = false;
        }
        if(bot_checker)
        {
            this.enabled = false;
        }
        if(tower1_checker)
        {
            tower1.SetActive(false);
            tower1_checker = false;
        }
        if(tower2_checker)
        {
            tower2.SetActive(false);
            tower2_checker = false;
        }
        //GameObject.Find("point1").GetComponent<Sowhan_Multi>().cost_holder = cost_holder;

    }

    private void OnDisable()
    {
        
    }

    public void check_Start()
    {
        while(tcpClient.Connected)
        {
            try
            {
                //Debug.Log("hello");
                var tmp = tcpClient.GetStream();
                string info = null;
                if (tcpClient.ReceiveBufferSize > 0)
                {
                    //Debug.Log("hello2");
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

                    //Debug.Log("hello3");
                    tmp.Read(bytes, 0, bytes.Length);

                    //Debug.Log("hello4");
                    info = Encoding.ASCII.GetString(bytes);
                    //Debug.Log(info);
                }

                //var ns = tcpClient.GetStream();

                //NetworkStream ns = new NetworkStream(tcpClient.Client);
                //StreamReader sn = new StreamReader(ns);
                //string info = sn.ReadLine();

                //Debug.Log(string.Compare(info, "Waiting"));
                if (string.Compare(info.Substring(0,5), "start") == 0)
                {
                    //cost_holder = false;
                    start_checker = true;
                    count_panel_checker = true;
                    sw.Write(" ");
                    sw.Flush();
                    /*5초 뒤 게임 시작 코드 작성*/
                    //var thread = new Thread(new ThreadStart(get_Unit));
                    //thread.Start();
                    //break;
                }
                else if (string.Compare(info.Substring(0,7), "Waiting") == 0)
                {
                    state_str = "Waiting...";
                }
                else if (string.Compare(info.Substring(0,3), "win") == 0)
                {
                    tower2_checker = true;
                    //tower2.SetActive(false);
                    tcpClient.Close();
                    break;
                }
                else if (string.Compare(info.Substring(0,4), "lose") == 0)
                {
                    tower1_checker = true;
                    //tower1.SetActive(false);
                    tcpClient.Close();
                    break;
                }
                else if(string.Compare(info.Substring(0,3),"bot") == 0)
                {
                    sw.Write(" ");
                    sw.Flush();
                    bot_checker = true;
                    start_checker = true;
                    count_panel_checker = true;
                    /*대기 시간 지나도 유저가 안들어오면 봇 시작*/
                }
                else if (string.Compare(info.Substring(0, 5), "units") == 0)
                {
                    ///*포인트 정보 받음*/
                    ////Debug.Log(info.Length);
                    ////Debug.Log(info);
                    var info_tmp = info.Split(' '); // unit + name1 + health1 + name2 + health2 .......
                    if (unit_info != null)
                    {
                        unit_info.Clear();
                    }
                    if (info.Length > 3)
                    {
                        //Debug.Log(info_tmp.Length);
                        for (int i = 1; i < info_tmp.Length - 1; i++)
                        {
                            //Debug.Log(info_tmp[i]);

                            //unit_info[i - 1] = str_tmp;
                            //Debug.Log(str_tmp.Length);
                            string str_tmp = info_tmp[i];
                            unit_info.Add(str_tmp);

                        }
                        //unit_info = info.Split(' ');
                        unit_info_checker = true;
                    }

                }
                else if (info != null)
                {
                    /*유닛 소환 숫자 도착시 활동*/
                    /*소환 유닛과 이름 넘겨 받음*/
                    string[] split_message = info.Split(' ');
                    //Debug.Log("mymy"+info);
                    //Debug.Log("unit num "+split_message[0]);
                    //Debug.Log("unit name "+split_message[1]);

                    unit_num = Convert.ToInt32(split_message[0]);
                    unit_name = split_message[1];
                    checker = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                //tcpClient.Close();
                start_checker = false;
                break;
                //throw;
            }
        }
    }

    void changeUnits(List<string> unit_info)
    {
        var info_arr = unit_info;
        //Debug.Log(info_arr.Count);
        int index = 1;
        /*point2 유닛 정보 체크*/
        try
        {
            int unit_count = point2.transform.childCount;
            Enemy_tower.Health = Convert.ToSingle(info_arr[0]);
            //Debug.Log("start");
            if (unit_count != 0)
            {
                for (int i = 0; i < unit_count; i++)
                {
                    var hello = point2.transform.GetChild(i).GetComponent<UnitMove>();
                    //Debug.Log(hello.name);
                    if (hello.name == info_arr[index])
                    {
                        hello.Health = Convert.ToSingle(info_arr[index + 1]);
                        index = index + 2;
                    }
                    else
                    {
                        hello.Health = 0;
                    }
                    if(hello.Health > 0)
                    {
                        point2.transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
            }
            
            else
            {
                //Debug.Log("Diff error");
            }
        }
        catch (Exception e)
        {
            //Debug.Log(e);
            //Debug.Log(point2.transform.childCount);
            //Debug.Log(info_arr.Count);
            //Debug.Log(index);
            //throw;
        }

    }

    void get_Unit()
    {
        while(true)
        {
            var tmp = tcpClient.GetStream();
            byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
            tmp.Read(bytes, 0, bytes.Length);
            string info = Encoding.ASCII.GetString(bytes);
            //NetworkStream ns = new NetworkStream(tcpClient.Client);
            //StreamReader sn = new StreamReader(ns);
            //string info = sn.ReadLine();
            //Debug.Log(info);
            //Debug.Log(Convert.ToInt32(info));
            //Debug.Log(info == "HeroKnight_8(Clone)");

            //enemy_Sowhan(Convert.ToInt32(info));
            if(!(string.Compare(info,"start") == 0 || string.Compare(info,"Waiting") == 0))
                unit_num = Convert.ToInt32(info);
                checker = true;
        }


    }

    void enemy_Sowhan(int num)
    {
        //Debug.Log(num + " 적 소환");
        if (unit[num] != null)
        {
            GameObject game = Instantiate(unit[num], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            game.name = unit_name;
            //Debug.Log("적 소환");
        }
        checker = false;
    }
    private void OnApplicationQuit()
    {
        if (thread.IsAlive)
            thread.Abort();
    }
}
