using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x,transform.position.y,transform.position.z);
    }
}
