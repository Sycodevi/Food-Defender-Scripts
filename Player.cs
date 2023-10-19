using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    public Animator animator;
    public VisualEffect AttackVFX;
    public float VFXTimer = 0.5f;
    bool Attacking = false;

    private void Awake()
    {
        Time.timeScale = 1;
        gameObject.GetComponent<Rigidbody>().sleepThreshold = 0;
    }
    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    public bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Triggered Entered by " + other.name);
    //    if (other.tag == "Enemy")
    //    {
    //        Debug.Log("Initiate Attack");
    //        InitiateAttack();
    //    }
    //}
    public void InitiateAttack()
    {
        Debug.Log("Attack Initiated");
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("2H_Melee_Attack_Spin") && Attacking == false)
        {
            Debug.Log("Animation");
            Attacking = true;
            StartCoroutine(AttackTimer());
        }
    }
    IEnumerator AttackTimer()
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("AttackTrigger");
        yield return new WaitForSeconds(VFXTimer);
        AttackVFX.Play();
        yield return new WaitForSeconds(.5f);
        animator.SetBool("isAttacking", false);
        Attacking = false;
    }
}
public class ATTACKVFXENABLE
{

}
