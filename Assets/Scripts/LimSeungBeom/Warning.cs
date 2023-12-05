using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    [SerializeField] float ChangeSpeed;
    bool OnChange;
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        OnChange = false;
        StartCoroutine(Change());
    }
    private void OnDisable()
    {
        SR.color = new Color(255, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Color excolor = new Color(255, 0, 0, ChangeSpeed * Time.deltaTime);
        if(OnChange)
        {
            SR.color += excolor;
        }

    }
    IEnumerator Change()
    {
        OnChange = true;
        yield return new WaitForSeconds(3); //3초동안 증가.
        OnChange = false;
    }
    
}
