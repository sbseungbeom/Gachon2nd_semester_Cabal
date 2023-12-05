using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuSet;
    public List<GameObject> menu = new List<GameObject>();
    public List<GameObject> setting = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < menu.Count; i++)
        {
            menu[i].SetActive(true);
        }
        for (int i = 0; i < setting.Count; i++)
        {
            setting[i].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuSet.activeSelf)
            {
                Resume();
                Back();
            }
            else
            {
                MenuOpen();
            }
        }
        if (menuSet.activeSelf)
        {
            //게임정지
        }
    }
    public void MenuOpen()
    {
        menuSet.SetActive(true);
    }

    public void Resume()
    {
        menuSet.SetActive(false);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Setting()
    {
        for(int i = 0; i < menu.Count; i++)
        {
            menu[i].SetActive(false);
        }
        for(int i = 0; i < setting.Count; i++)
        {
            setting[i].SetActive(true);
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Back()
    {
        for (int i = 0; i < menu.Count; i++)
        {
            menu[i].SetActive(true);
        }
        for (int i = 0; i < setting.Count; i++)
        {
            setting[i].SetActive(false);
        }
    }
}
