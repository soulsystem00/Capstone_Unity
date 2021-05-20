using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class GHSingletonAttribute
{
    public virtual string OrigianlPath
    {
        get { return string.Empty; }
    }
    public virtual Vector3? LocalPosition
    {
        get { return null; }
    }
}

/// <summary>
/// 상속받는 클래스는 Awake와 OnDestroy를 재구현 한다면 부모의 Awake와 OnDestroy를 불르거나 참고해야함. 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="T2"></typeparam>
/// 

public abstract class GHSingleton<T, T2> : UIComponent
    where T : MonoBehaviour
    where T2 : GHSingletonAttribute, new()
{
    // UnitySingleton 방식의 변수. ( 가디언헌터에서 Main급 UI마다 붙어있는 변수. Unity에서 할당해준 객체를 담아놓고 사용하는 역활. )
    static public T instance
    {
        get
        {
            if (m_instance == null)
            {
                T2 t2 = new T2();
                m_instance = Util.InstantiateUI<T>(t2.OrigianlPath, t2.LocalPosition);
                DontDestroyOnLoad(m_instance.gameObject.transform.root);
            }
            if (!m_instance.gameObject.activeInHierarchy)
            {
                m_instance.gameObject.SetActive(true);
            }
            return m_instance;
        }
        set
        {
#if UNITY_EDITOR
            if (m_instance != null && value != null)
                Debug.LogError("m_instance != null && value != null");
#endif
            m_instance = value;
        }
    }
    static protected T m_instance;

    static public bool IsInitInstance
    {
        get { return m_instance != null; }
    }

    //instance로 처음 접근한게 아니라Awake로 켜진것이라면 인스턴스를 초기화 한다. 
    protected void Awake()
    {
        m_instance = this as T;
    }

    protected void OnDestroy()
    {
        m_instance = null;
    }

    static public bool IsActive
    {
        get
        {
            return IsInitInstance && instance.gameObject.activeInHierarchy == true;
        }
    }
}
