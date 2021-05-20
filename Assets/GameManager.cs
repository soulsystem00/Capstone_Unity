using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Android;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int selectStageNum;
    public GameObject[] unit = new GameObject[5];
    public GameObject[] unitlist = new GameObject[13];
    public GameObject[] unitlist_boss = new GameObject[13];
    public GameObject[] EnemyUnitList = new GameObject[13];
    public int[] skill_list = new int[3];
    public int current_Skill;
    public int[] enableunit = new int[13];
    public int money;
    public int cristal;
    public int score;
    public int time_m;
    public int time_total_s;
    public int time_score_s;
    public int time_score_delay;
    public int star;
    public int exp;
    public int[] Stage_Info = new int[18];
    public int Gm_speed;
    public float Cost_Increase;

    public bool Sound_ON_OFF;
    public bool Effect_ON_OFF;


    public string stage_selector;

    public int MMR;
    public int Game_Counter;
    private void Awake()
    {
        UIManager.instance.OnSceneLoad();
        instance = this;
        DontDestroyOnLoad(this);
        stage_selector = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        //if(Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        //{
        //    Debug.Log("Permission allowed");

        //}
        //else
        //{
        //    Debug.Log("Permission denied");
        //    Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        //    Debug.Log(Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"));

        //}
        get_Enable_Unit_From_File();
        get_Money_From_File();
        get_Stage_Info_From_File();
        get_exp_from_file();
        get_Increase_From_File();
        get_MMR_from_file();
        get_Gamecounter_from_file();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        Debug.Log("ApplicationQuit");
        save_Enable_Unit_on_the_file();
        save_Money_on_the_file();
        save_Stage_Info_on_the_file();
        save_exp_on_the_file();
        save_Increase_on_the_file();
        save_MMR_on_the_file();
        save_Gamecounter_on_the_file();
    }
    private void OnApplicationPause(bool pause)
    {
#if !UNITY_EDITOR
        if(pause)
        {
            Debug.Log("Application Pause");
            save_Enable_Unit_on_the_file();
            save_Money_on_the_file();
            save_Stage_Info_on_the_file();
            save_exp_on_the_file();
            save_Increase_on_the_file();
            save_MMR_on_the_file();
            save_Gamecounter_on_the_file();
        }
        else
            Debug.Log("b");
#endif

    }
    private void OnDestroy()
    {
        Debug.Log("Application Destory");
        save_Enable_Unit_on_the_file();
        save_Money_on_the_file();
        save_Stage_Info_on_the_file();
        save_exp_on_the_file();
        save_Increase_on_the_file();
        save_MMR_on_the_file();
        save_Gamecounter_on_the_file();
    }
    public void InventoryButton(int num)
    {
        Debug.Log(num);
    }

    /// <summary>
    /// 게임 판수 불러오기
    /// </summary>
    void get_Gamecounter_from_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "Gamecounter.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Game_Counter = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create Gamecounter file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0);
            sr.Close();
            fs.Close();
            Game_Counter = 0;
        }
    }

    /// <summary>
    /// MMR 불러오기
    /// </summary>
    void get_MMR_from_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "MMR.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            MMR = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create MMR file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(2500);
            sr.Close();
            fs.Close();
            MMR = 2500;
        }
    }
    /// <summary>
    /// 경험치 불러오기
    /// </summary>
    void get_exp_from_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "exp.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            exp = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create Money file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0);
            sr.Close();
            fs.Close();
            exp = 0;
        }
    }

    /// <summary>
    /// 돈 불러오기
    /// </summary>
    void get_Money_From_File()
    {
        
        string moneypath = Application.persistentDataPath + "/" + "Money.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            cristal = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create Money file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(200);
            sr.Close();
            fs.Close();
            cristal = 200;
        }
    }

    /// <summary>
    /// 이용가능한 유닛 불러오기
    /// </summary>
    void get_Enable_Unit_From_File()
    {
        string moneypath = Application.persistentDataPath + "/" + "EnableUnit.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load EnableUnit from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string[] tmp = sr.ReadLine().Split(' ');
            for(int i =0;i<tmp.Length - 1;i++)
            {
                //Debug.Log(tmp[i]);
            }
            for(int i =0;i<tmp.Length - 1;i++)
            {
                enableunit[i] = Convert.ToInt32(tmp[i]);
                
            }
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create EnableUnit file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine("0 0 0 0 0 0 0 0 0 0 0 0 0 ");
            sr.Close();
            fs.Close();
            for(int i =0;i<13;i++)
            {
                enableunit[i] = 0;
            }
        }
    }
    /// <summary>
    /// 코스트 증가량 불러오기
    /// </summary>
    void get_Increase_From_File()
    {

        string moneypath = Application.persistentDataPath + "/" + "Increase.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load Increase from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Cost_Increase = Convert.ToSingle(sr.ReadLine());
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, Increase Money file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0.05);
            sr.Close();
            fs.Close();
            Cost_Increase = 0.05f;
        }
    }
    /// <summary>
    /// 스테이지 정보 불러오기
    /// </summary>
    void get_Stage_Info_From_File()
    {
        string moneypath = Application.persistentDataPath + "/" + "StageInfo.txt";
        //Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            //Debug.Log("file Exist, load StageInfo from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string[] tmp = sr.ReadLine().Split(' ');
            for (int i = 0; i < tmp.Length - 1; i++)
            {
                Stage_Info[i] = Convert.ToInt32(tmp[i]);
            }
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create StageInfo file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine("0 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 ");
            sr.Close();
            fs.Close();
            for (int i = 0; i < 18; i++)
            {
                if(i == 0)
                {
                    Stage_Info[i] = 0;
                }
                else
                {
                    Stage_Info[i] = -1;
                }
                
            }
        }
    }


    void save_exp_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "exp.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(exp.ToString());
            sr.Close();
            fs.Close();
        }
        else
        {
            Debug.Log("file isn't Exist, create Money file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0);
            sr.Close();
            fs.Close();
            exp = 0;
        }
    }
    /// <summary>
    /// 돈 파일로 저장하기
    /// </summary>
    void save_Money_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "Money.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save Money from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(cristal.ToString());
            sr.Close();
            fs.Close();
        }
        else
        {
            Debug.Log("file isn't Exist, create Money file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(200);
            sr.Close();
            fs.Close();
            cristal = 200;
        }
    }
    /// <summary>
    /// 코스트 증가량 파일로 저장하기
    /// </summary>
    void save_Increase_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "Increase.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save Increase from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(Cost_Increase.ToString());
            sr.Close();
            fs.Close();
        }
        else
        {
            Debug.Log("file isn't Exist, create Increase file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0.05);
            sr.Close();
            fs.Close();
            Cost_Increase = 0.05f;
        }
    }
    /// <summary>
    /// 이용가능한 유닛 파일로 저장하기
    /// </summary>
    void save_Enable_Unit_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "EnableUnit.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save EnableUnit from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            string tmp = null;
            for (int i = 0; i < enableunit.Length; i++)
            {
                tmp += enableunit[i].ToString() + ' ';
            }
            Debug.Log(tmp);
            sr.WriteLine(tmp);
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create EnableUnit file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine("0 0 0 0 0 0 0 0 0 0 0 0 0 ");
            sr.Close();
            fs.Close();
            for (int i = 0; i < 13; i++)
            {
                enableunit[i] = 0;
            }
        }
    }

    /// <summary>
    /// 스테이지 정보 파일로 저장하기
    /// </summary>
    void save_Stage_Info_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "StageInfo.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save StageInfo from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            string tmp = null;
            for (int i = 0; i < Stage_Info.Length; i++)
            {
                tmp += Stage_Info[i].ToString() + ' ';
            }
            sr.WriteLine(tmp);
            sr.Close();
            fs.Close();

        }
        else
        {
            Debug.Log("file isn't Exist, create StageInfo file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine("0 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 ");
            sr.Close();
            fs.Close();
            for (int i = 0; i < 18; i++)
            {
                if (i == 0)
                {
                    Stage_Info[i] = 0;
                }
                else
                {
                    Stage_Info[i] = -1;
                }

            }
        }
    }
    /// <summary>
    /// MMR 파일로 저장하기
    /// </summary>
    void save_MMR_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "MMR.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save MMR from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(MMR.ToString());
            sr.Close();
            fs.Close();
        }
        else
        {
            Debug.Log("file isn't Exist, create MMR file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(2500);
            sr.Close();
            fs.Close();
            MMR = 2500;
        }
    }

    void save_Gamecounter_on_the_file()
    {
        string moneypath = Application.persistentDataPath + "/" + "Gamecounter.txt";
        Debug.Log(moneypath);
        if (File.Exists(moneypath))
        {
            Debug.Log("file Exist, save Gamecounter from file");
            FileStream fs = new FileStream(moneypath, FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(Game_Counter.ToString());
            sr.Close();
            fs.Close();
        }
        else
        {
            Debug.Log("file isn't Exist, create Gamecounter file");
            FileStream fs = new FileStream(moneypath, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0);
            sr.Close();
            fs.Close();
            Game_Counter = 0;
        }
    }

}
