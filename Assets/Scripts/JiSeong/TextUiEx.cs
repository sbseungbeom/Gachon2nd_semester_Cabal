using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Text;
public class TextUiEx : MonoBehaviour
{
    public Image emptyImage0;
    public Image emptyImage1;
    public Image emptyImage2;
    public Image emptyBack;
    public Image textPanel;
    public TextAsset Excel_test;
    //오브 이미지
    public Sprite opponent0;
    public Sprite opponent1_0;
    public Sprite opponent1_1;
    public Sprite opponent1_2;
    public Sprite opponent1_3;
    public Sprite opponent1_4;
    //빛법사 이미지
    public Sprite opponent2_0;
    public Sprite opponent2_1;
    public Sprite opponent2_2;

    public Sprite backGround1;
    public Sprite backGround2;
    public AudioClip Talk1;

    public TMP_Text ChatText;
    public TMP_Text CharacterName;
    string[,] dataTable;

    private bool texting;
    private bool uiShake = false;
    private AudioSource audioSource;
    private bool _textSkip;
    private int lineSize, rowSize;

    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;    // 흔들림 정도

    private Vector3 originalPosition;
    private float shakeTimer = 0f;

    public string writerText = "";

    void Start()
    {
        texting = false;
        _textSkip = false;
        uiShake = false;
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        originalPosition = transform.position;

        string currenText = Excel_test.text.Substring(0, Excel_test.text.Length - 1);
        string[] line = currenText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        dataTable = new string[lineSize, rowSize];
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
            {
                dataTable[i, j] = row[j];
            }
        }
        print(dataTable[16, 10]);
        print(dataTable[16, 11]);
        print(dataTable[16, 12]);
        print(dataTable[16, 13]);
        print(dataTable[16, 14]);
        StartCoroutine(TextPractice());
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && texting == true)
        {
            _textSkip = true;
        }
    }
    IEnumerator NormalChat(string background_ID, string char_ID, string secondChar_ID, string talk_Text, string char_Emotion_Type, string secondChar_Emotion_Type, string talkBox_Image, string talkBox_Shake)
    {
        writerText = "";
        if (secondChar_ID == "@")
        {

        }
        if (background_ID == "523300")
        {
            emptyBack.sprite = backGround1;
        }
        else if (background_ID == "523301")
        {
            emptyBack.sprite = backGround2;
        }
        if (char_ID == "10001")
        {
            CharacterName.text = "오브";
        }
        else if (char_ID == "10002")
        {
            CharacterName.text = "빛법사";
        }

        if (char_Emotion_Type == "1_0")
        {
            emptyImage1.sprite = opponent1_0;
        }
        else if (char_Emotion_Type == "1_1")
        {
            emptyImage1.sprite = opponent1_1;
        }
        else if (char_Emotion_Type == "1_2")
        {
            emptyImage1.sprite = opponent1_2;
        }
        else if (char_Emotion_Type == "1_3")
        {
            emptyImage1.sprite = opponent1_3;
        }
        else if (char_Emotion_Type == "1_4")
        {
            emptyImage1.sprite = opponent1_4;
        }
        if (secondChar_Emotion_Type == "@")
        {
            emptyImage2.sprite = opponent0;
        }
        else if (secondChar_Emotion_Type == "2_0")
        {
            emptyImage2.sprite = opponent2_0;
        }
        else if (secondChar_Emotion_Type == "2_1")
        {
            emptyImage2.sprite = opponent2_1;
        }
        else if (secondChar_Emotion_Type == "2_2")
        {
            emptyImage2.sprite = opponent2_2;
        }
        if (talkBox_Shake != "@")
        {
            textPanel.GetComponent<UIPanelShake>().StartShake();
        }

        texting = true;
        int i = 0;
        for (i = 0; i < talk_Text.Length; i++)
        {
            yield return new WaitForSeconds(.05f);
            if (_textSkip)
            {
                int index = 0;
                //모든 텍스트를 한번에 wirtetext에 추가
                foreach (char a in talk_Text)
                {
                    if (index > i)
                    {
                        writerText += talk_Text[index];
                    }
                    index++;
                }
                i = talk_Text.Length;
                _textSkip = false;
            }
            else
                writerText += talk_Text[i];
            ChatText.text = writerText;
        }
        textPanel.GetComponent<UIPanelShake>().EndShake();
        texting = false;
        while (true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
            {
                break;
            }
            yield return null;
        }
    }

    void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator TextPractice()
    {
        int maxLine = lineSize;
        for (int i = 0; i < maxLine; i++)
        {
            yield return StartCoroutine(NormalChat(dataTable[i, 2], dataTable[i, 3], dataTable[i, 4], dataTable[i, 6], dataTable[i, 10], dataTable[i, 11], dataTable[i, 12], dataTable[i, 14]));
        }
    }
}
