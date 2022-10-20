using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 up= Vector3.zero,
    right= new Vector3(0,90,0),
    down =new Vector3(0,180,0),
    left = new Vector3(0,270,0),
    currentDirection= Vector3.zero;

    Vector3 nextPos, destination, direction;
    float speed= 5f;
    float rayLength= 1f;
    bool canMove=true;
    Animator anim;

    
    void Start()
    {
        currentDirection = up;
        destination = transform.position;
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
       if(canMove){
        Move();
      }
      else
      {
        Move();
      }
      
    }
    void FixedUpdate(){
    nextPos = Vector3.zero;

    }
    
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination,speed*Time.deltaTime);
      if(Input.GetKey(KeyCode.W))
        {
            nextPos = Vector3.forward;
            currentDirection=up;
            
            canMove=true;
            anim.SetBool("isRunning",true);
            

        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {   

            nextPos = Vector3.back;
            currentDirection=down;
            canMove=true;
                        anim.SetBool("isRunning",true);

        }
       else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            nextPos = Vector3.right;
            currentDirection=right;
            canMove=true;
                        anim.SetBool("isRunning",true);

        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            nextPos = Vector3.left;
            currentDirection=left;
            canMove=true;
            anim.SetBool("isRunning",true);
        }

         if(Vector3.Distance(destination,transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDirection;
            if(canMove)
            {
              if(Valid())
                {
             destination = transform.position + nextPos;
             direction= nextPos;
             canMove=false;
                }
            }
         }
    }
     
       
    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "enemy")
        {           
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
    
    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3 (0.1f, .25f, 0), transform.forward);
        RaycastHit hit;
        anim.SetBool("isRunning",false);
        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
        if (Physics.Raycast(myRay,out hit, rayLength))
        {
                if (hit.collider.tag == "wall")
                {
                   anim.SetBool("isRunning", false);
                    return false;   
                }
        }
        return true;  
    }
}