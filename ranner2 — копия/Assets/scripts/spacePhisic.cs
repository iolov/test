using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spacePhisic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    Rigidbody rb;
    Vector3 dir;
    [SerializeField] float speed;
    int lineToMove = 1;
    [SerializeField] float lineDistanse;
    [SerializeField] bool GODMODE;
    [SerializeField] Animator anim;
    [SerializeField] float height;
    [SerializeField] float defoltHeith;
    bool isGroung;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {
        textMeshProUGUI.text = DataHolder.ScenScore.ToString();
        rb.MovePosition(rb.position + dir * Time.fixedDeltaTime);
        if (transform.position.z / 50 > speed)
        {
            speed = transform.position.z / 50;
        }
        else
        {
            dir.z = speed;
        }

    }
    private void Update()
    {
        if (anim != null) anim.speed = speed / 2;

        if (svipeController.swipeRight)
        {
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        if (svipeController.swipeLeft)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }
        if (svipeController.swipeUp)
        {
            muveUp();
        }
        if (svipeController.swipeDown)
        {
            muveDown();
        }

        Vector3 targPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targPos += Vector3.left * lineDistanse;
        }
        else if (lineToMove == 2)
        {
            targPos += Vector3.right * lineDistanse;
        }
        transform.position = targPos;
    }
    void muveUp()
    {
        if (transform.position.y < defoltHeith+height)
        {
            transform.position += new Vector3(0, height, 0);
        }
    }
    void muveDown()
    {
        if (transform.position.y > defoltHeith)
        {
            transform.position += new Vector3(0, -height, 0);
        }
    }
    private void lose()
    {
        SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGroung = true;
        if (collision.transform.tag == "barier" & GODMODE != true)
        {
            lose();
        }
    }
}
