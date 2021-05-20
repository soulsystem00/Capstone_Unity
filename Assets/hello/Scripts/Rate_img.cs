using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rate_img : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI text;
    private GameObject gm;
    private int mmr;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        mmr = gm.GetComponent<GameManager>().MMR;
    }
    private void OnEnable()
    {
        gm = GameObject.Find("GameManager");
        mmr = gm.GetComponent<GameManager>().MMR;
    }
    // Update is called once per frame
    void Update()
    {
        switch (mmr/1000)
        {
            case 0:
                img.sprite = Resources.Load("Rate_bronze", typeof(Sprite)) as Sprite;
                mmrprint("Bronze");
                break;
            case 1:
                img.sprite = Resources.Load("Rate_silver", typeof(Sprite)) as Sprite;
                mmrprint("Silver");
                
                break;
            case 2:
                img.sprite = Resources.Load("Rate_gold", typeof(Sprite)) as Sprite;
                mmrprint("Gold");
                break;
            default:
                img.sprite = Resources.Load("Rate_master", typeof(Sprite)) as Sprite;
                text.text = "Master";
                break;
        }
    }

    void mmrprint(string rate_text)
    {

        switch ((mmr - (mmr / 1000) * 1000) / 100)
        {
            case 0:
                text.text = rate_text + " 5";
                break;
            case 1:
                text.text = rate_text + " 5";
                break;
            case 2:
                text.text = rate_text + " 4";
                break;
            case 3:
                text.text = rate_text + " 4";
                break;
            case 4:
                text.text = rate_text + " 3";
                break;
            case 5:
                text.text = rate_text + " 3";
                break;
            case 6:
                text.text = rate_text + " 2";
                break;
            case 7:
                text.text = rate_text + " 2";
                break;
            case 8:
                text.text = rate_text + " 1";
                break;
            case 9:
                text.text = rate_text + " 1";
                break;
        }
    }
}
