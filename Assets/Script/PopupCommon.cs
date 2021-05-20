using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PopupCommonAttribute : GHSingletonAttribute
{
    public override string OrigianlPath { get { return "Canvas/PopupCommon"; } }
}
public class PopupCommon : BaseUI<PopupCommon, PopupCommonAttribute>
{
    public enum QueryType
    {
        Yes,
        No,
    }
    public delegate void ExcuteFn(QueryType quaryType);

    ExcuteFn excuteFn;
    TextMeshProUGUI message;

    private new void Awake()
    {
        base.Awake();
        message = transform.Find("Popup/Massage").GetComponent<TextMeshProUGUI>();
    }

    public void Show(ExcuteFn _excuteFn, string messageStr)
    {
        excuteFn = _excuteFn;
        message.text = messageStr;
    }

    private void ExecuteMessage(QueryType queryType)
    {
        excuteFn(queryType);
        //CacheGameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void MessageYse()
    {
        ExecuteMessage(QueryType.Yes);
    }

    public void MessageNo()
    {
        ExecuteMessage(QueryType.No);
    }


    override protected void CloseFn()
    {
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = GameObject.Find("GameManager").GetComponent<GameManager>().Gm_speed;
    }
}
