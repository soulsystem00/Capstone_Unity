using DevionGames;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject gm;
    public int[] enableunit = new int[13]; // 이용가능한 유닛 
    public GameObject[] unit = new GameObject[5]; // 스택에 저장될 리스트
    public GameObject[] buttons; // 인벤토리 버튼들
    public GameObject[] storedUnit = new GameObject[5]; // 아래에 표시되는 리스트
    public GameObject[] gmunitlist; // 전체 유닛 리스트
    public Sprite im;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        gm = GameObject.Find("GameManager");
        enableunit = gm.GetComponent<GameManager>().enableunit;
        gmunitlist = gm.GetComponent<GameManager>().unitlist;
        unit = gm.GetComponent<GameManager>().unit;
        for (int i = 0; i < 5; i++) // 아래 사용유닛 목록 초기화
        {
            if (unit[i] != null)
            {
                //unit[i] = gmunitlist[i];
                storedUnit[i].FindChild("Image", true).GetComponent<Image>().sprite = unit[i].GetComponent<SpriteRenderer>().sprite;
                storedUnit[i].FindChild("Image", true).GetComponent<Image>().color = unit[i].GetComponent<SpriteRenderer>().color;
                //storedUnit[i].GetComponent<Image>().sprite = unit[i].GetComponent<SpriteRenderer>().sprite;
                //storedUnit[i].GetComponent<Image>().color = unit[i].GetComponent<SpriteRenderer>().color;
                //Debug.Log("Unit added");
            }
        }

        for (int i = 0; i < 13; i++) // 버튼 초기화
        {
            if (enableunit[i] == 1)
            {
                buttons[i].SetActive(true);
                buttons[i].FindChild("Image", true).GetComponent<Image>().sprite = gmunitlist[i].GetComponent<SpriteRenderer>().sprite;
                buttons[i].FindChild("Image", true).GetComponent<Image>().color = gmunitlist[i].GetComponent<SpriteRenderer>().color;
                //buttons[i].GetComponent<Button>().image.sprite = gmunitlist[i].GetComponent<SpriteRenderer>().sprite;
                //buttons[i].GetComponent<Button>().image.color = gmunitlist[i].GetComponent<SpriteRenderer>().color;
                //Debug.Log("button" + i + "enabled");
            }
            else
            {
                buttons[i].SetActive(false);
                //Debug.Log("button" + i + "disabled");
            }
        }
    }

    void OnDisable()
    {
        for(int i =0;i<5;i++)
        {
            if(unit[i] != null)
            {
                gm.GetComponent<GameManager>().unit[i] = unit[i];
            }
            else
            {
                gm.GetComponent<GameManager>().unit[i] = null;
            }
        }
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnitList(int num)    
    {
        for(int i =0;i<5;i++)
        {
            //Debug.Log(check(num));
            if(unit[i] == null && check(num))
            {
                unit[i] = gmunitlist[num];
                storedUnit[i].FindChild("Image",true).GetComponent<Image>().sprite = gmunitlist[num].GetComponent<SpriteRenderer>().sprite;
                storedUnit[i].FindChild("Image", true).GetComponent<Image>().color = gmunitlist[num].GetComponent<SpriteRenderer>().color;
                //storedUnit[i].GetComponent<Image>().sprite = gmunitlist[num].GetComponent<SpriteRenderer>().sprite;
                //storedUnit[i].GetComponent<Image>().color = gmunitlist[num].GetComponent<SpriteRenderer>().color;
                //Debug.Log("Unit added");
                break;
            }
        }
    }

    private bool check(int num)
    {
        int i = 0;
        for(i =0;i<5;i++)
        {
            if(unit[i] == null)
            {
                continue;
            }
            else
            {
                if(unit[i] == gmunitlist[num])
                {
                    break;
                }
            }
        }
        if (i == 5)
            return true;
        else
            return false;
    }

    public void Delect_Unit(int num)
    {
        unit[num] = null;
        storedUnit[num].FindChild("Image", true).GetComponent<Image>().sprite = im;
        storedUnit[num].FindChild("Image", true).GetComponent<Image>().color = new Color(40 / 255.0f, 36 / 255.0f, 29 / 255.0f);
        //storedUnit[num].GetComponent<Image>().sprite = im;
        //storedUnit[num].GetComponent<Image>().color = new Color(40 / 255.0f, 36 / 255.0f, 29 / 255.0f);
    }
}
