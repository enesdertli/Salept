using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector3 velocity;
    float JumpForce = 5f;
    float speed = 3f;
    Animator playerAnimator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

 
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += velocity * Time.deltaTime * speed;
        if (Input.GetButtonDown("Jump") && rigidbody.velocity.y == 0) {
            rigidbody.AddForce(Vector3.up*JumpForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
        if (playerAnimator.GetBool("isJumping") && rigidbody.velocity.y == 0) {
            playerAnimator.SetBool("isJumping", false);
        }
        if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.localScale = new Vector3(1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1) {
            transform.localScale = new Vector3(-1, 1);
        }

        bool playerHasHorizontalSpeed = Mathf.Abs(velocity.x)  > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);



    }
}
