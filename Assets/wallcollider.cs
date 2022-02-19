using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcollider : MonoBehaviour
{    
   
 
private void OnTriggerStay(Collider other)
    {
         if (other.name == "amu"){
             Debug.Log("hit");
     
    }
    }
    private void OnTriggerExit(Collider other)
    {
       
    }
}