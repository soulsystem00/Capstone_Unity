using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage_Multi_load : MonoBehaviour
{
    public TextMeshProUGUI mmr;
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mmr.text = GameObject.Find("GameManager").GetComponent<GameManager>().MMR.ToString();
    }
}
