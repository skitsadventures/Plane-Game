using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour
{
    public Engine engine;
    public float Speed;
    public float torque;
    private float throttle = 0f;
    Vector3 m_StartPos, m_StartForce;


    Rigidbody Plane;

    Vector3 l_EulerAngleVelocity;
    Vector3 r_EulerAngleVelocity;
    Vector3 u_EulerAngleVelocity;
    Vector3 d_EulerAngleVelocity;


    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        Plane = GetComponent<Rigidbody>();
        StartCoroutine(CalcSpeed());
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        l_EulerAngleVelocity = new Vector3(0, 0, -20);
        r_EulerAngleVelocity = new Vector3(0, 0, 20);
        u_EulerAngleVelocity = new Vector3(15, 0, 0);
        d_EulerAngleVelocity = new Vector3(-15, 0, 0);

        m_StartPos = transform.position;
        m_StartForce = Plane.transform.position;

    }
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForFixedUpdate();

            Speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
        }
    }



    // Update is called once per frame
    void Update()
    {
        float maxSpeed = 60;
        Plane.velocity = Vector3.ClampMagnitude(Plane.velocity, maxSpeed);
        Vector3 upForce = new Vector3 (0, 30, 0);
        Vector3 fForce = new Vector3(0, 0, 200);
        

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Engine on///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Speed >= 30 && Speed <= 40 && throttle == 1)
        {
            Plane.AddForce(fForce);
        }

        if (Speed >= 41 && Speed <= 50 && throttle == 1)
        {
            
        }

        if (Speed >= 51 && Speed <= 66 && throttle == 1)
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Engine off///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Speed >= 0 && Speed <= 30 && throttle == 0)
        {
            Plane.velocity = Plane.velocity * 0.99f * Time.deltaTime;
        }

        if (Speed >= 31 && Speed <= 40 && throttle == 0.40)
        {
            Plane.velocity = Plane.velocity * .8f * Time.deltaTime;
        }

        if (Speed >= 41 && Speed <= 50 && throttle == 0.50)
        {
            Plane.velocity = Plane.velocity * .8f * Time.deltaTime;
        }

        if (Speed >= 51 && Speed <= 66 && throttle == 1)
        {
            Debug.Log("WHOAH THATS FAST!!!");
            Plane.velocity = Plane.velocity * .8f * Time.deltaTime;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////




        //if (Speed >= 50.0f)
        //{
        //    Plane.velocity = transform.forward * Plane.velocity.magnitude;
        //}


        //if (Speed > 30 && Speed < 60f)
        //{

        //    Plane.AddForce(transform.up * ((Speed / 10.0f)));

        //}

        if (engine != null)
        {
            // Fire 1 to speed up, Fire 2 to slow down. Make sure throttle only goes 0-1.
            throttle += Input.GetAxis("Fire1") * Time.deltaTime;
            throttle -= Input.GetAxis("Fire2") * Time.deltaTime;
            throttle = Mathf.Clamp01(throttle);

            engine.throttle = throttle;
        }

        //if (engine.thrust == 0)
        //{
        //    Vector3 lastVelocity = Plane.velocity;
        //    Plane.AddForce(-lastVelocity / 2f);
        //    Plane.AddForce(transform.forward * Speed);
        //    //Physics.gravity = new Vector3(0, -1.0F, 0);
        //}

        //else
        //{
        //    Vector3 lastVelocity = Plane.velocity;
        //    Plane.AddForce(-lastVelocity / 2f);
        //    Plane.AddForce(transform.forward * engine.thrust);
        //    Plane.AddForce(transform.up * Speed * 10.0f);

        //}

        if (Input.GetKey("d"))
        {
            Quaternion deltaRotation = Quaternion.Euler(l_EulerAngleVelocity * Time.fixedDeltaTime);
            Plane.MoveRotation(Plane.rotation * deltaRotation);
        }
        if (Input.GetKey("a"))
        {
            Quaternion deltaRotation = Quaternion.Euler(r_EulerAngleVelocity * Time.fixedDeltaTime);
            Plane.MoveRotation(Plane.rotation * deltaRotation);
        }
        if (Input.GetKey("s"))
        {
            Quaternion deltaRotation = Quaternion.Euler(u_EulerAngleVelocity * Time.fixedDeltaTime);
            Plane.MoveRotation(Plane.rotation * deltaRotation);
        }
        if (Input.GetKey("w"))
        {
            Quaternion deltaRotation = Quaternion.Euler(d_EulerAngleVelocity * Time.fixedDeltaTime);
            Plane.MoveRotation(Plane.rotation * deltaRotation);
        }

        float turn = Input.GetAxis("Turn");
        Plane.AddTorque(transform.up * torque * turn);

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        //This is where we can make consequences for hitting land
        if (terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
    }
}

