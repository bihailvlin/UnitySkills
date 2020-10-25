using UnityEngine;
using System.Collections;

public class GirlAnimationControl : MonoBehaviour
{
    public Transform[] transforms;
    private Animator[] animator;

    private string currentState = "";
    void Start()
    {
        animator = new Animator[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            animator[i] = transforms[i].GetComponent<Animator>();
        }
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Base Layer.Jump3"))
        {
            for (int j = 0; j < animator.Length; j++)
            {
                animator[j].SetBool("Jump", false);
            }
        }
    }
    public void SetStand()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", true);
            animator[j].SetBool("Idle", false);
            animator[j].SetBool("Jump", false);
            animator[j].SetBool("Walk", false);
            animator[j].SetBool("Run", false);
            animator[j].SetBool("Sleep", false);
        }
    }

    public void SetIdle()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", false);
            animator[j].SetBool("Idle", true);
            animator[j].SetBool("Jump", false);
            animator[j].SetBool("Walk", false);
            animator[j].SetBool("Run", false);
            animator[j].SetBool("Sleep", false);
        }
    }

    public void SetJump()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", false);
            animator[j].SetBool("Idle", false);
            animator[j].SetBool("Jump", true);
            animator[j].SetBool("Walk", false);
            animator[j].SetBool("Run", false);
            animator[j].SetBool("Sleep", false);
        }
    }
    public void SetWalk()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", false);
            animator[j].SetBool("Idle", false);
            animator[j].SetBool("Jump", false);
            animator[j].SetBool("Walk", true);
            animator[j].SetBool("Run", false);
            animator[j].SetBool("Sleep", false);
        }
    }


    public void SetRun()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", false);
            animator[j].SetBool("Idle", false);
            animator[j].SetBool("Jump", false);
            animator[j].SetBool("Walk", false);
            animator[j].SetBool("Run", true);
            animator[j].SetBool("Sleep", false);
        }
    }


    public void SetSleep()
    {
        AnimatorStateInfo stateInfo = animator[0].GetCurrentAnimatorStateInfo(0);
        for (int j = 0; j < animator.Length; j++)
        {
            animator[j].SetBool("Stand", false);
            animator[j].SetBool("Idle", false);
            animator[j].SetBool("Jump", false);
            animator[j].SetBool("Walk", false);
            animator[j].SetBool("Run", false);
            animator[j].SetBool("Sleep", true);
        }
    }

}
