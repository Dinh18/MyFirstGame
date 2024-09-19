using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5; // toc do cua player
    private float jumpHeight = 7;
    // private StateMovement playerstateMovement; //trang thai di chuyen cua nhan vat
    private float horizontalMove;
    private Rigidbody2D rb; // chua cac thanh phan ve van toc, gia toc
    private bool isFaccingRight = true;
    private bool isGrounded = false; 
    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // playerstateMovement = StateMovement.Idle;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        // Horizontal di chuyen theo chieu doc tra ve -1, 0 ,1
        horizontalMove = Input.GetAxisRaw("Horizontal"); 
        if(!Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(speed * horizontalMove, rb.velocity.y);
            MoveHorizontal();
            playerAnimator.SetFloat("speed",Math.Abs(horizontalMove));
        }

        Jump();
        Crouch();
        Attack();

        
    }

    private void MoveHorizontal()
    {
        // quau player sang ben trai khi player dang nhin sang ben phai
        if(isFaccingRight && horizontalMove == -1)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            isFaccingRight = false;
        }
        // quay player sang ben phai khi player dang nhin sang ben trai
        if(!isFaccingRight && horizontalMove == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            isFaccingRight = true;
        }
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        } 
    }

    private void Crouch()
    {
        if(Input.GetKey(KeyCode.S))
        {
            playerAnimator.SetBool("isCrouch",true);
        }
        else playerAnimator.SetBool("isCrouch",false);
    }

    private void Attack()
    {
        if(Input.GetMouseButton(0)) playerAnimator.SetBool("isAttack",true);
        else playerAnimator.SetBool("isAttack",false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        playerAnimator.SetBool("isGround",true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        playerAnimator.SetBool("isGround",false);

    }

}
