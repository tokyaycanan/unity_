using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odaKontrol : MonoBehaviour
{
    private Animator animator;
    private Animator hataAnimator;

    void Start()
    {
        animator = GameObject.Find("kayitP").GetComponent<Animator>();
    }
    public void olusturB()
    {
        animator.SetBool("kaydet", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
