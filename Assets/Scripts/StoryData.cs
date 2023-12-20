using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class resource
{
    public int LoadType;
    public string backgroundImage;
    public string characterImage;
    public string nameContent;
    public string dialogueContent;
}
[System.Serializable]
public class StoryData:MonoBehaviour
{
    public List<resource> datas;
    public int dataIndex;

    public void Awake()
    {
        datas = new List<resource>()
        {
         new resource()
         {
             LoadType=1,backgroundImage="樱坡plus"
         },
         new resource()
         {
             LoadType=2,characterImage="加藤惠",nameContent="加藤惠",dialogueContent="你好，我是加藤惠"
         },
         new resource()
         {
             LoadType=2,characterImage="加藤惠",nameContent="加藤惠",dialogueContent="很高兴遇到你"
         },
         new resource()
         {
             LoadType=2,characterImage="加藤惠",nameContent="加藤惠",dialogueContent="让我们一起来做Galgame吧"
         },
         new resource()
         {
             LoadType=2,characterImage="加藤惠",nameContent="加藤惠",dialogueContent="请继续添加细节上的功能！"
         },
        };
        dataIndex = 0;
    }
}
