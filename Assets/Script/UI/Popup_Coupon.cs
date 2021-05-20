using System;
using UnityEngine;
using System.Collections; 

public class Popup_Coupon : UIComponent
{
    public enum E_TRANSFORM
    {
    }
    public enum E_TEXT
    {
    }
    public enum E_IMAGE
    {
    }
    public enum E_ANIM
    {
    }
    public enum E_SLIDER
    {
    }
    public enum E_BUTTON
    {
    }
    public override Enum GetEnumTransform() { return new E_TRANSFORM(); }
    public override Enum GetEnumText() { return new E_TEXT(); }
    public override Enum GetEnumImage() { return new E_IMAGE(); }
    public override Enum GetEnumAnim() { return new E_ANIM(); }
    public override Enum GetEnumSlider() { return new E_SLIDER(); }
    public override Enum GetEnumButton() { return new E_BUTTON(); }
    public override void OtherSetContent()
    {

    }

    void Start()
    {
        //m_pkTexts[(int)E_TEXT.test].text = "잘되나";
    }

    public void Awake()
    {

    }

    public void Clear()
    {

    }

    public void Confirm()
    {
        //PlayReverse();

        //string strCouponNum = m_pkLabels[(int)E_LABEL.Coupon_Input_Label].text;
        //PacketSend kSend = Net.GetInstance().GetPacketSend((ushort)Client_Header.CLIENT_PROTOCOL.CM_QRY_USE_COUPON);

        //long patiUID = PublishProxyManager.Get().GetUID();
        //kSend.Add(ref strCouponNum );
        //SINGLETON.DEF_NET().SendPacket(kSend);

        //m_pkLabels[(int)E_LABEL.Coupon_Input_Label].text = "";
        //m_pkLabels[(int)E_LABEL.Coupon_Input_Label].transform.parent.gameObject.GetComponent<UIInput>().value = "";


        //m_pkTexts[(int)E_TEXT.test].text = "잘되나";
        
    }
}
