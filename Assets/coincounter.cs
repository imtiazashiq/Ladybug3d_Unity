using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincounter : MonoBehaviour
{   
    public static int scorecount = 0;
    Text scorecol;
   
    // Start is called before the first frame update
    void Start()
    {
      scorecol= GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
     //   text.text = coincollection.ToString();
       scorecol.text= "Score : " + scorecount;
       
 
       if(scorecount >= 120) //put the amount you want here
       {
           UnityEngine.SceneManagement.SceneManager.LoadScene(3);
       }
    }

}
