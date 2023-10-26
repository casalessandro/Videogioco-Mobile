using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{ 

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    //Qui provo a mettere le veriabili per i pulsanti
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f; //Velocità movimenti orizzontali;
    [SerializeField] private float jumpForce = 14f; //Velocità salto; Serialize indica che la propirietà appare anche su unity(puoi mettere pure public);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        moveLeft= false;
        moveRight= false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }



    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
       /* dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
       */
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationUpdate();
    }
     
    private void MovePlayer()
    {
        if(moveLeft)
        {
            horizontalMove = -moveSpeed;
        }
        else if(moveRight)
        {
            horizontalMove= moveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
    public void FixedUpdate()
    {
       rb.velocity= new Vector2(horizontalMove, rb.velocity.y);
    }
    private void UpdateAnimationUpdate() //Si mette update per far capi che si deve eseguire ogni frame
    {
        if (dirX > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
            anim.SetBool("Running", false);
    }
}


