using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class heroController : MonoBehaviour {
    Rigidbody2D rBody;
    Animator animator; 

    public float jumpSpeed = 100f;
    public float moveSpeed = 100f;
    public Vector3 baseScale;
    public AudioClip jumpSound;
    public float maxVelocity = 2f;

    public bool isGrounded = false;
    float facedX = 1;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseScale = transform.localScale;
    }

	void Update () {
        if (!isGrounded && rBody.velocity.magnitude > maxVelocity)
            rBody.velocity = rBody.velocity.normalized * maxVelocity;

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            var newFaced = Input.GetKey("a") ? -1  : 1;
            if (newFaced != facedX)
            {
                transform.localScale = new Vector3(newFaced*baseScale.x, baseScale.y, baseScale.z);

                facedX = newFaced;
            }
            animator.SetBool("isMoving", true);
				
            transform.Translate(new Vector3(facedX, 0) * moveSpeed * Time.deltaTime);
        } else 
			animator.SetBool("isMoving", false);

        isGrounded = rBody.velocity == Vector2.zero;
        animator.SetBool("isGrounded", isGrounded);
        //animator.SetFloat("yVelocity", rBody.velocity.y);

        if (Input.GetKeyDown("w"))
            Jump();
               
	

    }

    void Jump()
    {
        if (isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpSpeed);
            GetComponent<AudioSource>().PlayOneShot(jumpSound);

        }
    }

    void RightStep() { }
    void LeftStep() { }
}
