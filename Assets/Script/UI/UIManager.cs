using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerAttribute : GHSingletonAttribute
{
    public override string OrigianlPath { get { return "UIManager"; } }
}

/// <summary>
/// esc누르면 UI닫는다
/// </summary>
public class UIManager : GHSingleton<UIManager, UIManagerAttribute>
{
    public Transform canvas;
    new private void Awake()
    {
        base.Awake();
        canvas = GameObject.Find("Canvas").transform;
    }
    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    public class UICloserStack
    {
        internal List<UICloser> previousHistory = new List<UICloser>();

        public void Push(UICloser newHistory)
        {
            previousHistory.Add(newHistory);
        }
        public bool Pop()
        {
            bool succeedCloseUI = false;
            while (succeedCloseUI == false && previousHistory.Count > 0)
            {
                int excuteIndex = previousHistory.Count - 1;
                UICloser uICloser = previousHistory[excuteIndex];
                succeedCloseUI = uICloser.CloseUI();
                if (succeedCloseUI == false)
                    previousHistory.RemoveAt(excuteIndex);
            }
            return succeedCloseUI;
        }
        public void Remove(int instanceID)
        {
            previousHistory.Remove(previousHistory.Find(p => p.instanceID == instanceID));
        }

        public int Count
        {
            get { return previousHistory.Count; }
        }
    }

    public void OnSceneLoad()
    {
    }

    public class UICloser
    {
        public UICloser(Transform _tr, Action ac)
        {
            this.tr = _tr;
            this.instanceID = _tr.gameObject.GetInstanceID();
            this.closeFn = ac;
        }

        public int instanceID;
        public Transform tr;
        public Action closeFn;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>창닫은게 있으면 true, 없으면 false</returns>
        public bool CloseUI()
        {
            //if (closeFn != null)
            //    return closeFn();

            if (tr != null && tr.gameObject.activeInHierarchy == true)
            {
                if (closeFn != null)
                {
                    closeFn();
                }
                else
                {
                    tr.gameObject.SetActive(false);
                }
                return true;
            }

            return false;
        }
    }

    static UICloserStack uICloserStack = new UICloserStack();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MoveBack();     //Escape 키를 눌렀을때.
        }
    }

    internal static void PushUiStack(Transform tr, Action ac = null)
    {
        UICloser uICloser = new UICloser(tr, ac);
        uICloserStack.Push(uICloser);
    }

    static public Action<int> OnExecutePopUiStackCallBack;
    internal static void PopUiStack(int instanceID)
    {
        uICloserStack.Remove(instanceID);

        if (OnExecutePopUiStackCallBack != null)
            OnExecutePopUiStackCallBack(uICloserStack.Count);
    }

    /// <summary>
    /// 여기에 가능하면 로직 추가하지 말고 UI에 esc누르면 특정 행동하도록 함수를 설정해주세요.
    /// </summary>
    public void MoveBack()
    {
        // UI닫기
        if (uICloserStack.Count > 0)
        {
            //창닫기 명령 실행.
            if (uICloserStack.Pop())   //닫은창이 있으면 true;
                return;
        }

#if UNITY_EDITOR
        //뒤로갈께 없으니 게임을 종료할것인지 묻자.
        if(SceneManager.GetActiveScene().name == "game")
        {
            PopupCommon.instance.Show(QuitGameFail, "게임을 포기하시겠습니까?");
        }
        else
        {
            PopupCommon.instance.Show(QuitMessage, "게임을 종료하시겠습니까?");
        }

        Debug.Log("뒤로갈께 없으니 게임을 종료할것인지 물어보자. Android");
#endif

        //QuestionQuitGameAndroid();
        if (SceneManager.GetActiveScene().name == "game")
        {
            PopupCommon.instance.Show(QuitGameFail, "게임을 포기하시겠습니까?");
        }
        else
        {
            PopupCommon.instance.Show(QuitMessage, "게임을 종료하시겠습니까?");
        }
    }

    void QuitMessage(PopupCommon.QueryType result)
    {
        switch (result)
        {
            case PopupCommon.QueryType.Yes:
                Application.Quit();
                break;
            case PopupCommon.QueryType.No:
                //gameObject.SetActive(false);
                break;
        }
    }

    void QuitGameFail(PopupCommon.QueryType result)
    {
        switch (result)
        {
            case PopupCommon.QueryType.Yes:
                SceneManager.LoadScene("main");
                break;
            case PopupCommon.QueryType.No:
                //gameObject.SetActive(false);
                break;
        }
    }
}
