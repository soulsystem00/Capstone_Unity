using DevionGames;
using PedometerU;
using PedometerU.Platforms;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class setGameUI : MonoBehaviour
{
    GameObject gm;
    public GameObject[] unitButtons = new GameObject[5];
    public GameObject[] SkillButtons = new GameObject[3];

    public Sprite null_btn;
    int step;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
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
