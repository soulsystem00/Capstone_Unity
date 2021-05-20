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
        //todo: BG Localize를 사용해서 번역한다. originalStr 를 설정된 국가에 따라 번역한다.
        string localizedString = originalStr;
        return string.Format(localizedString, arg);
    }

    static string GetLocalizeString(string originalStr)
    {
        //todo: BG Localize를 사용해서 번역한다. originalStr 를 설정된 국가에 따라 번역한다.
        string localizedString = originalStr;
        return localizedString;
    }



    /// <summary>
    /// 각도를 방향으로 변환
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
    /// ToVectorFromDegreeX 와 기능 동일 에디터에서 브레이크 걸거 디버깅 할때 사용
    /// 확장 메소드는 디버깅에서 인식 안됨
    /// 그래서 확장 함수가 아닌 스태틱 함수로 추가
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
