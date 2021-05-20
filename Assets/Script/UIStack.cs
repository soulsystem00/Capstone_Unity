using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackAttribute : GHSingletonAttribute
{
    public override string OrigianlPath { get { return "UIStack"; } }
}

public class UIStack : BaseUI<UIStack, UIStackAttribute>
{
    public enum UiType
    {
        None,
        Option,
    }

    public UiType uiType;

    public void DestroyUI()
    {
        CloseFn();
    }

    protected override void CloseFn()
    {
        if (uiType == UiType.Option)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
