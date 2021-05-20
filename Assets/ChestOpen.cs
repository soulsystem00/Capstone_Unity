using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject closeChest;
    public GameObject openChest;
    public AudioClip audioClip;
    private void OnEnable()
    {
        audioClip = Resources.Load<AudioClip>("sound/chestopen");
        StartCoroutine(ChestOpenCo());
    }

    private void OnDisable()
    {
        
        closeChest.SetActive(true);
        openChest.SetActive(false);
    }
    IEnumerator ChestOpenCo()
    {
        
        if(GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF)
        {
            var tmp = gameObject.AddComponent<AudioSource>();
            tmp.clip = audioClip;
            tmp.Play();
        }
        yield return new WaitForSeconds(0.75f);
        closeChest.SetActive(false);
        openChest.SetActive(true);
        yield return new WaitForSeconds(2f);
        shop.instance.open_cr.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
