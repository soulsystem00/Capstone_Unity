using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PostprocessAllAssets : UnityEditor.AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        var files = importedAssets.Concat(deletedAssets).Concat(movedAssets).Concat(movedFromAssetPaths);

        //Resoruce폴더 경로가 변경되었다면 ResoruceDB를 업데이트 하자
        bool changedResourceFolder = false;
        foreach(var item in files)
        {
            if (item.StartsWith("Assets/Resources"))
            {
                changedResourceFolder = true;
                break;
            }
        }

        if (changedResourceFolder == false)
            return;

        //리소스 폴더 목록 생성.
        string rootResourceFolder = Application.dataPath + "/Resources";
        int rootResourceFolderLength = rootResourceFolder.Length + 1;
        string[] subDirs =  Directory.GetDirectories(rootResourceFolder, "*.*", SearchOption.AllDirectories);
        string[] dirs = new string[subDirs.Length + 1];
        subDirs.CopyTo(dirs, 0);
        dirs[dirs.Length - 1] = rootResourceFolder;
         
        Dictionary<string, string> filePaths = new Dictionary<string, string>();
        foreach (var dir in dirs)
        {
            string[] dirFiles = Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in dirFiles)
            {
                if (file.EndsWith(".meta"))
                    continue;

                string prefabKey = Path.GetFileNameWithoutExtension(file);
                string directoryName = Path.GetDirectoryName(file);
                int directoryNameLength = directoryName.Length;
                string prefabPath = prefabKey;
                if (directoryNameLength > rootResourceFolderLength)
                {
                    prefabPath = directoryName.Substring(rootResourceFolderLength) + "/" + prefabKey;
                }

                if (filePaths.ContainsKey(prefabKey))
                    Debug.LogError(prefabKey);


                filePaths.Add(prefabKey, prefabPath);
            }
        }

        //filePaths 를 txt혹은 프리팹 혹은 스크립터블 오브젝트로 저장.

        string savePath = rootResourceFolder + "/PrefabPaths.txt";
        if(File.Exists(savePath))
            File.Delete(savePath);

        using (FileStream f = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            using (StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode))
            {
                foreach (var item in filePaths)
                {
                    string str = item.Key + "?" + item.Value;
                    writer.WriteLine(str);
                }

                writer.Close();
            }
        }
    }
}