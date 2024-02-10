using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] float timeLeft;
    [SerializeField] GameObject button;
    private void Start()
    {
        if (DataHolder.startTimer == true)
        {
            button.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (DataHolder.startTimer == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                button.SetActive(true);
                DataHolder.startTimer = false;
            }
        }
    }
}
