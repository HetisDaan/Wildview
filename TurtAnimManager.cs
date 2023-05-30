using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtAnimManager : MonoBehaviour
{
    public Collider mSphereCollider;
    public Animator mAnimator;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            mAnimator.SetBool("isInRange", true);
            Invoke("ResetIsInRange", 5f); // Call ResetIsInRange() after 5 seconds
        }
    }

    private void ResetIsInRange()
    {
        mAnimator.SetBool("isInRange", false);
        Debug.Log("5 seconden voorbij");
        
    }
}
