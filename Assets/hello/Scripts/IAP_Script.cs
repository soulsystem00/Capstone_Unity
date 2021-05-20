using DevionGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Script : MonoBehaviour
{
    public void IAP_Success(int num)
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.cristal += num;
        GameObject.Find("Canvas").FindChild("UI_IAP", true).FindChild("IAP_Success", true).SetActive(true);
    }

    public void IAP_Fail()
    {
        GameObject.Find("Canvas").FindChild("UI_IAP", true).FindChild("IAP_Fail", true).SetActive(true);
    }
}
