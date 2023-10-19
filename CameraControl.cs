using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField]
    private float x, y, z;

    Vector3 cameraOrientationVector;

    public Animator animator;
    bool ShakingAlready = false;

    private void Start()
    {
       cameraOrientationVector = new Vector3(x, y, z);
    }
    

    void LateUpdate()
    {

        transform.position = playerTransform.position + cameraOrientationVector;

    }

    public void ShakeScreen()
    {
        StartCoroutine(Shake());
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

    IEnumerator Shake()
    {
        if (ShakingAlready == false)
        {
            animator.SetTrigger("Shake");
            ShakingAlready = true;
            yield return new WaitForSeconds(1);
            ShakingAlready = false;
        }
    }
}