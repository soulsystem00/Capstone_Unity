using DevionGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_inventory : MonoBehaviour
{
    GameManager gm;
    public GameObject[] buttons;
    public GameObject Skill_Slot;
    public Sprite im;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable() // 화면 활성화시 동작
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (gm.skill_list[i] == 1)
            {
                buttons[i].SetActive(true);
            }
            else
            {
                buttons[i].SetActive(false);
            }
        }

        if (gm.current_Skill != -1)
        {
            Skill_Slot.FindChild("Image", true).GetComponent<Image>().sprite = buttons[gm.current_Skill].FindChild("Image", true).GetComponent<Image>().sprite;
            Skill_Slot.FindChild("Image", true).GetComponent<Image>().color = buttons[gm.current_Skill].FindChild("Image", true).GetComponent<Image>().color;
            Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().text = buttons[gm.current_Skill].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().text;
            Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().fontSize = buttons[gm.current_Skill].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().fontSize;
            Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().color = buttons[gm.current_Skill].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().color;
        }
        else
        {
            Skill_Slot_pressed();
        }
        //Debug.Log("Hello World");
    }

    private void OnDisable() // 화면 비활성화 시 동작
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skill_Slot_pressed()
    {
        Skill_Slot.FindChild("Image", true).GetComponent<Image>().sprite = im;
        Skill_Slot.FindChild("Image", true).GetComponent<Image>().color = new Color(40 / 255.0f, 36 / 255.0f, 29 / 255.0f);
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().text = "SKILL";
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().fontSize = 28;
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        gm.current_Skill = -1;
    }

    public void Skill_Btn_pressed(int num)
    {
        Skill_Slot.FindChild("Image", true).GetComponent<Image>().sprite = buttons[num].FindChild("Image", true).GetComponent<Image>().sprite;
        Skill_Slot.FindChild("Image", true).GetComponent<Image>().color = buttons[num].FindChild("Image", true).GetComponent<Image>().color;
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().text = buttons[num].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().text;
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().fontSize = buttons[num].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().fontSize;
        Skill_Slot.FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().color = buttons[num].FindChild("Text (TMP)", true).GetComponent<TextMeshProUGUI>().color;
        gm.current_Skill = num;
    }
}
