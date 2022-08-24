using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    Vector2 moveInput;
    Animator animator;
    BoxCollider2D myBoxCollider2D;

    [SerializeField]
    float xSpeed = 1f;

    [SerializeField]
    float jumpPower = 500f;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        FlipSprite();
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        print(moveInput);
        myRigidbody2D.velocity = new Vector2(moveInput.x * xSpeed, myRigidbody2D.velocity.y);
        // animator.SetBool("run", true);
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed && myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myRigidbody2D.AddForce(new Vector2(myRigidbody2D.velocity.x, jumpPower));
            // animator.SetBool("jump", true);
            print("jump");
        }
    }

    private void FlipSprite()
    {
        // bool movingRight = rigidbody2D.velocity.x > Mathf.Epsilon;
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            animator.SetBool("run", true);
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
}
