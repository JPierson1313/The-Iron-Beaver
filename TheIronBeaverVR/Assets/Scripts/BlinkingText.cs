using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public bool isActive;
    public GameObject startButton;

    public float countdownTimer;
    public float startNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = startNum;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        if(countdownTimer < 0)
        {
            isActive = !isActive;
            countdownTimer = startNum;
        }

        if(isActive)
        {
            startButton.SetActive(true);
        }
        if (!isActive)
        {
            startButton.SetActive(false);
        }
    }
}
