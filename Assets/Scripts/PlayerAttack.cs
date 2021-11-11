using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform gunTrans;
    private bool canShoot;
    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetButton("shoot") && canShoot)
        {
            canShoot = false;
            StartCoroutine(attackCo());
            //shoot stuff
            GameObject projectile = Instantiate(projectilePrefab, gunTrans.position, Quaternion.identity)as GameObject;
            projectile.GetComponent<GenericProjectile>().Fire(new Vector2(transform.localScale.x,0));
        }
    }

    private IEnumerator attackCo() //cooldown timer
    {
        yield return new WaitForSeconds(attackCooldown);
        canShoot = true;
    }
}
