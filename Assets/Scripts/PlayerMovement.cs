using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 change;
    private Rigidbody2D myRigidBody;
    private bool inAir;
    [SerializeField] Animator myAnimator;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        if (!myRigidBody)
        {
            Debug.LogError("No rigidBody found!");
        }
        if (!myAnimator)
        {
            Debug.LogError("No Animator found!");
        }
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        PlayAnimationsAndMove();
        if(Input.GetButtonDown("jump") && !inAir)
        {
            //jump
            inAir = true;
            myRigidBody.MovePosition(Vector2.up * jumpForce * Time.deltaTime);
        }
    }

    void MoveCharacter()
    {
        transform.position += change * Time.deltaTime * playerSpeed;
    }

    void PlayAnimationsAndMove()
    {
        if (change != Vector3.zero)
        {
            //currentState = PlayerState.walk;
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            transform.localScale = new Vector2(change.x,transform.localScale.y);
            myAnimator.SetBool("isMoving", true);
            myAnimator.SetFloat("moveX", change.x);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            inAir = false;
        }
    }
}
