using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieProjectile : GenericProjectile
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDmg();
            Destroy(this.gameObject);
        }
    }
}
