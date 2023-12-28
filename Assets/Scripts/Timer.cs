using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float passedTime = 0;
    public TMP_Text timerText;
    public bool timerIsRunnig = true;
    private void Update()
    {
        if (!timerIsRunnig) return;
        passedTime += Time.deltaTime;
        timerText.text = passedTime.ToString("0.0");
    }
}
