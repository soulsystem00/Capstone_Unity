using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySowhan : MonoBehaviour
{
    public Transform spawnPoints;
    public int TeamNum;
    public float[] delay = new float[13];
    public float[] speed = new float[13];
    public bool[] Unit_num = new bool[13];
   
    private GameObject dd;
    private GameObject[] unit = new GameObject[5];
    // Start is called before the first frame update

    private void Awake()
    {
       
    }
    void Start()
    {
        dd = GameObject.Find("GameManager");
        ////Debug.Log(dd.name);
        unit = dd.GetComponent<GameManager>().EnemyUnitList;
        spawnPoints = GetComponent<Transform>();

        for(int i = 0;i < 13;i++)
        {
            delay[i] = Random.Range(1, 15);
            speed[i] = Random.Range(5, 11);
        }

        if (Unit_num[0] == true)
        {
            InvokeRepeating("Enemy_Sowhan_0", delay[0], speed[0]);//소환!
        }
        if (Unit_num[1] == true)
        {
            InvokeRepeating("Enemy_Sowhan_1", delay[1], speed[1]);//소환!
        }
        if (Unit_num[2] == true)
        {
            InvokeRepeating("Enemy_Sowhan_2", delay[2], speed[2]);//소환!
        }
        if (Unit_num[3] == true)
        {
            InvokeRepeating("Enemy_Sowhan_3", delay[3], speed[3]);//소환!
        }
        if (Unit_num[4] == true)
        {
            InvokeRepeating("Enemy_Sowhan_4", delay[4], speed[4]);//소환!
        }
        if (Unit_num[5] == true)
        {
            InvokeRepeating("Enemy_Sowhan_5", delay[5], speed[5]);//소환!
        }
        if (Unit_num[6] == true)
        {
            InvokeRepeating("Enemy_Sowhan_6", delay[6], speed[6]);//소환!
        }
        if (Unit_num[7] == true)
        {
            InvokeRepeating("Enemy_Sowhan_7", delay[7], speed[7]);//소환!
        }
        if (Unit_num[8] == true)
        {
            InvokeRepeating("Enemy_Sowhan_8", delay[8], speed[8]);//소환!
        }
        if (Unit_num[9] == true)
        {
            InvokeRepeating("Enemy_Sowhan_9", delay[9], speed[9]);//소환!
        }
        if (Unit_num[10] == true)
        {
            InvokeRepeating("Enemy_Sowhan_10", delay[10], speed[10]);//소환!
        }
        if (Unit_num[11] == true)
        {
            InvokeRepeating("Enemy_Sowhan_11", delay[11], speed[11]);//소환!
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enemy_Sowhan_0()
    {
        //Debug.Log("h");
        if (unit[0] != null)
        {
            GameObject game = Instantiate(unit[0], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_1()
    {
        ////Debug.Log("h");
        if (unit[1] != null)
        {
            GameObject game = Instantiate(unit[1], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_2()
    {
        ////Debug.Log("h");
        if (unit[2] != null)
        {
            GameObject game = Instantiate(unit[2], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            //Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_3()
    {
        //Debug.Log("h");
        if (unit[3] != null)
        {
            GameObject game = Instantiate(unit[3], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            //Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_4()
    {
        //Debug.Log("h");
        if (unit[4] != null)
        {
            GameObject game = Instantiate(unit[4], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_5()
    {
        //Debug.Log("h");
        if (unit[5] != null)
        {
            GameObject game = Instantiate(unit[5], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_6()
    {
        //Debug.Log("h");
        if (unit[6] != null)
        {
            GameObject game = Instantiate(unit[6], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_7()
    {
        //Debug.Log("h");
        if (unit[7] != null)
        {
            GameObject game = Instantiate(unit[7], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_8()
    {
        //Debug.Log("h");
        if (unit[8] != null)
        {
            GameObject game = Instantiate(unit[8], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_9()
    {
        //Debug.Log("h");
        if (unit[9] != null)
        {
            GameObject game = Instantiate(unit[9], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_10()
    {
        //Debug.Log("h");
        if (unit[10] != null)
        {
            GameObject game = Instantiate(unit[10], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_11()
    {
        //Debug.Log("h");
        if (unit[11] != null)
        {
            GameObject game = Instantiate(unit[11], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_12()
    {
        //Debug.Log("h");
        if (unit[12] != null)
        {
            GameObject game = Instantiate(unit[12], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }
    public void Enemy_Sowhan_No()
    {
        //Debug.Log("h");
        if (unit[11] != null)
        {
            GameObject game = Instantiate(unit[11], spawnPoints);

            game.layer = TeamNum + 8;
            game.GetComponent<UnitMove>().TeamNum = TeamNum;
            ////Debug.Log("적 소환");

        }
    }

}
