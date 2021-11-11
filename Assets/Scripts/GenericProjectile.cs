using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dispawnTime;
    public Rigidbody2D projRb;

    public void Update() //destroy it after a set amount of sec
    {
        dispawnTime -= Time.deltaTime;
        if (dispawnTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Fire(Vector2 direction)
    {
        projRb.velocity = direction * speed;
    }
}

