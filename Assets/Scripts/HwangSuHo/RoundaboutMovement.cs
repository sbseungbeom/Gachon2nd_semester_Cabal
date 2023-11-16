using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundaboutMovement : MonoBehaviour
{
    //[SerializeField] int dir;
    [SerializeField] float speed;
    [SerializeField] Transform offset;

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        transform.RotateAround(offset.position, Vector3.up, speed * dir * Time.deltaTime);
    }
}
