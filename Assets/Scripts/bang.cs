using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bang : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject shotPrefab;
    public float bulletSpeed = 30;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(shotPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

}