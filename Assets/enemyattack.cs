using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyattack : MonoBehaviour
{
    public GameObject image;

void Start(){
       
     }
 

 void OnTriggerEnter(Collider other)
{
if (other.gameObject.name.Contains("amu"))
{
  Debug.Log("You lose");
  //image.SetActive(true);
}
}


/*    public float Range = 1.1f;
    public Transform attackpoint;
    public LayerMask PlayerLayer;
    bool playerCheck;
    public float damage = 20f;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         playerCheck = Physics.CheckSphare(attackpoint.position, PlayerLayer);  
         if(playerCheck == true){
             attack();
         }
    }
    void attack(){

        FindObjectOfType<PlayerHealth>().Health -= damage;

        if(FindObjectOfType<PlayerHealth>().Health <= 0)
        {
            FindObjectOfType<PlayerHealth>().GameOver();
        }
    }
}*/
}