using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private bool GameIsPause;
    private GameObject stop;
    // Start is called before the first frame update
    void Start()
    {
        stop = GameObject.Find("Canvas");
        stop.SetActive(false);
    }

    // Update is called once per frame
    void Update()       
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                GameIsPause = false;
                stop.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                GameIsPause = true;
                stop.SetActive(false);
                Time.timeScale = 0f;    
            }
        }
    }
}
