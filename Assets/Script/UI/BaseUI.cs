using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI<T, T2> : UIComponent
    where T : MonoBehaviour
    where T2 : GHSingletonAttribute, new()
{
    // UnitySingleton 방식의 변수. ( Main급 UI마다 붙어있는 변수. Unity에서 할당해준 객체를 담아놓고 사용하는 역활. )
    static public T instance
    {
        get
        {
            if (m_instance == null)
            {
                T2 t2 = new T2();

                m_instance = Util.InstantiateUI<T>(t2.OrigianlPath, t2.LocalPosition);
            }
            if(!m_instance.gameObject.activeInHierarchy)
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


    GameObject m_gameObject;
    public GameObject CacheGameObject
    {
        get {
            if (m_gameObject == null)
                m_gameObject = gameObject;
            return m_gameObject;
        }
    }

    virtual protected void CloseFn()
    {
        if(CacheGameObject)
            CacheGameObject.SetActive(false);
    }

    void CloseCallback()
    {
        CloseFn();
    }

    private void OnEnable()
    {
        UIManager.PushUiStack(transform, CloseCallback);
    }

    private void OnDisable()
    {
        UIManager.PopUiStack(CacheGameObject.GetInstanceID());
    }
}
