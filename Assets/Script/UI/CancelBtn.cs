using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CancelBtn : MonoBehaviour, IPointerClickHandler
{
    public GameObject popup;

    public void OnPointerClick(PointerEventData eventData)
    {
        popup.SetActive(false);
    }
}
