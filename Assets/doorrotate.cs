using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorrotate : MonoBehaviour
{

 private bool open= false;
public float doorOpenAngle = 90f;
public float doorCloseAngle = 0f;
public GameObject obj;
public float storeY;



private void OnTriggerEnter(Collider col)
{
    door();
}
public void ChangeDoorState()
{
    open = !open;
}
    void Update(){

    storeY = obj.transform.eulerAngles.y;
    



    }
   private void door(){
    if (storeY <= 0){
    Quaternion newRotation = Quaternion.Euler(0, doorOpenAngle, 0);
    transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, 10f);
    }
    else 
    {
        Quaternion newRotation = Quaternion.Euler(0, doorCloseAngle, 0);
    transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, 10f);
    }



    }
}






/* public bool open = false;
public float doorOpenAngle = 90f;
public float doorCloseAngle = 0f;
public float smooth = 10f;



    void Start()
    {
        
    }
   
    
  //public void ChangeDoorState()
//{
//open = !open;
//}

    // Update is called once per frame
    void Update()
    {
/*if(open) //open == true
{
Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
}
else
{
Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
}
}*/




