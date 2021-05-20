using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class EditorEssential
{ 
     #region 에디터 시작Ctrl+E/정지 단축키Ctrl+Q
    [MenuItem("Util/Start %e", false, -99)]
    static void StartPlay()
    {
        UnityEditor.EditorApplication.isPlaying = true;
    }

    [MenuItem("Util/Stop %q", false, -99)]
    static void StopPlay()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }


    #endregion //에디터 시작Ctrl+E/정지 단축키Ctrl+Q
    private static string GetSelectedObjectPaths()
    {
        List<string> selectedObjectPaths = new List<string>(Selection.objects.Length);

        string projectPath = Application.dataPath.Replace("Assets", string.Empty);

        foreach (Object obj in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            selectedObjectPaths.Add(path);
        }
        string pathsString = string.Empty;

        for (int i = 0; i < selectedObjectPaths.Count; i++)
        {
            string item = selectedObjectPaths[i];
            if (i == 0)
            {
                pathsString = string.Format("{1}{0}", item, projectPath);
            }
            else
            {
                pathsString = string.Format("{0} {2}{1}", pathsString, item, projectPath);
            }
        }
        return pathsString;
    }

    class SpriteInfo
    {
        public Sprite sprite;
        public int seq;

        public SpriteInfo(Sprite item, int seq)
        {
            this.sprite = item;
            this.seq = seq;
        }
    }
    class MakeAniInfo
    {
        public string groupName;
        public List<SpriteInfo> sprites = new List<SpriteInfo>();
        public string animationFilePath;
    }
   
    [MenuItem("Assets/Tool/Make Animation", false, 1)]
    public static void SvnLogSelected()
    {
        List<Sprite> sprites = new List<Sprite>(Selection.objects.Length);
        foreach (var item in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(item.GetInstanceID());
            

            if (Directory.Exists(path))
            {
                Debug.Log("Folder");
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    if (file.EndsWith(".meta"))
                        continue;

                    Sprite sprite1 = AssetDatabase.LoadAssetAtPath<Sprite>(file);
                    if (sprite1 == null)
                        continue;

                    sprites.Add(sprite1);
                }
                continue;
            }
            else
            {
                Debug.Log("File");
            }

            Texture2D texture = (Texture2D)item;
            if (texture == null)
                continue;
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GetAssetPath(texture));
            if (sprite == null)
                continue;

            sprites.Add(sprite);
        }
        // 폴더 선택했는지, 파일 선택했는지
        // 그룹으로 나누기 -> 네이밍 정해져 있어야함. ex)숫자로 구분, _언더바로 구분
        // 애니메이션 만들어질 경로 ( 애니메이션 파일 이름 포함)

        // 이미지들 만들때 사용하는 재료

        // 그룹 나누기
        Dictionary<string, MakeAniInfo> aniInfo = new Dictionary<string, MakeAniInfo>();  // <그룹이름, 애니메이션 정보>
        foreach(var item in sprites)
        {
            string assetFullPath = AssetDatabase.GetAssetPath(item);

            string filename = Path.GetFileNameWithoutExtension(assetFullPath);

            int seq = -1;
            // filename 에서 언더바로 구분하거나, 숫자로 구분해야함.
            string groupName;
            if (filename.IndexOf("_") > 0)
            {
                // _ 가 있음.
                string[] tempStr = filename.Split('_');
                groupName = tempStr[0];
                seq = int.Parse(tempStr[1]);
            }
            else
            {
                // 숫자로 구분.
                int firstNumberIndex = filename.IndexOfAny("0123456789".ToCharArray());

                groupName = filename.Substring(0, firstNumberIndex);

                string number = filename.Substring(firstNumberIndex, filename.Length - firstNumberIndex);


                bool result = int.TryParse(number, out int i); //i now = 108  
                if (result == false)
                    continue;

                seq = i;
            }


            //assetFullPath  //파일 이름 // 폴더 
            // 폴더에는 Sprite 가 포함되어 있는위치 뽑고
            if (aniInfo.ContainsKey(groupName) == false)
            {
                aniInfo[groupName] = new MakeAniInfo();
                aniInfo[groupName].groupName = groupName;

                string[] paths = assetFullPath.Split(new String[] { "Sprite" }, StringSplitOptions.None);
                string animationFolderPath = paths[0];

                aniInfo[groupName].animationFilePath = animationFolderPath + groupName + ".anim";
            }
            aniInfo[groupName].sprites.Add(new SpriteInfo(item, seq));
        }

        // aniInfo seq  대로 정렬.
        foreach (var item in aniInfo)
        {
            item.Value.sprites.Sort(
            delegate (SpriteInfo p1, SpriteInfo p2)
            {
                return (p1.seq.CompareTo(p2.seq));
            });
        }

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";

        // 애니메이션 만들기
        foreach (var item in aniInfo)
        {
            var makeInfo = item.Value;
            var spriteInfo = makeInfo.sprites;
            ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[spriteInfo.Count];
            for (int i = 0; i < (spriteInfo.Count); i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                spriteKeyFrames[i].time = i;
                spriteKeyFrames[i].value = spriteInfo[i].sprite;
            }

            AnimationClip animClip = new AnimationClip();
            animClip.frameRate = 30;   // FPS
            AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);

            AssetDatabase.CreateAsset(animClip, makeInfo.animationFilePath);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/2 Copy Transform Path")]
    static void CopyTransformPath()
    {

        List<Transform> selectItems = new List<Transform>();
        selectItems.AddRange(Selection.transforms);
        selectItems.Sort(
            delegate (Transform p1, Transform p2)
            {
                return (p1.name.CompareTo(p2.name)) * -1;
            });


        StringBuilder sb = new StringBuilder();
        foreach (Transform t in selectItems)
        {
            string originalName = t.name;
            string componentPath = t.name;
            Transform tParent = t.parent;
            while (tParent.parent != null) // 루트는 의도적으로 담지 않았음.
            {
                componentPath = string.Format("{0}/{1}", tParent.name, componentPath);
                tParent = tParent.parent;
            }

            sb.AppendLine("\"" + componentPath + "\"");
        }

        clipboard = sb.ToString().Trim();
    }


    [MenuItem("Tools/1 Copy Component Path")]
    static void CopyComponentPath()
    {
        StringBuilder sb2 = new StringBuilder();

        List<System.Type> findTypes = new List<System.Type>();
        findTypes.Add(typeof(Text));
        findTypes.Add(typeof(TextMesh));
        findTypes.Add(typeof(Image));

        List<Transform> selectItems = new List<Transform>();// ;
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            selectItems.Add(Selection.gameObjects[i].transform);
        }

        selectItems.Sort(
            delegate (Transform p1, Transform p2)
            {
                return (p1.name.CompareTo(p2.name)) * -1;
            });

        //부모도 선택되어 있으면 부모는 선택 목록에서 제외 한다.
        Transform parent = null;
        foreach (Transform t in selectItems)
        {
            Component[] m = t.GetComponents<Component>();
            bool containComponent = false;
            for (int i = 0; i < m.Length; i++)
            {
                System.Type itType = m[i].GetType();
                if (findTypes.Contains(itType))
                {
                    containComponent = true;
                    break;
                }
            }

            if (containComponent == false)
            {
                bool isParent = false;
                foreach (var item in selectItems)
                {
                    if (item == t)
                        continue;

                    var trs = item.GetComponentsInParent<Transform>();
                    foreach (var tr in trs)
                    {
                        if (tr == t)
                        {
                            parent = t;
                            isParent = true;
                            break;
                        }
                    }

                    if (isParent)
                        break;
                }
            }
        }

        selectItems.Remove(parent);

        StringBuilder sb1 = new StringBuilder();
        foreach (Transform t in selectItems)
        {
            string originalName = t.name;
            string componentPath = t.name;
            Transform tParent = t.parent;
            while (true)
            {
                if (tParent.parent == null || tParent == parent)
                    break;
                componentPath = string.Format("{0}/{1}", tParent.name, componentPath);
                tParent = tParent.parent;
            }

            Component[] m = t.GetComponents<Component>();

            for (int i = 0; i < m.Length; i++)
            {
                System.Type itType = m[i].GetType();
                if (findTypes.Contains(itType))
                {
                    string smallCharacterName = string.Format("{0}{1}", originalName[0].ToString().ToLower(), originalName.Substring(1));


                    string typeString = itType.ToString();
                    typeString = typeString.Replace("UnityEngine.UI.", "");
                    typeString = typeString.Replace("UnityEngine", "");

                    sb1.AppendFormat("{0} {1};\n", typeString, smallCharacterName);
                    sb2.AppendFormat("{2} = transform.Find(\"{0}\").GetComponent<{1}>();\n", componentPath, typeString, smallCharacterName);
                }
            }
        }

        sb1.AppendLine();

        clipboard = sb1.ToString() + sb2.ToString().Trim();
    }

    static void SaveTextureToFile(Texture2D texture, TextureImporter textureImporter, string fileName)
    {
        try
        {
            string directoryPath = Path.GetPathRoot(fileName);
            string fileNameWithoutExtionsion = Path.GetFileNameWithoutExtension(fileName);
            for (int i = 0; i < textureImporter.spritesheet.Length; i++)
            {
                var sprite = textureImporter.spritesheet[i];

                Texture2D newTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                Color[] newColors = texture.GetPixels((int)sprite.rect.x,
                                                                (int)sprite.rect.y,
                                                                (int)sprite.rect.width,
                                                                (int)sprite.rect.height);

                newTexture.SetPixels(newColors);
                newTexture.Apply();


                var bytes = newTexture.EncodeToPNG();
                string savePath = Application.dataPath + "/" + fileNameWithoutExtionsion + "_" + (i + 1) + ".png";
                var file = File.Open(savePath, FileMode.Create);
                var binary = new BinaryWriter(file);
                binary.Write(bytes);
                file.Close();
            }

            AssetDatabase.Refresh();
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(string.Format("{0} {1}", fileName, ex));
        }
    }

    [MenuItem("Window/1 메인씬 Open", false, -100 + 3)]
    static public void SceneOpen1()
    {
        OpenSceneByName("main");
    }
    [MenuItem("Window/2 게임 Open", false, -100 + 3)]
    static public void SceneOpen2()
    {
        OpenSceneByName("game");
    }

    private static void OpenSceneByName(string sceneName)
    {
        string sceneFolderPath = string.Format("Assets/Scenes/{0}.unity",sceneName);
        if (File.Exists(sceneFolderPath))
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(sceneFolderPath);
    }



    //[MenuItem("Tools/1 CopyPath")]
    //static void MakeVariableSelectionTransform()
    //{

    //    List<Transform> selectItems = new List<Transform>();
    //    selectItems.AddRange(Selection.transforms);
    //    selectItems.Sort(
    //        delegate (Transform p1, Transform p2)
    //        {
    //            return (p1.name.CompareTo(p2.name)) * -1;
    //        });


    //    StringBuilder sb = new StringBuilder();
    //    foreach (Transform t in selectItems)
    //    {
    //        string originalName = t.name;
    //        string componentPath = t.name;
    //        Transform tParent = t.parent;
    //        while (tParent.parent != null) // 루트는 의도적으로 담지 않았음.
    //        {
    //            componentPath = string.Format("{0}/{1}", tParent.name, componentPath);
    //            tParent = tParent.parent;
    //        }

    //        sb.AppendLine("\"" + componentPath + "\"");
    //    }

    //    clipboard = sb.ToString().Trim();
    //}

    public static string clipboard
    {
        get
        {
            TextEditor te = new TextEditor();
            te.Paste();
            return te.text;
        }
        set
        {
            TextEditor te = new TextEditor();
            te.text = value;
            te.OnFocus();
            te.Copy();
        }
    }
}
