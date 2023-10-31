using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TextUiEx : MonoBehaviour
{
    public Image emptyImage1;
    public Image emptyImage2;
    public Image emptyBack;
    public Sprite opponent0;
    public Sprite opponent1_1;
    public Sprite opponent1_2;
    public Sprite opponent2_1;
    public Sprite opponent2_2;
    public GameObject selectB1;
    public GameObject selectB2;
    public GameObject selectB3;
    public Sprite backGround1;
    public Sprite backGround2;
    public AudioClip Talk1;//임시
    public int buttonSelect;

    public TMP_Text ChatText;
    public TMP_Text CharacterName;

    public TMP_Text b1Text;
    public TMP_Text b2Text;
    public TMP_Text b3Text;

    private AudioSource audioSource;

    public string writerText = "";

    void Start()
    {
        buttonSelect = 0;

        selectB1.SetActive(false);
        selectB2.SetActive(false);
        selectB3.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();

        StartCoroutine(TextPractice1());
    }

    public void B1()
    {
        buttonSelect = 1;
        selectB1.SetActive(false);
        selectB2.SetActive(false);
        selectB3.SetActive(false);
        StartCoroutine(TextPractice1_1());
    }
    public void B2()
    {
        buttonSelect = 2;
        selectB1.SetActive(false);
        selectB2.SetActive(false);
        selectB3.SetActive(false);
        StartCoroutine(TextPractice1_1());
    }
    public void B3()
    {
        buttonSelect = 3;
        selectB1.SetActive(false);
        selectB2.SetActive(false);
        selectB3.SetActive(false);
        StartCoroutine(TextPractice1_1());
    }

    IEnumerator NormalChat(string narrator, string narration, int person1, int person2, int background, int audiosound)
    {
        int i = 0;
        CharacterName.text = narrator;//지울부분
        writerText = "";
        //person1
        if(person1 == 0)
        {
            emptyImage1.sprite = opponent0;
        }
        else if (person1 == 1)
        {
            emptyImage1.sprite = opponent1_1;
        }
        else if (person1 == 2)
        {
            emptyImage1.sprite = opponent1_2;
        }
        //person2
        if (person2 == 0)
        {
            emptyImage2.sprite = opponent0;
        }
        else if (person2 == 1)
        {
            emptyImage2.sprite = opponent2_1;
        }
        else if (person2 == 2)
        {
            emptyImage2.sprite = opponent2_2;
        }
        //background
        if (background == 1)
        {
            emptyBack.sprite = backGround1;
        }
        else if (background == 2)
        {
            emptyBack.sprite = backGround2;
        }
        //audiosound
        if (audiosound == 1)
        {
            PlayAudio(Talk1);
        }

        //텍스트 효과
        for (i = 0; i < narration.Length; i++)
        {
            writerText += narration[i];
            ChatText.text = writerText;
            yield return null;
        }
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
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

    IEnumerator TextPractice1()
    {
        yield return StartCoroutine(NormalChat(" ", " ", 0, 0, 1, 0));
        yield return StartCoroutine(NormalChat(" ", " ", 1, 0, 1, 1));
        yield return StartCoroutine(NormalChat(" ", " ", 1, 1, 1, 0));
        yield return StartCoroutine(NormalChat("주인공", "대화1_1", 2, 1, 1, 1));
        yield return StartCoroutine(NormalChat("상대", "대화1_2", 1, 2, 1, 0));
        b1Text.text = "선택1";
        b2Text.text = "선택2";
        b3Text.text = "선택3";
        selectB1.SetActive(true);
        selectB2.SetActive(true);
        selectB3.SetActive(true);
    }
    IEnumerator TextPractice1_1()
    {
        if (buttonSelect == 1)
        {
            yield return StartCoroutine(NormalChat("주인공", "대답1_1_1", 2, 1, 1, 0));
            yield return StartCoroutine(NormalChat("상대", "대답1_1_2", 1, 2, 1, 0));
        }
        else if (buttonSelect == 2)
        {
            yield return StartCoroutine(NormalChat("주인공", "대답1_2_1", 2, 1, 1, 0));
            yield return StartCoroutine(NormalChat("상대", "대답1_2_2", 1, 2, 1, 0));
        }
        else if (buttonSelect == 3)
        {
            yield return StartCoroutine(NormalChat("주인공", "대답1_3_1", 2, 1, 1, 0));
            yield return StartCoroutine(NormalChat("상대", "대답1_3_2", 1, 2, 1, 0));
        }
        StartCoroutine(TextPractice2());
    }
    IEnumerator TextPractice2()
    {
        yield return StartCoroutine(NormalChat("상대", "대화2_1", 0, 2, 2, 0));
        yield return StartCoroutine(NormalChat(" ", " ", 1, 1, 2, 0));
        yield return StartCoroutine(NormalChat("주인공", "대화2_2", 2, 1, 2, 0));
        yield return StartCoroutine(NormalChat("주인공,상대", "대화2_3", 2, 2, 2, 0));

    }
}
