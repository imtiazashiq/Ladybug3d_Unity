using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyactivtion : MonoBehaviour
{
  public GameObject self;
    public int time;
    
 
    void Start()
    {
        StartCoroutine (Hide ());
    }
 
    IEnumerator Hide()
    {   
        
        yield return new WaitForSeconds (time);
       self.SetActive (false);
    }
}