using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("�ı����")]
    public TextAsset dialogueDataFile;
    public int dialogueIndex;
    public string[] dialogueRows;
    public List<Sprite> sprites = new List<Sprite>();
    public Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    [Header("���")]
    public Image leftImage;
    public Image midImage;
    public Image rightImage;
    public Text nameText;
    public Text dialogText;
    [Header("����")]
    public Button nextBtn;
    public GameObject optionBtn;
    public Transform optionBtnGroup;


    public void Awake()
    {
        imageDic["���ٻ�"] = sprites[0];
        imageDic["������Ҳ"] = sprites[1];
    }
    public void Start()
    {
        ReadText(dialogueDataFile);
        ShowDialogueRow();
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    /// <summary>
    /// ���½�ɫͼƬ
    /// </summary>
    /// <param name="_name"></param>
    /// <param name="_position"></param>
    public void UpdateImage(string _name, string _position)
    {
        leftImage.enabled = false;
        midImage.enabled = false;
        rightImage.enabled = false;
        if (_position == "��")
        {
            leftImage.enabled = true;
            leftImage.sprite = imageDic[_name];
        }
        else if (_position == "��")
        {
            midImage.enabled = true;
            midImage.sprite = imageDic[_name];
        }
        else if (_position == "��")
        {
            rightImage.enabled = true;
            rightImage.sprite = imageDic[_name];
        }
    }

    /// <summary>
    /// ���¶Ի���
    /// </summary>
    /// <param name="_textAsset"></param>
    public void ReadText(TextAsset _textAsset)
    {
        dialogueRows = _textAsset.text.Split('\n');
    }

    /// <summary>
    /// ��ʾ�Ի���
    /// ���ø������ݵĺ���
    /// </summary>
    public void ShowDialogueRow()
    {
        for (int i = 0; i < dialogueRows.Length; i++)
        {
            string[] cells = dialogueRows[i].Split(',');
            if (cells[0] == "����" && int.Parse(cells[1]) == dialogueIndex)
            {
                nextBtn.gameObject.SetActive(true);
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);
                dialogueIndex = int.Parse(cells[5]);
                break;
            }
            else if (cells[0] == "��֧" && int.Parse(cells[1]) == dialogueIndex)
            {
                nextBtn.gameObject.SetActive(false);
                GenerateOption(i);
                break;
            }
            else if (cells[0] == "END")
            {
                Debug.Log("��Ϸ����");
                break;
            }
        }
    }

    /// <summary>
    /// ��ҳ
    /// </summary>
    public void ClickToNext()
    {
        ShowDialogueRow();
    }

    /// <summary>
    /// ����ѡ�ť
    /// </summary>
    /// <param name="_index"></param>
    public void GenerateOption(int _index)
    {
        string[] cells = dialogueRows[_index].Split(',');
        if (cells[0] == "��֧")
        {
            GameObject button = Instantiate(optionBtn, optionBtnGroup);
            button.GetComponentInChildren<Text>().text = cells[4];
            button.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                OnOptionBtnClicked(int.Parse(cells[5]));
            });
            GenerateOption(_index + 1);
        }
    }

    /// <summary>
    /// ���ѡ��ʵ�ַ�֧��ת
    /// </summary>
    /// <param name="_index"></param>
    public void OnOptionBtnClicked(int _index)
    {
        dialogueIndex = _index;
        ShowDialogueRow();
        for (int i = 0; i < optionBtnGroup.childCount; i++)
        {
            Destroy(optionBtnGroup.GetChild(i).gameObject);
        }
    }
}
