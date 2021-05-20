using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DevionGames;
using System;

public class Circle_Script : MonoBehaviour
{
    RectTransform Rect;
    public TextMeshProUGUI count;
    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        count = GameObject.Find("Steps").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var cur = Rect.localScale;
        if(cur.x < 0.01)
        {
            Debug.Log("Circle Destoryed");
            Destroy(gameObject);
        }
        cur.x -= 0.01f;
        cur.y -= 0.01f;

        Rect.localScale = cur;

        
    }

    public void Button_Pushed()
    {
        int num = Convert.ToInt32(count.text);
        num += 1;
        count.text = num.ToString();
        Destroy(gameObject);
    }
}
