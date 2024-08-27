using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject shotPrefab;
    public float bulletSpeed = 30;
    public AudioSource src;
    public AudioClip shootingSound;

    private float nextTimeToFire = 0f;
    public float fireRate = 6f;


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            var bullet = Instantiate(shotPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            Shoot();
        }
    }

    void Shoot()
    {
        

        src.clip = shootingSound;
        src.Play();
    }

}