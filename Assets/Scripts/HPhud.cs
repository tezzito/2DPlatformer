using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPhud : MonoBehaviour
{
    public TMPro.TMP_Text HP;
    bool Un = false;
    int hp = 3;

    void Start()
    {
        HP.text = hp.ToString();
    }


    public void UnSec()
    {
        Un = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger" && Un == false)
        {
            if (hp == 1)
            {
                SceneManager.LoadScene(3);
            }
            hp--;
            Un = true;
            HP.text = hp.ToString();
            Invoke("UnSec", 0.5f);
            Debug.Log("AHHAHAHHAHA");
        }
    }

}