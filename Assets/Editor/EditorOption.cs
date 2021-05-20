using System.Collections.Generic;
using UnityEngine;

public enum DevOptionType
{
    StartIndex = -1,
    PlayerAttack,
    SetNearMon,
    Dash,
    LastIndex
}
public class EditorOption
{
    static public Dictionary<DevOptionType, bool> DevOption
    {
        get
        {
            if (m_DevOption == null)
                InitDevOptionValue();
            return m_DevOption;
        }
    }

    static Dictionary<DevOptionType, bool> m_DevOption;
    static public void InitDevOptionValue()
    {
        if (m_DevOption == null)
            m_DevOption = new Dictionary<DevOptionType, bool>();

        for (DevOptionType i = DevOptionType.StartIndex + 1; i < DevOptionType.LastIndex; i++)
        {
#if UNITY_EDITOR
            string key = "DevOption_" + i;
            m_DevOption[i] = PlayerPrefs.GetInt(key, 0) == 0 ? false : true;
#else
        m_DevOption[i] = false;
#endif
        }
    }
}
