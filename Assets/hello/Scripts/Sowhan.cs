using DevionGames;
using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Sowhan : MonoBehaviour
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

    //private void Awake()
    //{
        
    //}
    private void Start()
    {
        dd = GameObject.Find("GameManager");
        //Debug.Log(dd.name);
        unit = dd.GetComponent<GameManager>().unit;
        Cost_Increase = dd.GetComponent<GameManager>().Cost_Increase;
        spawnPoints = GetComponent<Transform>();
        btn = GetComponent<Button>();
        test = Resources.Load<GameObject>("test");
    }
    private void FixedUpdate()
    {
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
                game.layer = TeamNum + 8;
                game.GetComponent<UnitMove>().TeamNum = TeamNum;
                Instantiate(test, test_1[num]).GetComponent<Sohawn_CoolTIme>().s = game.GetComponent<UnitMove>().second;
                Debug.Log("소환");
                Cost -= game.GetComponent<UnitMove>().Cost;
                if (Cost < 0)
                    Cost = 0;
            }
        }
        //Debug.Log(btn.name);


    }

}
