using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
	#region Variables
	[Range(0, 1)]
    public float throttle = 1.0f;
	

	[Tooltip("How much power the engine puts out.")]
	public float thrust;

	[SerializeField] Transform propeller;

	private Rigidbody rigid;
	AudioSource engineSound;
	#endregion

	#region Properties
	private float currentRPM;
	public float CurrentRPM
	{
		get { return currentRPM; }
	}
	#endregion
		
	private void Awake()
	{
		rigid = GetComponentInParent<Rigidbody>();
		engineSound = GetComponent<AudioSource>();
	}

    private void Update()
    {
		propeller.Rotate(Vector3.right * throttle * 20);
		engineSound.volume = throttle * 0.1f;
    }

    private void FixedUpdate()
	{
		if (rigid != null)
		{
			rigid.AddRelativeForce(Vector3.forward * thrust * throttle, ForceMode.Force);
		}

		if (throttle == 1)
        {
			Debug.Log("WHOAH THATS FAST!!!");
		}
	}

}
