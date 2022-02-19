using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollection : MonoBehaviour
{

    void Update(){

        transform.Rotate(0,0 ,-90*Time.deltaTime);
    }
   
    private void OnTriggerEnter(Collider other)
 {
     if (other.name == "amu") {
     coincounter.scorecount ++;
        Destroy (gameObject);
    }
    
 }
}
