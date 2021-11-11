using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : GenericProjectile
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Solid"))
        {
            Destroy(this.gameObject);
        }
    }
}
