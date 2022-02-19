using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

   [SerializeField] private float speed;

      Animator anim;
      private Vector3 moveDirection;
      CharacterController controller;
      private Rigidbody rb;
      public bool canMove=true;

     // private Vector3 velocity;
     // [SerializeField] private float gravity;
      //[SerializeField] private bool isGrounded;
      //[SerializeField] private float groundCheckDistance;
      //[SerializeField] private LayerMask groundMask;

     // private float jumpForce;
     //[SerializeField] private float jump1 = 5f;
      
       //   private SphereCollider col;




            


    void Start()
    {
      controller = GetComponent<CharacterController>();
       anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
             //   col = GetComponent<SphereCollider>();


  
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
      if(canMove){
        Move();
      runanim();
      print("move move moves");
      }
      else
      {
        Move();
      }
     
      
    


  //  if (Input.GetKey("t"))
  //      {
          // rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
//                      transform.Translate(Vector3.up * jump1);

   //     }   
   
    
    
  //     if (Input.GetKey("t") && isGrounded){
        //             isGrounded = false;

       //  rb.AddForce(0, jump1, 0);

        // transform.Translate (Vector3.up * jump1 * Time.deltaTime);
       //  jump();
//
   //    }     
   
    }
     
    
    
    private void Move()
     {
      // isGrounded=Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
    //  if(isGrounded && velocity.y < 0){
     //   velocity.y= -1f;
     // }

    //  if(isGrounded){
           if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
   {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed;
               controller.Move(moveDirection* Time.deltaTime);
                              transform.rotation = Quaternion.LookRotation( moveDirection );


    }
    else if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
    {
        moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical")) * speed ;
               controller.Move(moveDirection* Time.deltaTime);
                              transform.rotation = Quaternion.LookRotation( moveDirection );

    }
  // else if (Input.GetKey("t"))
    //    {
    //             moveDirection.y = jump1;
                          


      //   moveDirection.y -= gravity * Time.deltaTime;
        //       controller.Move(moveDirection* Time.deltaTime);
       //  Vector3 atas = new Vector3 (0,100,0);
         //   rb.AddForce(atas * speed);
         // rb.velocity = new Vector3(0f, jump1, 0f);
  
          // rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
               //      transform.Translate(Vector3.up * jump1);
                //     velocity.y -= gravity * Time.deltaTime;
             //  controller.Move(velocity * Time.deltaTime);
                      

     //  }   
       
      
    else
    {
        moveDirection= Vector3.zero;
               controller.Move(moveDirection* Time.deltaTime);
          //     velocity.y += gravity * Time.deltaTime;
            //   controller.Move(velocity * Time.deltaTime);


    }
      
    
     }
     private void runanim(){
 if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
         {
         anim.SetBool("isRunning",true);
       }
       else
      {
            anim.SetBool("isRunning", false);
            
       }      
     }
      
      /*  float moveZ= Input.GetAxis("Vertical");
        float movex= Input.GetAxis("Horizontal");

        moveDirection = new Vector3(movex, 0, moveZ);
 
         
       transform.rotation = Quaternion.LookRotation( moveDirection );
        moveDirection *= speed;
       controller.Move(moveDirection* Time.deltaTime);

*/
    
   void OnTriggerStay(Collider other)
    {
       //print("colliding with: " + other.gameObject.name);
   if(other.gameObject.tag == "wall")
        { 
        
                        anim.SetBool("isRunning", false);
                       canMove= false;
                     
                        print("jhaahhaa");

        }
    }
    void OnTriggerExit(Collider other)
    {
       print("collision exit");
               anim.SetBool("isRunning", true);
          canMove= true;

if(other.gameObject.tag == "wall")        {
        print("collision exit, return step offset to 0.5f");
        canMove= true;
        anim.SetBool("isRunning", true);
             
        }
        } 
 //   private void jump(){
  //        moveDirection.y = jump1;
   //       moveDirection.z = jump1;


    //     moveDirection.y -= gravity * Time.deltaTime;
    //    controller.Move(moveDirection* Time.deltaTime);   
       }
