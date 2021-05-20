using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class VersionInfo : MonoBehaviour
{
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        txt.text = "Version Info : " + PlayerSettings.bundleVersion.ToString();
#elif UNITY_ANDROID
        txt.text = "Version Info : " + Application.version.ToString();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
