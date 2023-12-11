using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageObjectPool : MonoBehaviour
{
    float _radius;
    [Header("WeakShot POOL")]
    [SerializeField] WhiteMagicianNormalShot _daggerPrefab;
    [SerializeField] List<WhiteMagicianNormalShot> _daggers;
    [SerializeField] int _daggersCount;
    public int _daggerActiveIndex;

    [Header("Collar POOL")]
    [SerializeField] WhiteMagicianCollar _collarPrefab;
    [SerializeField] List<WhiteMagicianCollar> _collars;
    [SerializeField] int _collarsCount;
    public int _collarActiveIndex;

    [Header("Meteor POOL")]
    [SerializeField] WhiteMagicianMeteor _MeteorPrefab;
    [SerializeField] List<WhiteMagicianMeteor> _Meteors;
    [SerializeField] int _MeteorsCount;
    public int _meteorActiveIndex;

    [Header("Fist POOL")]
    [SerializeField] WhiteMagicianFist _FistPrefab;
    [SerializeField] List<WhiteMagicianFist> _Fists;
    [SerializeField] int _FistsCount;
    public int _fistActiveIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GenratePool()
    {
        int i;
        for (i = 0; i < 5; i++)
        {
            _daggers.Add(Instantiate(_daggerPrefab, transform.position, _daggerPrefab.transform.rotation));
            _daggersCount++;
        }
        for (i = 0; i < 5; i++)
        {
            _collars.Add(Instantiate(_collarPrefab, transform.position, _daggerPrefab.transform.rotation));
            _collarsCount++;
        }
        for (i = 0; i < 5; i++)
        {
            _Meteors.Add(Instantiate(_MeteorPrefab, transform.position, _daggerPrefab.transform.rotation));
            _MeteorsCount++;
        }
        for (i = 0; i < 5; i++)
        {
            _Fists.Add(Instantiate(_FistPrefab, transform.position, _daggerPrefab.transform.rotation));
            _FistsCount++;
        }

    }
    public void UseDaggerPool()
    {
        float count = Random.Range(3, _daggersCount + .1f);
        _daggerActiveIndex = Mathf.FloorToInt(count);
        for (int i = 0; i < count; i++)
        {
            //반지름 맞춰서 랜덤하게 데거 배치
        }
        StartCoroutine(DaggerPattern(count));
    }
    IEnumerator DaggerPattern(float count)
    {
        //for문으로 .n초마다 활성화
        yield return new WaitForSeconds(3.0f);
        //경고 띄우기
        yield return new WaitForSeconds(3.0f);
        //for로 내려찍기
        yield return new WaitForSeconds(3.0f);
        //끗
    }

    public void UseCollarPool()
    {
        float count = Random.Range(3, _collarsCount + .1f);
        _collarActiveIndex = Mathf.FloorToInt(count);
        for (int i = 0; i < count; i++)
        {
            //반지름 맞춰서 랜덤하게 데거 배치
        }
        StartCoroutine(CollarPattern(count));
    }
    IEnumerator CollarPattern(float count)
    {
        //for문으로 .n초마다 활성화
        yield return new WaitForSeconds(3.0f);
        //경고 띄우기
        yield return new WaitForSeconds(3.0f);
        //for로 내려찍기
        yield return new WaitForSeconds(3.0f);
        //끗
    }
    public void UseMeteorPool()
    {
        float count = Random.Range(3, _MeteorsCount + .1f);
        _meteorActiveIndex = Mathf.FloorToInt(count);
        for (int i = 0; i < count; i++)
        {
            //반지름 맞춰서 랜덤하게 데거 배치
        }
        StartCoroutine(MeteorPattern(count));
    }
    IEnumerator MeteorPattern(float count)
    {
        //for문으로 .n초마다 활성화
        yield return new WaitForSeconds(3.0f);
        //경고 띄우기
        yield return new WaitForSeconds(3.0f);
        //for로 내려찍기
        yield return new WaitForSeconds(3.0f);
        //끗
    }
    public void UseFistPool()
    {
        float count = Random.Range(3, _FistsCount + .1f);
        _fistActiveIndex = Mathf.FloorToInt(count);
        for (int i = 0; i < count; i++)
        {
            //반지름 맞춰서 랜덤하게 데거 배치
        }
        StartCoroutine(FistPattern(count));
    }
    IEnumerator FistPattern(float count)
    {
        //for문으로 지정된 시간마다 활성화 하고 공격
        yield break;
        //끗
    }
}
