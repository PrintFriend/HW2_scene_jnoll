using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class playerwitdash: MonoBehaviour
{
    // properites of Rigidbody: Add force, velocity

    Rigidbody rb;
    [SerializeField]
    float jumpSpeed = 10;

    [SerializeField]
    GameObject bullet;

    public float speed = 10f;

    // Start is called before the first frame update
    [SerializeField]
    float bulletSpeed = 100f;
    [SerializeField]
    bool onGround;

    private int maxJumps = 2;
    private int jumpRemaining;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumpRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value) // control type: vector 2 --> {x,y}
    {
        Vector2 input = value.Get<Vector2>();

        Debug.Log(input);

        //transform.forward, transform.right (vectors forward and right from player)

        rb.velocity = input.y * transform.forward + input.x * transform.right;
        rb.velocity *= speed; //rb.velocity = rb.velocity * speed
    }

    void OnFire() //this function will be called when the fire action is triggered, e.g. when the left mouse button is pressed
    {
        Debug.Log("FIRING");
        GameObject bulletInstance = Instantiate(bullet, transform.position + 0.5f * transform.forward, Quaternion.identity);
        Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(bulletSpeed * transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            // our feet are touching the ground
            onGround = true;
            jumpRemaining = maxJumps;
        }
        Debug.Log("ground");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            // our feet are touching the ground
            onGround = false;
        }
    }
    void OnJump() //this function will be called when jump action is triggered, e.g. when the space is pressed
    {

        Debug.Log("JUMPING");
        if (onGround == true || jumpRemaining>0)
        {
            rb.velocity += (transform.up * jumpSpeed);
        }

        jumpRemaining = jumpRemaining - 1;
    }

}


