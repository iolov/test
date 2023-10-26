using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuMAnage : MonoBehaviour
{
    public void ScenesManegTo0()
    {
        SceneManager.LoadScene(0);
    }
    public void ScenesManegTo1()
    {
        SceneManager.LoadScene(1);
    }
    public void QUIT()
    {
        Application.Quit();
    }
}
