using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

class ExtendClass
{ }

class MyColor
{
    public static Color InventoryGray = new Color(0.1333333f, 0.145098f, 0.1529412f);
}

class Util
{
    private SpriteAtlas mySpriteAtlas;
    public Sprite SpriteReturn(string spriteName)
    {
        return mySpriteAtlas.GetSprite(spriteName);
    }

    /// <summary>
    /// 중복없는 랜덤 int값
    /// </summary>
    /// <param name="spriteName"></param>
    /// <returns></returns>
    public static int[] RandomIntOverlapNone(int length, int min, int max)
    {
        int[] randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; i++)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; j++)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }

    enum CostType
    {
        Gold,
        Dia,
        SpecialMedal,
    }

    /// <summary>
    ///  maxValue 의 percent%는 얼마?
    /// </summary>
    public static float PercentReturn1(float maxValue, float percent)
    {
        return maxValue * percent / 100;
    }

    /// <summary>
    /// value 는 maxValue 몇%?
    /// </summary>
    public static float PercentReturn2(float value, float maxValue)
    {
        return value / maxValue * 100;
    }


    public static bool IsPointerOverUI()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Clicked on the UI");
            return true;

        }
        return false;

    }


    public static T InstantiateUI<T>(string origianlPath, Vector3? localPosition) where T : Component
    {
        string parentGoName;
        int firstSlashIndex = origianlPath.IndexOf('/');
        if (firstSlashIndex == -1)
            parentGoName = origianlPath;
        else
            parentGoName = origianlPath.Substring(0, firstSlashIndex);

        string originalChildPath = origianlPath.Substring(firstSlashIndex + 1, origianlPath.Length - firstSlashIndex - 1);

        GameObject rootGameObject = GameObject.Find(parentGoName);
        string prefabName;

        Transform tr = rootGameObject ? rootGameObject.transform.Find(originalChildPath) : null;
        if (tr == null)
        {
            //originalChildPath에서 끝을 잘라서 prefabName 에 넣자 -> PrefabName을 넣을 필요가 없다...!!!!
            int lastSlashIndex = origianlPath.LastIndexOf('/');
            if (lastSlashIndex == -1)
            {
                prefabName = origianlPath;
            }
            else
            {
                prefabName = origianlPath.Substring(lastSlashIndex + 1, origianlPath.Length - lastSlashIndex - 1);
                origianlPath = origianlPath.Substring(0, lastSlashIndex);

                int index = originalChildPath.LastIndexOf('/');
                if (index > 0)
                    originalChildPath = originalChildPath.Substring(0, index);
            }
        }
        else
        {
            return (T)tr.GetComponent(typeof(T));
        }

        GameObject go = null;

        //
        string prefabPath = GetPrefabPaths(prefabName);

        Object prefab = Resources.Load(prefabPath);
        if (prefab != null)
        {
            go = (GameObject)(GameObject.Instantiate(prefab));
            go.name = prefabName;
        }
        else
        {
            go = new GameObject(prefabName, typeof(T));
        }

        if (go == null)
        {
            Debug.LogError(string.Format("prefabName == null, origianlPath:{0}, prefabName:{1}", origianlPath, prefabName));
        }

        if (rootGameObject)
        {
            Transform childTr = rootGameObject.transform.Find(originalChildPath);
            if(childTr)
                go.transform.SetParent(childTr);
            else
                go.transform.SetParent(rootGameObject.transform);

            go.transform.localScale = Vector3.one;
        }

        var rt = go.GetComponent<RectTransform>();

        if (rt)
        {
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }

        if (localPosition == null)
        {
            if (rt)
            {
                rt.anchoredPosition = Vector3.zero;
            }
            else
                go.transform.position = Vector3.zero;
        }
        else
        {
            if (rt)
                rt.localPosition = localPosition.Value;
        }

        return (T)go.GetComponent(typeof(T));
    }

    static public string PrefabFilePath
    {
        get
        {
            return "PrefabPaths";
        }
    }

    static Dictionary<string, string> prefabPaths = null;
    static Dictionary<string, string> PrefabPaths
    {
        get
        {
            if (prefabPaths == null)
            {

                TextAsset data = Resources.Load(PrefabFilePath, typeof(TextAsset)) as TextAsset;
                StringReader sr = new StringReader(data.text);
                prefabPaths = new Dictionary<string, string>();

                // 먼저 한줄을 읽는다. 
                string source = sr.ReadLine();
                string[] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )

                while (source != null)
                {
                    values = source.Split('?');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
                    if (values.Length == 0)
                    {
                        sr.Close();
                        break;
                    }
                    // 
                    prefabPaths.Add(values[0], values[1]);

                    source = sr.ReadLine();    // 한줄 읽는다.
                }
            }
            return prefabPaths;
        }
    }
    private static string GetPrefabPaths(string prefabName)
    {
        if (PrefabPaths.ContainsKey(prefabName))
            return PrefabPaths[prefabName];

        return prefabName;
    }

    public static void InitCache()
    {
        foreach (var item in PrefabPaths)
        {
            Object loadObject = Resources.Load(item.Value);
            if (loadObject.GetType() == typeof(GameObject))
            {
                prefabCache[item.Value] = (GameObject)loadObject;
            }
        }
    }

    static public Dictionary<string, GameObject> prefabCache = new Dictionary<string, GameObject>();

    internal static T GetLoadedGameObject<T>(string prefabPath)
    {
        GameObject go = GetLoadedGameObject(prefabPath);
        return go.GetComponent<T>();
    }

    internal static GameObject GetLoadedGameObject(string prefabPath)
    {
        if (prefabCache.ContainsKey(prefabPath) == false)
            prefabCache[prefabPath] = (GameObject)Resources.Load(prefabPath);

        return prefabCache[prefabPath];
    }

    internal static GameObject Instantiate(string prefabPath, Transform parent)
    {
        GameObject _object = GetLoadedGameObject(prefabPath);
        GameObject newGo = Object.Instantiate(_object, parent);

        InitObject(_object, newGo);
        return newGo;
    }
    internal static GameObject Instantiate(string prefabPath, Vector3 position, Quaternion rotation)
    {
        GameObject _object = GetLoadedGameObject(prefabPath);
        GameObject newGo = Object.Instantiate(_object, position, rotation);

        InitObject(_object, newGo);
        return newGo;
    }

    internal static GameObject Instantiate(Object _object, Transform parent)
    {
        GameObject t = GetLoadedGameObject(_object.name);
        GameObject newGo = Object.Instantiate(t, parent);

        InitObject(_object, newGo);
        return newGo;
    }

    internal static GameObject Instantiate(string prefabPath)
    {
        GameObject prefab = GetLoadedGameObject(prefabPath);

        return Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    static void InitObject(UnityEngine.Object original, UnityEngine.Object newCompont)
    {
        newCompont.name = original.name;
    }

    internal static GameObject Instantiate(GameObject prefab)
    {
        return Util.Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    internal static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newGo = UnityEngine.Object.Instantiate(prefab, position, rotation);

        InitObject(prefab, newGo);
        return newGo;
    }


    internal static T Instantiate<T>(T prefab) where T : Component
    {
        return Instantiate<T>(prefab, Vector3.zero, Quaternion.identity);
    }
    internal static T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
    {
        T newGo = UnityEngine.Object.Instantiate<T>(prefab, position, rotation);

        InitObject(prefab, newGo);
        return newGo;
    }
}