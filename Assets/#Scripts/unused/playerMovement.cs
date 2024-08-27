using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{


    //Health System
    public int maxHealth = 100;
    public int currentHealth;
    //public HealthBar healthBar;

    //PlayerMovement
    public CharacterController controller;

    public float speed = 0f;
    public float gravity = -200f;
    public float jumpHeight = 2f;

    public float walkspeed = 12f;
    public float sprintspeed = 22f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    void Start()
    {
        //Health start game
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {




        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + -transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift) && z == 1)
        {
            speed = sprintspeed;
        }
        else
        {
            speed = walkspeed;
        }
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= 20;
        //healthBar.SetHealth(currentHealth);
    }

}
