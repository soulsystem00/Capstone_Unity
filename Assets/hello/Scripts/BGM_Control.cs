using DevionGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Control : MonoBehaviour
{
    public AudioClip BGM_Home;
    public AudioClip BGM_shop;
    public AudioClip BGM_upgrade;
    public AudioClip BGM_heroes;
    public AudioClip BGM_skill;
    public AudioClip BGM_stageselect;

    public AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        //audioSource.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        //audioSource.clip = BGM_Home;
        //audioSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        audioSource.mute = GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF;
        audioSource.volume = 0.3f;
    }


    
    public void MusicPlay(string name)
    {
        if(!GameObject.Find("GameManager").GetComponent<GameManager>().Sound_ON_OFF)
        {
            audioSource.loop = true;
            if (name == "HomeScene")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_Home;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 1");
            }
            else if (name == "Panel_Shop")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_shop;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 2");
            }
            else if (name == "Upgrade")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_upgrade;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 3");
            }
            else if (name == "Inventory")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_heroes;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 4");
            }
            else if (name == "Skill_inventory")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_skill;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 5");
            }
            else if (name == "Panel_SelectStage")
            {
                audioSource.mute = true;
                audioSource.clip = BGM_stageselect;
                audioSource.mute = false;
                audioSource.Play();
                //Debug.Log("Music 6");
            }
        }
    }

    public void ButtonDown()
    {
        var tmp =  gameObject.AddComponent<AudioSource>();
        var tmpclip = Resources.Load<AudioClip>("sound/");
    }
}
