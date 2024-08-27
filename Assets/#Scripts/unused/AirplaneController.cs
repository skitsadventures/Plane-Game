using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GravMap;

public class AirplaneController : MonoBehaviour
{
    public float FlySpeed;
    public float YawAmount = 120;
    public float Rotate = 360;
    public Engine engine;
    private float throttle = 0f;
    GameObject Plane;
    //bool VehicleEnable = true   ;
    // public GravMap Map;

    public float Yaw;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

        //if (VehicleEnable == true)
        //{

            // Plane.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            Physics.gravity = new Vector3(0, GravMapM(FlySpeed, 0, 45, -9.8f, 0), 0);

            transform.position += transform.forward * FlySpeed * Time.deltaTime;

        if (FlySpeed >= 30)
        {
            //Plane.transform
        }
        if (FlySpeed >= 40)
        {
            
        }
        if (FlySpeed >= 40)
        {

        }

        if (Input.GetKey("d"))
            {
                transform.Rotate(0, 0, -1);
            }
            if (Input.GetKey("a"))
            {
                transform.Rotate(0, 0, 1);
            }
            if (Input.GetKey("s"))
            {
                transform.Rotate(1, 0, 0);
            }
            if (Input.GetKey("w"))
            {
                transform.Rotate(-1, 0, 0);
            }

            if (engine != null)
            {
                // Fire 1 to speed up, Fire 2 to slow down. Make sure throttle only goes 0-1.
                throttle += Input.GetAxis("Fire1") * 2f * Time.deltaTime;
                throttle -= Input.GetAxis("Fire2") * 2f * Time.deltaTime;
                throttle = Mathf.Clamp(throttle, 0, 45);

                FlySpeed = throttle;
            }
        //}
    }

    public static float GravMapM(float FlySpeed, float MinSpeed, float MaxSpeed, float MinGrav, float MaxGrav)
        {
            var fromAbs = FlySpeed - MinSpeed;
            var fromMaxAbs = MaxSpeed - MinSpeed;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = MaxGrav - MinGrav;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + MinGrav;

            return to;
        }
    
}
