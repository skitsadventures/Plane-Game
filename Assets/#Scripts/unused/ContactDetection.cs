using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDetection : MonoBehaviour
{
    private DemoBomb demoSceneControl;
    public Rigidbody rigidbody;

    private void Start()
    {
        // Find the csDemoSceneControl component in the scene
        demoSceneControl = FindObjectOfType<DemoBomb>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object doesn't have the "LandingStrip" tag
        if (!collision.gameObject.CompareTag("LandingStrip"))
        {
            // Call the InstantiateEffect() function from csDemoSceneControl script
            demoSceneControl.InstantiateEffect();
            rigidbody.freezeRotation = true;
        }
    }

}
