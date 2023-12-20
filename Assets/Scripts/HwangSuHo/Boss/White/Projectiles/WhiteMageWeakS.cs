using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class WhiteMageWeakS : Projectile
{
    bool _isDroping = false;
    [SerializeField] float _readyCount;
    [SerializeField] GameObject _warn;
    [Header("Model Parameter")]
    [SerializeField] GameObject[] _models;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Motor());
    }
    IEnumerator Motor()
    {
        _warn.SetActive(true);
        yield return new WaitForSeconds(_readyCount);
        _warn.SetActive(false);
        _isDroping = true;
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (_isDroping)
            base.Update();
    }
    public void ModelSet(int index)
    {
        _models[index].SetActive(true);
    }
}
