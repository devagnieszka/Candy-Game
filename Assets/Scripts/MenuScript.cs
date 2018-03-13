using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public static int difficulty;

    public void triggerMenu (int i)
    {
        switch (i)
        {
            default:
            case (0):
                difficulty = 0;
                SceneManager.LoadScene("level1");
              
                break;

            case (1):
                difficulty = 1;
                SceneManager.LoadScene("level1");
           
                break;
           
            case (2):
                difficulty = 2;
                SceneManager.LoadScene("level1");

                break;


            case (3):
                Application.Quit();


                break;

        }


    }
    

    
	
}
