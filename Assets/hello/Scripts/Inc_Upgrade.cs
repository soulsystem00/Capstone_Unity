using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inc_Upgrade : MonoBehaviour
{
    public TextMeshProUGUI cur_increase;
    public TextMeshProUGUI next_increase;
    public TextMeshProUGUI Upgrade_Crystal;
    public TextMeshProUGUI Upgrade_rate;
    public TextMeshProUGUI Cur_Crystal;
    private int level;
    private void OnEnable()
    {
        Cur_Crystal.text = GameObject.Find("GameManager").GetComponent<GameManager>().cristal.ToString();
        float cur_per = GameObject.Find("GameManager").GetComponent<GameManager>().Cost_Increase;
        cur_increase.text = cur_per.ToString();
        next_increase.text = (cur_per + 0.01f).ToString();
        level = Convert.ToInt32(cur_per * 100 - 4);
        Upgrade_Crystal.text = (level * 1000).ToString();
        set_rate(level);
        //Debug.Log(level);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cur_Crystal.text = GameObject.Find("GameManager").GetComponent<GameManager>().cristal.ToString();
        float cur_per = GameObject.Find("GameManager").GetComponent<GameManager>().Cost_Increase;
        cur_increase.text = cur_per.ToString();
        next_increase.text = (cur_per + 0.01f).ToString();
        level = Convert.ToInt32(cur_per * 100 - 4);
        Upgrade_Crystal.text = (level * 1000).ToString();
        set_rate(level);
        //Debug.Log(level);
    }

    public void Cost_Upgrade()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().cristal > Convert.ToInt32(Upgrade_Crystal.text))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().cristal -= Convert.ToInt32(Upgrade_Crystal.text);
            int result = reinforce(level);

            if (result == 1) // 성공시
            {

                GameObject.Find("GameManager").GetComponent<GameManager>().Cost_Increase += 0.01f;
                set_rate(level);
                GameObject.Find("Upgrade").FindChild("Upgrade_Success", true).SetActive(true);
                //Debug.Log("성공했습니다.");
            }
            else // 실패시
            {
                GameObject.Find("Upgrade").FindChild("Upgrade_Fail", true).SetActive(true);
                //Debug.Log("실패했습니다.");
            }
        }
        else
        {
            GameObject.Find("Upgrade").FindChild("Not_Enough", true).SetActive(true);
            //Debug.Log("크리스탈 부족");
        }
    }

    public int reinforce(int level)
    {
        System.Random random = new System.Random();
        double rate = cal_rate(level);
        int result = random.Next(0, 10001);

        if (result <= rate)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }
    public int cal_rate(int level)
    {
        int rate = Convert.ToInt32(100 * 100 * Math.Exp(-1 * Convert.ToDouble(level) / 10));
        return rate;
    }

    public void set_rate(int level)
    {
        Upgrade_rate.text = Convert.ToString(Convert.ToDouble(cal_rate(level)) / 100) + "%";
    }
}
