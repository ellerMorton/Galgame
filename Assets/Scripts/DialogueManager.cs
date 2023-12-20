using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("文本相关")]
    public TextAsset dialogueDataFile;
    public int dialogueIndex;
    public string[] dialogueRows;
    public List<Sprite> sprites = new List<Sprite>();
    public Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    [Header("组件")]
    public Image leftImage;
    public Image midImage;
    public Image rightImage;
    public Text nameText;
    public Text dialogText;
    [Header("交互")]
    public Button nextBtn;


    public void Awake()
    {
        imageDic["加藤惠"] = sprites[0];
        imageDic["安艺伦也"] = sprites[1];
    }
    public void Start()
    {
        ReadText(dialogueDataFile);
        ShowDialogRow();
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    /// <summary>
    /// 更新角色图片
    /// </summary>
    /// <param name="_name"></param>
    /// <param name="_position"></param>
    public void UpdateImage(string _name, string _position)
    {
        leftImage.enabled = false;
        midImage.enabled = false;
        rightImage.enabled = false;
        if (_position == "左")
        {
            leftImage.enabled = true;
            leftImage.sprite = imageDic[_name];
        }
        else if (_position == "中")
        {
            midImage.enabled = true;
            midImage.sprite = imageDic[_name];
        }
        else if (_position == "右")
        {
            rightImage.enabled = true;
            rightImage.sprite = imageDic[_name];
        }
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogueRows = _textAsset.text.Split('\n');
    }

    public void ClickToNext()
    {
        ShowDialogRow();
    }

    /// <summary>
    /// 显示对话行
    /// 调用更新内容的函数
    /// </summary>
    public void ShowDialogRow()
    {
        foreach (var row in dialogueRows)
        {
            string[] cells = row.Split(',');
            if (cells[0] == "剧情" && int.Parse(cells[1]) == dialogueIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);
                dialogueIndex = int.Parse(cells[5]);
                break;
            }
            else if (cells[0] == "分支" && int.Parse(cells[1]) == dialogueIndex)
            {
               
            }
        }
    }
}
