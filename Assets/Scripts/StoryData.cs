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
             LoadType=1,backgroundImage="ӣ��plus"
         },
         new resource()
         {
             LoadType=2,characterImage="���ٻ�",nameContent="���ٻ�",dialogueContent="��ã����Ǽ��ٻ�"
         },
         new resource()
         {
             LoadType=2,characterImage="���ٻ�",nameContent="���ٻ�",dialogueContent="�ܸ���������"
         },
         new resource()
         {
             LoadType=2,characterImage="���ٻ�",nameContent="���ٻ�",dialogueContent="������һ������Galgame��"
         },
         new resource()
         {
             LoadType=2,characterImage="���ٻ�",nameContent="���ٻ�",dialogueContent="��������ϸ���ϵĹ��ܣ�"
         },
        };
        dataIndex = 0;
    }
}
