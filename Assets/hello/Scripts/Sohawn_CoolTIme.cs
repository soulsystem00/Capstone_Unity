using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sohawn_CoolTIme : MonoBehaviour
{
    public GameObject CoolTime;
    public float s;
    private Image Image;
    private float a;

    // Start is called before the first frame update
    void Start()
    {
        Image= GetComponent<Image>();
        //CoolTime.SetActive(false);
        a = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Image>().color = new Color(Image.color.r, Image.color.g, Image.color.b, a);
        GetComponent<Image>().fillAmount = a;
        a -= Time.deltaTime/(s*2f);
        //Debug.Log(a);
        if (a <= 0f)
        {
            a = 1f;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
    }
}
