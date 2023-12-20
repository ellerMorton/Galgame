using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image BGImage;
    //public Image DialogueBoxImage;
    public Image CharacterImage;
    public Text NameContent;
    public Text DialogueContent;
    public GameObject talkSence;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void SetBackGroundImage(string backgroundImage)
    {
        BGImage.sprite = Resources.Load<Sprite>("BG/" + backgroundImage);
        if (BGImage.sprite != null)
        {
            Debug.Log("背景资源加载成功！");
        }
        else
        {
            Debug.Log("背景资源加载失败！");
        }
        // DialogueBoxImage.sprite = Resources.Load<Sprite>("对话框/1");
    }

    public void SetCharacterImage(string characterImage)
    {
        talkSence.gameObject.SetActive(true);
        CharacterImage.sprite = Resources.Load<Sprite>("Character/" + characterImage);
        if (CharacterImage.sprite != null)
        {
           Debug.Log("人物资源加载成功！");
        }
        else
        {
            Debug.Log("人物资源加载失败！");
        }
        CharacterImage.gameObject.SetActive(true);
    }

    public void UpdateNameContent(string nameContent)
    {
        NameContent.text = nameContent;
    }

    public void UpdateDialogueContent(string dialogueContent)
    {
        DialogueContent.text = dialogueContent;
    }
}
