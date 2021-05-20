using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour, IPointerClickHandler
{
    public enum BtnType
    {
        BGMOnOff,
        SEOnOff,
    }
    public BtnType btnType;
    public TextMeshProUGUI btnText;
    bool isBgmOn = true;
    bool isSEOn = true;
    Image btnSprite;

    private void Awake()
    {
        isBgmOn = !GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF;
        isSEOn = !GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF;
        btnText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        btnSprite = GetComponent<Image>();
        if(btnType == BtnType.BGMOnOff)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF)
            {
                btnText.text = "배경음 켜기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
            }
            else
            {
                btnText.text = "배경음 끄기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
            }
        }
        if (btnType == BtnType.SEOnOff)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF)
            {
                btnText.text = "효과음 켜기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
            }
            else
            {
                btnText.text = "효과음 끄기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
            }
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (btnType == BtnType.BGMOnOff)
        {
            isBgmOn = !isBgmOn;

            if (isBgmOn)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF = false;
                btnText.text = "배경음 끄기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF = true;
                btnText.text = "배경음 켜기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
            }
                
        }
        else if (btnType == BtnType.SEOnOff)
        {
            isSEOn = !isSEOn;

            if (isSEOn)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF = false;
                btnText.text = "효과음 끄기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_sky");
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF = true;
                btnText.text = "효과음 켜기";
                btnSprite.sprite = ExtendFunction.instance.SpriteReturn("button_orange");
            }
                
        }
    }
}
