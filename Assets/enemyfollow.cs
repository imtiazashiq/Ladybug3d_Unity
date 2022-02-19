using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class enemyfollow : MonoBehaviour
{
 /*   public bool ReadyToExecute;
    public bool wasToRight;
    public bool wasToLeft;
    public bool done;
    private int moveDir;
    private int curDir; // You can store your current direction here but I'm not using it in this code. This is how you would do it though
    private bool canChange;
    private Rigidbody2D enemyRb;
     private Vector3 moveDirection;
 private float enemySpd = 5f;
     // Start is called before the first frame update
    
    void Start()
    {
        done = false;
        ReadyToExecute = true;
        wasToRight = false;
        wasToLeft = false;

        moveDir = Random.Range(1, 5);
      //  moveDirection= Vector3.forward; // 1-4  -- 1=down 2=left 3=right 4=up
       
       
 
        canChange = true; // Allows the enemy to pick a random direction when true
    }

    // Update is called once per frame
    void Update()
    {
        if(!done)
        {
            Main();
        }
       

    }
    private void FixedUpdate()
    {
        enemyRb.MovePosition(enemyRb.position + moveDirection, enemySpd * Time.fixedDeltaTime);
    }
    public void Main()
    {
        if(ReadyToExecute)
        {
            CheckSensors();
            Debug.Log("Checking Sensors...");
            ReadyToExecute = false;
        }
    }
    public IEnumerator MoveForward()
    {
       // Debug.Log("Moving forward...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (this.transform.forward / 18);
            yield return null;
        }
        SetReady();
    }
  /*   public IEnumerator MoveRight()
    {
       //Debug.Log("Moving forward...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (this.transform.right / 18);
            yield return null;
        }
        SetReady();
    }

    public IEnumerator MoveLeft()
    {
     //  Debug.Log("Moving forward...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (-this.transform.right / 18);
            yield return null;
        }
        SetReady();
    }
    public IEnumerator moveBack()
    {
     //  Debug.Log("Moving forward...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (-this.transform.forward / 18);
            yield return null;
        }
        SetReady();
    }

*/
 /*   public IEnumerator TurnCW()
    {
        Debug.Log("Turning -90");
      //  for (int i = 0; i < 180; i++)
      //  {
            this.transform.Rotate(new Vector3(0, 90, 0));
            yield return null;
      ///  }
         SetReady();
    }
    public IEnumerator TurnCWW()
    {
        Debug.Log("Turning..180.");
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
        bool todown= false;
       

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
          if (Physics.Raycast(transform.position, this.transform.forward * -1, out hit, 0.7f))
        {
          //  Debug.Log("There is something in Left of me! hahhahahahhahahahahah");
           todown= true;
        }
    
      if (todown == false && toLeft== false && toRight == false & inFront == false)
        {
            moveDir = Random.Range(1, 5); // 1-4--1=down 2=left 3=right 4=up
            if (moveDir < 1 || moveDir > 4)
            {
                while (moveDir < 1 || moveDir > 4)
                {
                    moveDir = Random.Range(1, 5);
                    if (moveDir == curDir)
                    {
                        moveDir = Random.Range(1, 5);
                    }
                }  // End of While loop
            }
        else if(todown == true && toLeft== true && toRight == false & inFront == true)
        {
            moveDir = Random.Range(1, 5); // 1-4  -- 1=down 2=left 3=right 4=up
            while(moveDir < 1 || moveDir > 4 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }// End of While loop
        }// End of Right path closed all other paths open Statement
 
        // Cannot move Left or Right
        else if(todown == true && toLeft== false && toRight == false & inFront == true)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 4 || moveDir == 2 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }// End of While Loop
        }// End of Up or Down path open IF Statement
 
        // Can only move up
        else if(todown == false && toLeft== false && toRight == false & inFront == true)
        {
            moveDir = 4;
        } // End of Up movement only IF statement
 
        // Can only move Up or Right
        else if(todown == false && toLeft== false && toRight == false & inFront == true)
        {
            moveDir = Random.Range(1,5);// 1-4  -- 1=down 2=left 3=right 4=up
            while (moveDir < 3 || moveDir > 4) // can only be 3 or 4
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of Up or Right Movement IF statement
 
        // Can move Left, Right or Up
        else if(todown == false && toLeft== true && toRight == true & inFront == true)
        {
            moveDir = Random.Range(1, 5);
            while (moveDir > 4 || moveDir < 2) // Cannot be 1
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of Left,Right,Up IF statement
 
        // Can only move Left or Up
        else if(todown == false && toLeft== true && toRight == false & inFront == true)
        {
            moveDir = Random.Range(1, 5); // 1 = down 2 = left 3 = right 4 = up
            while (moveDir < 1 || moveDir > 4 || moveDir == 1 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of Left/Up IF statement
 
        // Cannot move left
        else if(todown == true && toLeft== false && toRight == true & inFront == true)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 4 || moveDir == 2)
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of Down, Right, Up IF statement
 
        // Can move any direction except Up
        else if(todown == true && toLeft== true && toRight == true & inFront == false)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of any direction BUT Up statement
 
        // Cannot move Right or Up
        else if(todown == true && toLeft== true && toRight == false & inFront == false)
        {
            moveDir = Random.Range(1, 5); // 1 = down 2 = left 3 = right 4 = up
            while(moveDir < 1 || moveDir > 2)
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of can't move Right or Up statement
 
        // Cannot move Left or Up
        else if (todown == true && toLeft== false && toRight == true & inFront == false)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }// End of Can't move Left or Up statement
 
        // Can only move Down
        else if (todown == true && toLeft== false && toRight == false & inFront == false)
        {
            moveDir = 1;
        } // End of can only move Down statement
 
        // Can only move Left
        else if (todown == false && toLeft== true && toRight == false & inFront == false)
        {
            moveDir = 2;
        } // End of can only move Left statement
 
        // Can only move Right
        else if (todown == false && toLeft== false && toRight == true & inFront == false)
        {
            moveDir = 3;
        } // End of can only move Right
 
        else { moveDir = 4; } // In case we forgot a scenario or since we didn't add move up only, we'll move Up by default
    }
 
    void MoveLeft()
    {
        curDir = 2;
        enemyRb.transform.eulerAngles = new Vector3(0, 0, -90);
        moveDirection = Vector2.left;
    }
 
    void MoveRight()
    {
        curDir = 3;
        enemyRb.transform.eulerAngles = new Vector3(0, 0, 90);
        moveDirection = Vector2.right;
    }
 
    void MoveUp()
    {
        curDir = 4;
        enemyRb.transform.eulerAngles = new Vector3(0, 0, 180);
        moveDirection = Vector2.up;
    }
 
    void MoveDown()
    {
        curDir = 1;
        enemyRb.transform.eulerAngles = new Vector3(0, 0, 0);
        moveDirection = Vector2.down;
    }
    
    void StopMoving()
    {
        moveDirection = Vector2.zero;
     
    }
  /*  void MovementHandler()
    {
        if (moveDir == 1)
        {
            if ( !todown == true)
            {
                MoveDown();
            }
            else { CheckSensors(); }
        }
        else if (moveDir == 2)
        {
            if (!toLeft == true)
            {
                MoveLeft();
            }
            else { CheckSensors(); }
        }
        else if (moveDir == 3)
        {
            if (!toRight == true)
            {
                MoveRight();
            }
            else { CheckSensors(); }
        }
        else if (moveDir == 4)
        {
            if (!inFront == true)
            {
                MoveUp();
            }
            else { CheckSensors(); }
        }
 
        if (canChange == true)
        {
            StartCoroutine(RandomMovement());
        }
    }
 */
 /*   IEnumerator RandomMovement()
    {
        canChange = false;
        var timer = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(timer);
        CheckSensors();
        yield return new WaitForSeconds(0.5f);
        canChange = true;
    }
}
 } // End of all paths open IF statement
        
      /* if(inFront == false && toRight == false && toLeft ==false) //No walls around
        {
            if (wasToRight == false && wasToLeft == false)
            {
                
                StartCoroutine(MoveForward());
                Debug.Log("No walls to left or right sensed.");
                wasToRight = false;
                wasToLeft=false;
                ReadyToExecute=true;

            }
            else if(wasToLeft == false && wasToRight== true)
            {
             transform.Rotate(0, -90, 0);
            StartCoroutine(MoveForward());
               
             
                Debug.Log("No walls to left or right sensed. There was previously a wall to right.");
                wasToRight = true;
                wasToLeft = false;
            }
            else if(wasToLeft == true && wasToRight== false)
            {
                StartCoroutine(MoveForward());
                Debug.Log("No walls to left or right sensed. There was previously a wall to right.aaaaa");
                wasToRight = false;
                wasToLeft = false;
                                ReadyToExecute=false;

            }
            else
            {
               StartCoroutine(TurnCW());
               
                Debug.Log("No walls to left or right sensed. There was previously a wall to right111111.");
                wasToRight = false;
                wasToLeft= false;
               
               
                
            }
            
        
        else if(inFront == true && toLeft == false && toRight == false ) //Wall in front
        {
            
            transform.Rotate(0, 90, 0);

            StartCoroutine(MoveForward()); /// turn 0
            Debug.Log("Wall in front sensed.");
            wasToRight = false;
            wasToLeft = false;
            ReadyToExecute= true;
        }
        else if (inFront == false && toRight == true && toLeft== true) //Wall to the right and left
        {
            StartCoroutine(MoveForward()); // move forward.
            Debug.Log("Wall to the right and left only sensed.");
            wasToRight = true;
            wasToLeft = true;
            ReadyToExecute= false;
        }
         else if (toRight == false && toLeft == true && inFront== true) //Wall to the front and left
        {
            transform.Rotate(0, 90, 0);
            StartCoroutine(MoveForward());
            
            Debug.Log("Wall to the right ");
         
            wasToLeft=true;
            wasToRight= false;
            ReadyToExecute= true;
        }
       
         else if (toLeft == false && toRight == true  && inFront== true ) //Wall to the front and right
        {
            transform.Rotate(0, -90, 0);
            StartCoroutine(MoveForward());
            
            Debug.Log("Wall to the left only sensed...................");
            wasToLeft=false;
            wasToRight= true;
            ReadyToExecute= true;
            
        }
        else
        {

            StartCoroutine(TurnCW());
            Debug.Log("Wall to the left only sensed11111.");
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
    
       void OnTriggerStay(Collider other)
    {
       //print("colliding with: " + other.gameObject.name);
   if(other.gameObject.tag == "Player")
        { 

         print("jhaahhaa");

        }
       
*/


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
    
     /*  void OnTriggerStay(Collider other)
    {
       //print("colliding with: " + other.gameObject.name);
   if(other.gameObject.tag == "Player")
        { 
           // SceneManager.LoadScene(2);
        
  print("jhaahhaa");

        }
       */


}
/*public float moveForce = 0f;
private Rigidbody rb;
public Vector3 moveDir;
public LayerMask whatIsWall;
public float maxDistFromWall = 0f;

void Start (){
    rb = GetComponent<Rigidbody>();
    moveDir = ChooseDirection();
                transform.rotation = Quaternion.LookRotation(moveDir);


}
    void Update(){
        rb.velocity = moveDir * moveForce;

        if(Physics.Raycast(transform.position, transform.forward, maxDistFromWall, whatIsWall))
        {
            moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

}

Vector3 ChooseDirection()
{
    System.Random ran = new System.Random();
    int i = ran.Next (0, 3);
    Vector3 temp = new Vector3();

    if(i == 0)
    {
        temp= transform. forward;

    }
    else if (i== 1)
    {
        temp = -transform.forward;
    }
    else if (i== 2)
    {
        temp = transform.right;
    }
    else if (i== 3)
    {
        temp = -transform.right;
    }
    return temp;
} */


  
   /*  public bool ReadyToExecute;
    public bool wasToRight;
    public bool done;
    public bool wasToLeft;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        ReadyToExecute = true;
        wasToRight = false;
        wasToLeft= false;
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
            Debug.Log("Checking Sensors...");
            ReadyToExecute = false;
        }
    }
    public IEnumerator MoveForward()
    {
        Debug.Log("Moving forward...");
        for (int i = 0; i < 18; i++)
        {
            this.transform.position += (this.transform.forward / 18);
            yield return null;
        }
        SetReady();
    }

    public IEnumerator TurnCCW()
    {
        Debug.Log("Turning..qqqqq.");
       // for (int i = 0; i < 180; i++)
       // {
            this.transform.Rotate(new Vector3(0, 90, 0));
            yield return null;
      //  }
        SetReady(); 
    }

    public IEnumerator TurnCW()
    {
        Debug.Log("Turning...");
      //  for (int i = 0; i < 180; i++)
      //  {
            this.transform.Rotate(new Vector3(0, -90, 0));
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
            Debug.Log("There is something in front of me!");
            inFront = true;
        }
        if (Physics.Raycast(transform.position, this.transform.right, out hit, 0.7f))
        {
            Debug.Log("There is something to the right of me!");
            toRight = true;
        }
         if (Physics.Raycast(transform.position, -this.transform.right, out hit, 0.7f))
        {
            Debug.Log("There is something to the right of me!");
            toLeft = true;
        }
        if(inFront == false && toRight == false) //No walls around
        {
            if (wasToRight == false)
            {
                {
                StartCoroutine(MoveForward());
                Debug.Log("No walls to left or right sensed.");
            }
            }
            else
            {
                StartCoroutine(TurnCW());
                Debug.Log("No walls to left or right sensed. There was previously a wall to right.");
                wasToRight = false;
            }
        }
        else if(inFront == true) //Wall in front
        {
            StartCoroutine(TurnCCW());
            Debug.Log("Wall in front sensed.");
            wasToRight = false;
        }
        else if (inFront == false && toRight == true) //Wall to the right only
        {
            StartCoroutine(MoveForward());
            Debug.Log("Wall to the right only sensed.");
            wasToRight = true;
        }
        else{
             
            this.transform.Rotate(new Vector3(0, 90, 0));
        }
    }

    public void turnOff()
    {
        done = true;
    }
    
       void OnTriggerStay(Collider other)
    {
       //print("colliding with: " + other.gameObject.name);
   if(other.gameObject.tag == "Player")
        { 
        
                     
             
                        print("jhaahhaa");

        }
    } 
 } */
 /*  Rigidbody2D rb;

    // movement speed
    [SerializeField] float speed;

    // possible movent directions
    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 1;

    // doesn't have to be serialized
    [SerializeField] Vector2 currentDir;

    // how far to look ahead
    [SerializeField] float rayDistance;

    // which layers to raycast for
    [SerializeField] LayerMask rayLayer;
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start moving in a directions
        currentDir = directions[directionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // raycast
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        // visably debug the ray
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        // if walls and pacman layer are selected, will return true for either
        if(hit2D.collider != null)
        {
            // check if wall ahead
            if (hit2D.collider.gameObject.CompareTag("wall"))
            {
                ChangeDirection();
                print("pacman ahead!");
            }

            // check if pacman ahead
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                // deal damage;
                print("pacman ahead!");
            }
        }
    }


    void ChangeDirection()
    {
        // randomly select between -1 and 1;
        directionIndex += Random.Range(0, 2) * 2 - 1;

        // keeps index from exceeding 3
        int clampedIndex = directionIndex % directions.Length;

        // keep index positive
        if(clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        // temporary freeze movement before set the new direction
        rb.velocity = Vector2.zero;

        // set the current direction from the directions array
        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {
        // move in current direction
        rb.AddForce(currentDir * speed);
    }
 }
 */
 
 
    
   
/*
 public Transform target;//set target from inspector instead of looking in Update
    public float speed;
    public float distance;
    public float agroRange;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < agroRange) //Agro range
        {  //rotate to look at the player
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
        }

        if (Vector3.Distance(transform.position, target.position) < agroRange) //Agro range
        {   //move towards the player
            if (Vector3.Distance(transform.position, target.position) > distance)
            {//move if distance from target is greater than distance
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }
} */
/*
 
*/