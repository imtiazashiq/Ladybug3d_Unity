using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winscript : MonoBehaviour
{   
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Coin");
if (enemies == null || enemies.Length == 0)
     UnityEngine.SceneManagement.SceneManager.LoadScene(2);
}
}