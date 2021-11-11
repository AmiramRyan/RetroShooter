using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private int index;
    [SerializeField] private int invTime;
    [SerializeField] private Animator myAnim;
    private bool invisable;

    void Start()
    {
        invisable = false;
        currentHp = maxHp;
        for(int i=0; i<hearts.Count -1; i++)
        {
            hearts[i].SetActive(true);
        }
        index = 2;
    }

    public void TakeDmg()
    {
        if (!invisable)
        {
            currentHp -= 1;
            hearts[index].SetActive(false);
            index--;
            myAnim.SetBool("hit",true);
            if (currentHp <= 0)
            {
                //ded
                SceneManager.LoadScene("SampleScene");
            }
            StartCoroutine(InvFrameCo());
        }
    }

    private IEnumerator InvFrameCo()
    {
        invisable = true;
        yield return new WaitForSeconds(invTime);
        invisable = false;
        myAnim.SetBool("hit", false);
    }
}
