using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //public float life = 3;
    private float life;
    //public EnemyFollow currentHealth;
    public int Dmg = 10;
    void Awake()
    {
        //Destroy(gameObject, life);
        life = 0.0f;
    }

    private void Update()
    {
        life += 0.1f;
        if (life > 8.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
