using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MyExtension {

    public static T AddOrGetComponent<T>(this Transform tr) where T : Component
    {
        T t = tr.GetComponent<T>();
        if (t == null)
            t = tr.gameObject.AddComponent<T>();

        return t;
    }

    public static T AddOrGetComponent<T>(this GameObject tr) where T : Component
    {
        T t = tr.GetComponent<T>();
        if (t == null)
            t = tr.AddComponent<T>();

        return t;
    }

    // 1,000.1
    public static string ToNumber1(this float value)
    {
        return string.Format("{0:n1}", value);
    }

    // 1,000
    public static string ToNumber0(this float value)
    {
        return string.Format("{0:n0}", value);
    }
    public static string ToNumber0(this int value)
    {
        return string.Format("{0:n0}", value);
    }

    public static string Localize(this string originalStr, params System.Object[] arg)
    {
        return GetLocalizeString(originalStr, arg);
    }

    public static string Localize(this string originalStr)
    {
        return GetLocalizeString(originalStr);
    }


    // GetLocalizeString
    static string GetLocalizeString(string originalStr, params System.Object[] arg)
    {
        //todo: BG Localize�� ����ؼ� �����Ѵ�. originalStr �� ������ ������ ���� �����Ѵ�.
        string localizedString = originalStr;
        return string.Format(localizedString, arg);
    }

    static string GetLocalizeString(string originalStr)
    {
        //todo: BG Localize�� ����ؼ� �����Ѵ�. originalStr �� ������ ������ ���� �����Ѵ�.
        string localizedString = originalStr;
        return localizedString;
    }



    /// <summary>
    /// ������ �������� ��ȯ
    /// </summary>
    /// <param name="degree"></param>
    /// <returns></returns>
    public static Vector3 ToVectorFromDegreeX(this float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(0, Mathf.Sin(radian), Mathf.Cos(radian));
    }
    public static Vector3 ToVectorFromDegreeY(this float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
    public static Vector3 ToVectorFromDegreeZ(this float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
    }


    /// <summary>
    /// ToVectorFromDegreeX �� ��� ���� �����Ϳ��� �극��ũ �ɰ� ����� �Ҷ� ���
    /// Ȯ�� �޼ҵ�� ����뿡�� �ν� �ȵ�
    /// �׷��� Ȯ�� �Լ��� �ƴ� ����ƽ �Լ��� �߰�
    /// </summary>
    /// <param name="degree"></param>
    /// <returns></returns>
    /// 
    public static Vector3 ToVectorFromDegreeXDebug(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(0, Mathf.Sin(radian), Mathf.Cos(radian));
    }
    public static Vector3 ToVectorFromDegreeYDebug(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
    public static Vector3 ToVectorFromDegreeZDebug(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
    }
}
