using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GravMap;

public class Airplane_Controller : MonoBehaviour
{
    public float FlySpeed = 45;
    public float YawAmount = 120;
    public float Rotate = 360;
    public Engine engine;
    private float throttle = 45.0f;
   // public GravMap Map;

    public float Yaw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, GravMap.GravMapM(FlySpeed, 0, 45, -9.8f, 0), 0);




        transform.position += transform.forward * FlySpeed * Time.deltaTime;
        

        //Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Yaw,pitch,roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, -30, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 360, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
        float turn = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        //Apply Rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);





        

        if (engine != null)
        {
            // Fire 1 to speed up, Fire 2 to slow down. Make sure throttle only goes 0-1.
            throttle += Input.GetAxis("Fire1") * 2f * Time.deltaTime;
            throttle -= Input.GetAxis("Fire2") * 2f * Time.deltaTime;
            throttle = Mathf.Clamp(0, throttle, 45);

            FlySpeed = throttle;
        }
    }
    

}
