using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    float velocity= 0.0f;
    public float acceleration = 0.3f;
    public float deceleration = 0.5f;
    int VelocityHash;
 //   int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
      
    }

    // Update is called once per frame
    void Update()
    {
       
        bool forwardPressed= Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s");
       

        if (forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
 }
        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
 }
         if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
 }

    animator.SetFloat(VelocityHash, velocity);
    }
}