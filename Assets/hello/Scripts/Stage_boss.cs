using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_boss : MonoBehaviour
{
    public Transform spawnPoints;
    public int TeamNum;
    public GameObject tow;
    public int boss_num;
    private float hp;
    private GameObject dd;
    private GameObject[] unit = new GameObject[5];
    bool sowhan_complet;


    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        dd = GameObject.Find("GameManager");
        Debug.Log(dd.name);
        unit = dd.GetComponent<GameManager>().unitlist_boss;
        spawnPoints = GetComponent<Transform>();
        hp = 0f;
        sowhan_complet = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var tmp = tow.GetComponent<TowerScript>().Health;
        if(tmp > hp)
        {
            hp = tmp;
            Debug.Log(hp);
        }
        if ((tow.GetComponent<TowerScript>().Health <= hp / 2) && sowhan_complet)
        {
            Debug.Log("boss");
            Debug.Log(hp);
            if (unit[boss_num] != null)
            {
                GameObject game = Instantiate(unit[boss_num], spawnPoints);

                game.layer = TeamNum + 8;
                game.GetComponent<UnitMove>().TeamNum = TeamNum;
                //Debug.Log("적 소환");
                sowhan_complet = false;
            }
        }
    }
    
}
