using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSpeedOnOff : MonoBehaviour, IPointerClickHandler
{
    Image m_sprite;
    Game_speed speedManager;
    private GameObject gm;
    public bool isOn;

    public enum SpeedType
    {
        x1,
        x2,
        x3
    }
    
    public SpeedType speedType;
    private void Awake()
    {
        gm = GameObject.Find("GameManager");
        m_sprite = GetComponent<Image>();
        speedManager = transform.parent.GetComponent<Game_speed>();
        //speedManager.BtnReset();
    }

    private void Start()
    {
        speedManager.BtnInit();
    }
    public void BtnReset()
    {
        isOn = false;
        m_sprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
        //Debug.Log("disable");
    }
    public void BtnReset_Enable()
    {
        isOn = true;
        m_sprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
        //Debug.Log("enable");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        speedManager.BtnReset();
        int speed = 0;
        switch (speedType)
        {
            case SpeedType.x1:
                speed = 1;
                break;
            case SpeedType.x2:
                speed = 2;
                break;
            case SpeedType.x3:
                speed = 3;
                break;
        }
        Spd(speed);

        isOn = !isOn;
        if (isOn)
        {
            m_sprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
        }
        else
        {
            m_sprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
        }
    }

    public void Spd(int speed)
    {
        Time.timeScale = speed;
        gm.GetComponent<GameManager>().Gm_speed = speed;
    }
}
