using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class EditorOptionConfig : EditorWindow
{
    [MenuItem("Tools/Option")]
    static void Init()
    {
        GetWindow(typeof(EditorOptionConfig));
        //// Get existing open window or if none, make a new one:  
        //GHEditorTool window = (GHEditorTool)GetWindow(typeof(GHEditorTool));
        //window.
    }

    Vector2 mPos = Vector2.zero;
    void OnGUI()
    {
        mPos = GUILayout.BeginScrollView(mPos);
        for (DevOptionType i = DevOptionType.StartIndex + 1; i < DevOptionType.LastIndex; i++)
        {
            GUILayout.BeginHorizontal();
            {
                bool tempBool = EditorOption.DevOption[i];

                EditorOption.DevOption[i] = GUILayout.Toggle(EditorOption.DevOption[i], i.ToString());

                if (tempBool != EditorOption.DevOption[i])
                {
                    PlayerPrefs.SetInt(string.Format("{0}_{1}", "DevOption_", i), EditorOption.DevOption[i] == true ? 1 : 0);
                    PlayerPrefs.Save();
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
    }
}