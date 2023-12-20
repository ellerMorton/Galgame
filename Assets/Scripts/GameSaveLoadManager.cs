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
        savePath = "D:/Unity2022/�����ļ�/Galgame Test/SavaDataPath/gameSave.json";
    }

    // ������Ϸ����
    public void SaveGame(StoryData datas)
    {
        string jsonData = JsonUtility.ToJson(datas);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("��Ϸ���ȱ���ɹ���");
    }

    // ������Ϸ����
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
            Debug.Log("��Ϸ���ȼ��سɹ���");
            return data;
        }
        else
        {
            Debug.Log("û�б������Ϸ���ȣ�");
            return null;
        }
    }
}
