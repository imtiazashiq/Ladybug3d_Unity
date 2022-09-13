using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class enemyfollow : MonoBehaviour
{

   public bool ReadyToExecute;
    public bool wasToRight;
    public bool wasToLeft;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
     
        done = false;
        ReadyToExecute = true;
        wasToRight = false;
        wasToLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!done)
        {
            Main();
        }
        
    }

    public void Main()
    {
        if(ReadyToExecute)
        {
            CheckSensors();
        //    Debug.Log("Checking Sensors...");
            ReadyToExecute = false;
        }
    }
    public IEnumerator MoveForward()
    {
       // Debug.Log("Moving forward...");
        for (int i = 0; i < 15; i++)
        {
            this.transform.position += (this.transform.forward / 15);
            yield return null;
        }
        SetReady();
    }
     public IEnumerator MoveRight()
    {
       // Debug.Log("Moving Right...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (this.transform.right / 18);
            yield return null;
        }
        SetReady();
    }

    public IEnumerator MoveLeft()
    {
      //  Debug.Log("Moving Right...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (-this.transform.right / 18);
            yield return null;
        }
        SetReady();
    }

    public IEnumerator TurnCW()
    {
       // Debug.Log("Turning -90");
      //  for (int i = 0; i < 180; i++)
      //  {
            this.transform.Rotate(new Vector3(0, -90, 0));
            yield return null;
      ///  }
         SetReady();
    }
    public IEnumerator TurnCWW()
    {
       // Debug.Log("Turning..180.");
      //  for (int i = 0; i < 180; i++)
      //  {
            this.transform.Rotate(new Vector3(0, 180, 0));
            yield return null;
      ///  }
         SetReady();
    }

    public void SetReady()
    {
        if (!ReadyToExecute)
            ReadyToExecute = true;
    }

    public void CheckSensors()
    {
        bool inFront = false;
        bool toRight = false;
        bool toLeft = false;
       

        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 0.7f))
        {
            //Debug.Log("There is something in front of me!");
            inFront = true;
        }
        if (Physics.Raycast(transform.position, this.transform.right, out hit, 0.7f))
        {
           // Debug.Log("There is something to the right of me!");
            toRight = true;
        }
        if (Physics.Raycast(transform.position, this.transform.right * -1, out hit, 0.7f))
        {
          //  Debug.Log("There is something in Left of me! hahhahahahhahahahahah");
           toLeft= true; 
        }
        
       if(inFront == false && toRight == false && toLeft ==false) //No walls around
        {
            if (wasToRight == false && wasToLeft == false)
            {
                
               StartCoroutine(MoveForward());
              //  Debug.Log("No walls to left or right sensed.");
                wasToRight = false;
                wasToLeft=false;

            }
            else if(wasToLeft == false && wasToRight== true)
            {
              transform.Rotate(0, -90, 0);
            StartCoroutine(MoveForward());
             
              //  Debug.Log("No walls to left or right sensed. There was previously a wall to right.");
                wasToRight = true;
                wasToLeft = false;
            }
            else if(wasToLeft == true && wasToRight== false)
            {
               transform.Rotate(0, 90, 0);
            StartCoroutine(MoveForward());
             //   Debug.Log("No walls to left or right sensed. There was previously a wall to right.aaaaa");
                wasToRight = false;
                wasToLeft = false;
            }
            else
            {
               StartCoroutine(TurnCW());
               
              //  Debug.Log("No walls to left or right sensed. There was previously a wall to right111111.");
                wasToRight = false;
                wasToLeft= false;
                //ReadyToExecute= true;
               
                
            }
            
        }
        else if(inFront == true && toLeft == false && toRight == false ) //Wall in front
        { transform.Rotate(0, 90, 0);
            StartCoroutine(MoveForward());
             /// turn 0
          //  Debug.Log("Wall in front sensed.");
            wasToRight = false;
            wasToLeft = false;
            ReadyToExecute= true;
        }
        else if (inFront == false && toRight == true && toLeft== true) //Wall to the right and left
        {
            StartCoroutine(MoveForward()); // move forward.
           // Debug.Log("Wall to the right and left only sensed.");
            wasToRight = true;
            wasToLeft = true;
            ReadyToExecute= false;
        }
         else if (toRight == false && toLeft == true && inFront== true) //Wall to the front and left
        {
            transform.Rotate(0, 90, 0);
            StartCoroutine(MoveForward());
            wasToLeft=true;
            wasToRight= false;
            ReadyToExecute= true;
        }
         else if (toLeft == false && toRight == true  && inFront== true ) //Wall to the front and right
        {
            transform.Rotate(0, -90, 0);
            StartCoroutine(MoveForward());
          //  Debug.Log("Wall to the left only sensed...................");
            wasToLeft=false;
            wasToRight= true;
            ReadyToExecute= true;
            
        }
        else if (toRight == false && toLeft == true && inFront== false) //Wall to the to all direction
        {
          transform.Rotate(0, 90, 0);
            StartCoroutine(MoveForward());
           // Debug.Log("Wall to the left only sensed.");
            wasToLeft=true;
            wasToRight= false;
            ReadyToExecute= false;
            
        }
         
        
        else
        {
            StartCoroutine(TurnCW()); // 180
           // Debug.Log("Wall to the left only sensed11111.");
            wasToLeft=true;
            wasToRight= false;
            ReadyToExecute = false;
            

            ////remaining front left , front right,//
           
        }
    }

    public void turnOff()
    {
        done = true;
    }
    
   

}
