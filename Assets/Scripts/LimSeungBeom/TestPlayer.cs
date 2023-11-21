using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    Vector3 TargetLocation;
    [SerializeField] Transform BulletSpawnPoint;
    GameObject RedHollow;
    [SerializeField] GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        RedHollow = transform.GetChild(3).gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z),Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z), Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E)) RedHollow.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Q)) RedHollow.SetActive(false);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hits;
        Physics.Raycast(ray, out hits);

        TargetLocation = hits.point;
        transform.LookAt(hits.point);

        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Projectile, BulletSpawnPoint.position, Quaternion.identity);
            bullet.transform.LookAt(hits.point);
        }
    }
}
