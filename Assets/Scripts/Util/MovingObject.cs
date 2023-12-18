using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector3 Movement;

    private void Update()
    {
        transform.Translate(Movement * Time.deltaTime, Space.World);
    }
}
