using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof (Animator))]
public class heroController : MonoBehaviour {
    Rigidbody2D rBody;
    Animator animator; 

    public float jumpSpeed = 100f;
    public float moveSpeed = 100f;
    public Transform groundCheck;
    public AudioClip jumpSound;

    bool isGrounded = false;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left*moveSpeed);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed);

        if (isGrounded != (rBody.velocity == Vector2.zero))
        {
            SendMessage("leftStep");
            SendMessage("RightStep");
        }

        isGrounded = rBody.velocity == Vector2.zero;
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isMoving", true);
        }

        if ((Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            || (Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpSpeed);
            GetComponent<AudioSource>().PlayOneShot(jumpSound);

        }
    }
}
