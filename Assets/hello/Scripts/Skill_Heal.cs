using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Heal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Invoke("DisableThis", 3f);
        GameObject point2 = GameObject.Find("point1");
        for (int i = 0; i < point2.transform.childCount; i++)
        {
            point2.transform.GetChild(i).GetComponent<UnitMove>().setHealth(-10); // 매개변수 만큼 체력 - 매개변수 로 체력 만들어주는데 음수로 넣으면 체력이 더해짐
            Debug.Log(point2.transform.GetChild(i).name + " " + point2.transform.GetChild(i).GetComponent<UnitMove>().Health.ToString());
        }
    }

    void DisableThis()
    {
        Debug.Log("SKill Disabled");
        gameObject.SetActive(false);
        GameObject.Find("Btn_Heal").SetActive(false);
    }
}
