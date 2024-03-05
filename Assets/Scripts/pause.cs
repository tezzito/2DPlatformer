using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private bool GameIsPause;
    private GameObject stop;

    // Update is called once per frame
    void Update()       
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                GameIsPause = false;
                Time.timeScale = 1f;
            }
            else
            {
                GameIsPause = true;
                Time.timeScale = 0f;    
            }
        }
    }
}
