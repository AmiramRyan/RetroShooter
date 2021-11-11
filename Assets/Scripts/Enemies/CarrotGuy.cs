using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGuy : MonoBehaviour
{
    [SerializeField] private float activeRange;
    public GameObject target;
    public Animator myAnim;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < activeRange)
        {
            myAnim.SetTrigger("playerInRange");
        }
    }
}
