using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public bool isRunnig = false;
    public bool isjumping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool( "isRunning", isRunnig );
        animator.SetBool( "isJumping", isjumping );
    }
}
