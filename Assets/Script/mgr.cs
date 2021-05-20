using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;

public class mgr : MonoBehaviour
{
    public GameObject team1;
    public GameObject team2;
    public GameObject Win;
    public GameObject Lose;
    private GameObject Game_mgr;
    private GameObject gm;
    private GameObject point1;
    private GameObject point2;


    public TcpClient tcpClient;

    string str;
    //public GameObject EndGame;
    // Start is called before the first frame update
    void Start()
    {
        str = null;

        Time.timeScale = Convert.ToSingle(GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed);
        gm = GameObject.Find("GameManager");
        Game_mgr = GameObject.Find("mgr");
        point1 = GameObject.Find("point1");
        point2 = GameObject.Find("point2");
        //Thread thread = new Thread(new ThreadStart(get_result));
        //thread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (team1.activeSelf == false)
        {
            //게임 종료 및 팀 1 승리
            //Time.timeScale = 0f;
            //GameObject tmp = GameObject.Find("Earthqueke");
            //if (tmp != null)
            //{
            //    tmp.SetActive(false);
            //}
            //Game_mgr.GetComponent<Game_score>().enabled = true;
            team2.GetComponent<TowerScript>().Health = 2147483647;// 게임이 백그라운드에서 진행이 되는데 타워 파괴되지 않게 바꿈
            Lose.SetActive(true);
            //EndGame.SetActive(true);

            //유닛 멈추기
            //unit_stop();
            //Destroy(point1);
            //Destroy(point2);
            point1.SetActive(false);
            point2.SetActive(false);
        }

        if (team2.activeSelf == false)
        {
            //게임 종료 및 팀 2 승리
            //Time.timeScale = 0f;
            //GameObject tmp = GameObject.Find("Earthqueke");
            //if (tmp != null)
            //{
            //    tmp.SetActive(false);
            //}

            Game_mgr.GetComponent<Game_score>().enabled = true;
            Win.SetActive(true);
            team1.GetComponent<TowerScript>().Health = 2147483647; // 게임이 백그라운드에서 진행이 되는데 타워 파괴되지 않게 바꿈
            Win.GetComponent<StageResult>().enabled = true; //별띄우기

            //end유닛 멈추기
            //unit_stop();
            //Destroy(point1);
            //Destroy(point2);
            point1.SetActive(false);
            point2.SetActive(false);

            //EndGame.SetActive(true);
        }



    }

    public void retry_game()
    {
        Debug.Log("다시~");
        SceneManager.LoadScene("SampleScene");
    }

    public void end_game()
    {
        //SceneManager.LoadScene("넘어갈 씬");
        Debug.Log("넘어가~");
    }

    public void unit_stop()
    {
        int count = point1.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            point1.transform.GetChild(i).GetComponent<UnitMove>().MAXSPEED = 0;
        }

        count = point2.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            point2.transform.GetChild(i).GetComponent<UnitMove>().MAXSPEED = 0;
        }
    }
}
