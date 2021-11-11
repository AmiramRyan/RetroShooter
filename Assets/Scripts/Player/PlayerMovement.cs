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
        if(Input.GetButtonDown("Jump") && !inAir)
        {
            //jump
            inAir = true;
            //transform.position = Vector3.Lerp(transform.position,transform.position +new Vector3(0,jumpForce,0), 0.2f);
            myRigidBody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            myAnimator.SetTrigger("jump");
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Solid"))
        {
            inAir = false;
        }
    }
}
