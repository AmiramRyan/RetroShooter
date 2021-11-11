using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizy : MonoBehaviour
{
    private bool isMoving;
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> points;
    private int index;
    private Transform currentPoint;
    void Start()
    {
        isMoving = true;
        currentPoint = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, currentPoint.position) > 0.01f)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
                myRb.MovePosition(temp);
            }
            else if (index == 1)
            {
                index = 0;
                currentPoint = points[index];
                transform.localScale = new Vector3(transform.localScale.x *-1,transform.localScale.y,transform.localScale.z);
            }
            else
            {
                index = 1;
                currentPoint = points[index];
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDmg();
        }
    }

}
