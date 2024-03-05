using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPhud : MonoBehaviour
{
    public TMPro.TMP_Text HP;
    public float LastDamage;
    public int hp = 3;

    void Start()
    {
        HP.text = hp.ToString();
        LastDamage = Time.time;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger" && Time.time - LastDamage > 0.5f)
        {
            if (--hp <= 0) SceneManager.LoadScene(0);
            LastDamage = Time.time;
            HP.text = hp.ToString();
        }
    }

}