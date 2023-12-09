using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

public class SunlightYellowOverdrive : MonoBehaviour
{


    [SerializeField] float SpreadX; // 좌우 퍼지는 정도
    [SerializeField] float SpreadY; // 상하 퍼지는 정도
    [SerializeField] float SpreadZ; // 전후 퍼지는 정도

    [SerializeField] float FistCoolTime;
    [SerializeField] GameObject Player;
    int FistsArrIndex = 0;
    float ex;
    float ex2;
    float ex3;
    [SerializeField] GameObject SunlightYellowOverdrive_Fist;

    Transform SavedPlayerPosition;

    GameObject[] Fists = new GameObject[30];


    // Start is called before the first frame update
    void Start()
    {
        /// <summary>
        /// 주먹 50개 생성 후 Fists 배열에 넣음.
        /// </summary>
        for(int i = 0; i < Fists.Length; i++)
        {
            GameObject FistInstances = Instantiate(SunlightYellowOverdrive_Fist);
            Fists[i] = FistInstances;
            FistInstances.SetActive(false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            StartCoroutine(ActivateFist(FistsArrIndex,ex,ex2,ex3));
                
            //StartCoroutine(ActivateFist(FistsArrIndex, 0, 0));
            
        }


        ex = Random.Range(-SpreadX, SpreadX);
        ex2 = Random.Range(-SpreadY, SpreadY);
        ex3 = Random.Range(-SpreadZ, SpreadZ);
    }


    //주먹 발사하는 함수. x,y,z의 offset값을 인자로 받아주어야 함.
    IEnumerator ActivateFist(int Index,float Offset,float Offset2,float Offset3)
    {
        SavedPlayerPosition = Player.transform;
        GameObject ActivatedFist = Fists[Index];

        FistsArrIndex++;
        if (FistsArrIndex == Fists.Length)
        {
            FistsArrIndex = 0;
        }
        ActivatedFist.SetActive(true);
        ActivatedFist.transform.LookAt(Player.transform.position);
        ActivatedFist.transform.position = new Vector3(this.transform.position.x + Offset, this.transform.position.y + Offset2, this.transform.position.z + Offset3);
        
        yield return new WaitForSeconds(5);
        
        ActivatedFist.SetActive(false);
        ActivatedFist.transform.position = this.transform.position;
    }
}
