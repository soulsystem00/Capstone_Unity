using DevionGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHPbar : MonoBehaviour
{
    public GameObject tower;
    public TextMeshProUGUI Txt;
    public Slider slider;
    float max;
    // Start is called before the first frame update
    void Start()
    {
        max = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var hp = tower.GetComponent<TowerScript>().Health;
        if(max < hp)
        {
            max = hp;
        }
        //Txt.text = hp.ToString() + " " + "/" + " " + max.ToString();
        Txt.text = hp.ToString();
        slider.value = (hp / max) * 100;
    }
}
