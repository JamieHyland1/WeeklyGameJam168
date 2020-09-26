using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Range(1,10)] public float jumpVelocity;
    [Range(1,15)] public float wallJumpVelocityY;
    [Range(1,15)] public float wallJumpVelocityX;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Range(1,10)]public int jumpFrames = 3;
    public int jumpFrameCounter;
    Color color;

    [Range(1,10)]public float runSpeed = 2f;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    Animator animator;
    bool jumpInput = false;

    public bool onWall = false;
    public bool onGround = true;

    public bool wallJumping = false;

    public Transform groundCheck;
    public Transform groundCheckR;
    public Transform groundCheckL;

    public Transform wallCheckR;
    public Transform wallCheckL;
    bool runInput;
    private Vector2 direction;
    Vector2 oldPos;

    void Awake(){
       rigidbody = this.GetComponent<Rigidbody2D>();
       spriteRenderer = this.GetComponent<SpriteRenderer>();
       animator = this.GetComponent<Animator>();
       direction = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        setTrailColor();
        if(!onGround && jumpFrameCounter > 0)jumpFrameCounter--;
        Vector3 debugPos = transform.position;
         if(Input.GetButtonUp("Horizontal")){
            runInput = false;
        }
        if(Input.GetButtonDown("Jump") && ((onGround || onWall) || jumpFrameCounter > 0)){
            Debug.Log("pressed jump");
            jumpInput = true;
            animator.SetBool("isJumping",jumpInput);
        }
        if(Input.GetKey("d") || Input.GetKey("right")){
            runInput = true;
            spriteRenderer.flipX = false;
            direction.x=-1;
        }else if(Input.GetKey("a") || Input.GetKey("left")){
            runInput = true;
            spriteRenderer.flipX = true;
            direction.x = 1;
        }
       Debug.DrawLine(oldPos, debugPos, color, 2.0f);
       Debug.DrawLine(transform.position, new Vector3(debugPos.x + rigidbody.velocity.normalized.x,debugPos.y,debugPos.z),Color.red);
       Debug.DrawLine(transform.position, new Vector3(debugPos.x,debugPos.y + rigidbody.velocity.normalized.y,debugPos.z),Color.green);
       Debug.DrawLine(transform.position, new Vector3(debugPos.x + rigidbody.velocity.normalized.x,debugPos.y + rigidbody.velocity.normalized.y,debugPos.z),Color.cyan);
    }

    void FixedUpdate(){
       oldPos = transform.position;
       checkWallsAndFloor();
        if(jumpInput && onWall){
            rigidbody.AddForce(new Vector2(direction.x * wallJumpVelocityX,wallJumpVelocityY),ForceMode2D.Impulse);
            jumpInput = false;
            animator.SetBool("isJumping",jumpInput);
            Debug.Log("wall jump " + direction.x * wallJumpVelocityX);
            direction.x *= -1;
            if(spriteRenderer.flipX == false)spriteRenderer.flipX = true; else spriteRenderer.flipX = false; 

        }else if(jumpInput){
            rigidbody.AddForce(Vector2.up * jumpVelocity,ForceMode2D.Impulse);
            jumpInput = false;
            animator.SetBool("isJumping",jumpInput);
          
        }
        //Wall jump code
        // if(rigidbody.velocity.y < 0 && (onWall || (runInput && onWall))){
        //     if(runInput && onWall)Debug.Log("pushing up on wall");
        //     rigidbody.gravityScale = 0.25f;
        // }else if(rigidbody.velocity.y > 0  && !Input.GetButton("Jump")){
        //      animator.Play("Playing_Falling");
        //     rigidbody.gravityScale = lowJumpMultiplier;
        // }
        // else if(rigidbody.velocity.y < 0f){
        //     animator.Play("Playing_Falling");
        //     rigidbody.gravityScale = fallMultiplier; 
        // } 
        // else {
        //    rigidbody.gravityScale = 1;
        // }

        animator.SetFloat("Speed",Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat("ySpeed",rigidbody.velocity.y);
        
      
    }

    void checkWallsAndFloor(){
         if((Physics2D.Linecast(transform.position, wallCheckR.position, 1 << 10) ||
        Physics2D.Linecast(transform.position, wallCheckL.position, 1 << 10)) && !onGround){
            onWall = true;
        }
        else{
            onWall = false;
        }
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
           Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
           Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")))
           {
            onGround = true;
            jumpFrameCounter = jumpFrames;
            animator.SetBool("onGround",onGround);
        }
        else {
            onGround = false;
            animator.SetBool("onGround",onGround);
        }
        if(runInput && (!onWall && !onGround)){
            rigidbody.velocity = new Vector2(-direction.x*runSpeed,rigidbody.velocity.y);
        }else if(runInput && !onWall){
            rigidbody.velocity = new Vector2(-direction.x*runSpeed,rigidbody.velocity.y);

        }else if(onGround){
            rigidbody.velocity = new Vector2(0,rigidbody.velocity.y);
        }

    }
    void setTrailColor(){
        if(onGround && (!onWall))color = Color.red;
        if(!onGround && !onWall)color = Color.green;
        if(!onGround && onWall)color = Color.blue;
    }
}
