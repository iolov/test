using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPhis : MonoBehaviour
{
    [SerializeField]  Transform player;
    Vector3 dir;

    void Start()
    {
        dir = transform.position- player.position;

    }

    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x,transform.position.y,dir.z+player.position.z);
        transform.position = newPos;
    }
}
