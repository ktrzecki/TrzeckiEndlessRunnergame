using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    
    public Rigidbody2D Player;

    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Transform FeetPosition;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private float JumpTime = 0.3f;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private PlatformSpawner platformSpawner;
    [SerializeField] private CollectableSpawner collectableSpawner;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D playerCollider;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;
    private float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;

    


    //private bool isDoubleJump = false;


    // Update is called once per frame
    private void Update()
    {
      


        //making jump on ground
        //isGrounded = Physics2D.OverlapCircle(FeetPosition.position, groundDistance, groundlayer);
        if(Physics2D.OverlapCircle(FeetPosition.position, groundDistance, groundlayer) == true)
          {
            isGrounded = true;   
          }
        else
        {
            isGrounded = false;
        }
     

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            Player.velocity = Vector2.up * jumpForce;
            isJumping = true;
            animator.SetBool("isJumping", true);
            isGrounded = false;
            animator.SetBool("isJumping", false);

           
        }
        //length of jump
        if (isJumping == true && Input.GetButton("Jump")) 
        {
            if (jumpTimer < JumpTime)
            {
                Player.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
                Debug.Log(jumpTimer + JumpTime);

            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0f;

            //lets you adjust the box collider size
            //playerCollider.size = new Vector2(1, 0.5f);
        }

        if (Input.GetKeyDown("x") && isGrounded == true)
        {
            obstacleSpawner.pausedObstacles();
            platformSpawner.pausedPlatforms();
            collectableSpawner.pausedCollectables();
            obstacleSpawner.isPaused = true;
            platformSpawner.isPaused = true;
            collectableSpawner.isPaused = true;
            animator.SetBool("isCrouching", true);

        }
        if (Input.GetKeyUp("x") && isGrounded ==true)
        {
            obstacleSpawner.ResumeObstacles();
            platformSpawner.ResumePlatforms();
            collectableSpawner.ResumeCollectables();
            obstacleSpawner.isPaused = false;
            platformSpawner.isPaused = false;
            collectableSpawner.isPaused = false;
            animator.SetBool("isCrouching", false);
        }

        

}
    
    
    
}
