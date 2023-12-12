using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGolem : Enemy
{

    SpriteRenderer spriter;

    [SerializeField] Sprite LowFireGolem;
    [SerializeField] Sprite LowWaterGolem;
    [SerializeField] Sprite LowGrassGolem;

    int SpriteSelect;
    // Start is called before the first frame update
    void Start()
    {
        SpriteSelect = Random.Range(0,3);
        spriter= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(SpriteSelect == 0) { 
            spriter.sprite = LowFireGolem;
        }
        if (SpriteSelect == 1)
        {
            spriter.sprite = LowWaterGolem;
        }
        if (SpriteSelect == 2)
        {
            spriter.sprite = LowGrassGolem;
        }
    }
}
