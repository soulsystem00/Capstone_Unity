using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sec_Count : MonoBehaviour
{
    public TextMeshProUGUI text;
    int sec;
    // Start is called before the first frame update
    void Start()
    {
        sec = 5;
        StartCoroutine(Count());
    }

    // Update is called once per frame
    void Update()
    {
        if(sec > 0)
        {
            text.text = sec.ToString();
        }
        else
        {
            gameObject.SetActive(false);
            GameObject.Find("point1").GetComponent<Sowhan_Multi>().cost_holder = false;
            GameObject.Find("point2").GetComponent<EnemySowhan>().enabled = !GameObject.Find("point2").GetComponent<EnemySowhan_Multi>().enabled;
        }
    }

    IEnumerator Count()
    {
        while (sec > 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            sec--;
        }


    }
}
