using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIComponent : MonoBehaviour
{
    public virtual void OtherSetContent()
    {
    }
    public virtual void UIMessage(UIComponent pkUIComponent)
    {
    }
    public virtual Enum GetEnumTransform()
    {
        return null;
    }

    public virtual Enum GetEnumText()
    {
        return null;
    }

    public virtual Enum GetEnumImage()
    {
        return null;
    }
    public virtual Enum GetEnumAnim()
    {
        return null;
    }
    public virtual Enum GetEnumSlider()
    {
        return null;
    }
    public virtual Enum GetEnumButton()
    {
        return null;
    }


    protected UIComponent m_pkParent;

    private Enum m_pkEnumTransform;
    public Transform[] m_pkTransforms;

    private Enum m_pkEnumText;
    public Text[] m_pkTexts;

    private Enum m_pkEnumImage;
    public Image[] m_pkImages;

    private Enum m_pkEnumAnim;
    public Animator[] m_pkAnims;

    private Enum m_pkEnumSlider;
    public Slider[] m_pkSliders;

    private Enum m_pkEnumButton;
    public Button[] m_pkButtons;

    public enum E_DEPTH
    {
        BACKGROUND_DEPTH,
        BASE_DEPTH,
        WINDOW_DEPTH,
        WINDOW_ITEM_DEPTH,
        WINDOW_POPUP_DEPTH,
        MAX_DEPTH,
    }


    [ContextMenu("SetContent")]
    public void SetContent()
    {
        m_pkEnumTransform = GetEnumTransform();
        if (m_pkEnumTransform != null)
            SetTransform();

        m_pkEnumText = GetEnumText();
        if (m_pkEnumText != null)
            SetText();

        m_pkEnumImage = GetEnumImage();
        if (m_pkEnumImage != null)
            SetImage();

        m_pkEnumAnim = GetEnumAnim();
        if (m_pkEnumAnim != null)
            SetAnim();

        m_pkEnumSlider = GetEnumSlider();
        if (m_pkEnumSlider != null)
            SetSlider();

        m_pkEnumButton = GetEnumButton();
        if (m_pkEnumButton != null)
            SetButton();

        OtherSetContent();
    }

    private void SetTransform()
    {
        Enum pkEnum = m_pkEnumTransform;

        m_pkTransforms = new Transform[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Transform[] Transforms = gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform Transform in Transforms)
            {
                if (Transform.name.Equals(str) == true)
                {
                    if (m_pkTransforms[i] != null)
                    {
                        Debug.LogError("SetTransform Error : " + str);
                    }
                    m_pkTransforms[i] = Transform;
                }
            }
            if (m_pkTransforms[i] == null)
            {
                Debug.LogError("Find not SetTransform Error : " + str);
            }
        }
    }

    private void SetText()
    {
        Enum pkEnum = m_pkEnumText;

        m_pkTexts = new Text[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Text[] Texts = gameObject.GetComponentsInChildren<Text>();
            foreach (Text Text in Texts)
            {
                if (Text.name.Equals(str) == true)
                {
                    if (m_pkTexts[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkTexts[i] = Text;
                }
            }
            if (m_pkTexts[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }

    private void SetImage()
    {
        Enum pkEnum = m_pkEnumImage;

        m_pkImages = new Image[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Image[] Images = gameObject.GetComponentsInChildren<Image>();
            foreach (Image Image in Images)
            {
                if (Image.name.Equals(str) == true)
                {
                    if (m_pkImages[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkImages[i] = Image;
                }
            }
            if (m_pkImages[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }

    private void SetAnim()
    {
        Enum pkEnum = m_pkEnumAnim;

        m_pkAnims = new Animator[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Animator[] Anims = gameObject.GetComponentsInChildren<Animator>();
            foreach (Animator Anim in Anims)
            {
                if (Anim.name.Equals(str) == true)
                {
                    if (m_pkAnims[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkAnims[i] = Anim;
                }
            }
            if (m_pkAnims[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }

    private void SetSlider()
    {
        Enum pkEnum = m_pkEnumSlider;

        m_pkSliders = new Slider[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Slider[] Sliders = gameObject.GetComponentsInChildren<Slider>();
            foreach (Slider Slider in Sliders)
            {
                if (Slider.name.Equals(str) == true)
                {
                    if (m_pkSliders[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkSliders[i] = Slider;
                }
            }
            if (m_pkSliders[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }

    private void SetButton()
    {
        Enum pkEnum = m_pkEnumButton;

        m_pkButtons = new Button[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Button[] Buttons = gameObject.GetComponentsInChildren<Button>();
            foreach (Button Button in Buttons)
            {
                if (Button.name.Equals(str) == true)
                {
                    if (m_pkButtons[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkButtons[i] = Button;
                }
            }
            if (m_pkButtons[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }
}
