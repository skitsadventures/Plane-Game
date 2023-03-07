using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private float life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life += 0.1f;
        if (life > 7.0f)
        {
            Destroy(gameObject);
        }
    }
}
