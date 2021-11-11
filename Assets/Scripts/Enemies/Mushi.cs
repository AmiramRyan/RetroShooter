using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushi : MonoBehaviour
{
    [SerializeField] private float activeRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projPoint;
    private bool canAttack;
    public GameObject target;
    public Animator myAnim;
    public float dist;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        myAnim.SetBool("playerInRange", PlayerInRange());
        if(PlayerInRange() && canAttack)
        {
            canAttack = false;
            //attack
            myAnim.SetTrigger("shoot");
            GameObject projectile = Instantiate(projectilePrefab, projPoint.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<GenericProjectile>().Fire(new Vector2(transform.localScale.x * -1, 0));
            StartCoroutine(attackCo());
        }
    }

    private bool PlayerInRange()
    {
        if (dist < activeRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator attackCo()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
