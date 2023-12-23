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
    /// ������Ϸ����
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
        Debug.Log("��Ϸ���ȱ���ɹ���");
    }

    /// <summary>
    /// ������Ϸ����
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
        Debug.Log("��Ϸ���ȼ��سɹ���");
        return data;
    }
}
