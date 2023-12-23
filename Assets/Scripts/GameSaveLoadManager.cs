using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Rendering;

public class GameSaveLoadManager : MonoBehaviour
{
    string fileSavePath = Application.streamingAssetsPath + "/SavePath.json";
    /// <summary>
    /// 保存游戏进度
    /// </summary>
    /// <param name="datas"></param>
    public void SaveGame(Data datas)
    {
        string json = JsonUtility.ToJson(datas, true);
        using (StreamWriter sw = new StreamWriter(fileSavePath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
        Debug.Log("游戏进度保存成功！");
    }

    /// <summary>
    /// 加载游戏进度
    /// </summary>
    public void LoadGame()
    {
        Load();
    }

    public Data Load()
    {
        string json;
        using (StreamReader sr = new StreamReader(fileSavePath))
        {
            json = sr.ReadToEnd();
            sr.Close();
        }
        Data data = JsonUtility.FromJson<Data>(json);
        Debug.Log("游戏进度加载成功！");
        return data;
    }
}
