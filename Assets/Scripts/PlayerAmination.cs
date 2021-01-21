using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmination : MonoBehaviour
{
    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Sprint", true);
        }
        else
        {
            animator.SetBool("Sprint", false);
        }
        Preparation();

    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    
    public void Preparation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Preparation", true);
            GetComponent<SpellCast>().PrepareSpell();
        }
        else if(!Input.GetMouseButton(1))
        {
            animator.SetBool("Preparation", false);
            GetComponent<SpellCast>().DestroySpell();
        }

        if (animator.GetBool("Preparation") && Input.GetMouseButtonDown(0))
            Cast();
    }

    public void Cast()
    {
        animator.SetTrigger("Cast");
        GetComponent<SpellCast>().ReleaseSpell();
    }
    

}
