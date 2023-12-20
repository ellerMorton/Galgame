using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameSaveLoadManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = "D:/Unity2022/工程文件/Galgame Test/SavaDataPath/gameSave.json";
    }

    // 保存游戏进度
    public void SaveGame(StoryData datas)
    {
        string jsonData = JsonUtility.ToJson(datas);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("游戏进度保存成功！");
    }

    // 加载游戏进度
    public void LoadGame()
    {
        Load();
    }

    public StoryData Load()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            StoryData data = JsonUtility.FromJson<StoryData>(jsonData);
            Debug.Log("游戏进度加载成功！");
            return data;
        }
        else
        {
            Debug.Log("没有保存的游戏进度！");
            return null;
        }
    }
}
