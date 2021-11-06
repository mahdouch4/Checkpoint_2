using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float smooth;
    public Rigidbody2D rb;
    private bool FacingRight;
    private bool OnGround;
    public Collider2D Groundcheck;
    public LayerMask Ground;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }

    void FixedUpdate()
    {
        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(x * speed ,rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity,targetVelocity,ref targetVelocity , smooth *Time.deltaTime);
        if (x!=0 && OnGround == true){
            animator.SetBool("Running",true);
        }
        if(OnGround == false || x==0){
            animator.SetBool("Running",false);
        }
        transform.rotation = Quaternion.identity;
        //animator.SetBool("Run", true);
       //jumping 
        OnGround = Groundcheck.IsTouchingLayers(Ground);
        if(Input.GetKeyDown(KeyCode.Space) && OnGround ){
           rb.AddForce(new Vector2 (0f,jumpForce));
           GetComponent<AudioSource>().Play();
           }
           if(OnGround == false){
               animator.SetBool("Jumping",true);
           }
           else if (OnGround == true){
               animator.SetBool("Jumping",false);
           }
          //Debug.Log(x);

        //Flipping
        if(x == 1 && FacingRight){
            Flip();

        }
        else if (x == -1 && !FacingRight){
            Flip();
        }
    }   
    void Flip() {
        FacingRight=!FacingRight;
        float scale = transform.localScale.x;
        scale *=-1;
        transform.localScale = new Vector2 (scale,transform.localScale.y);

    }
}
