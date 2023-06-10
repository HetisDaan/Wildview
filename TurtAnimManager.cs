using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtAnimManager : MonoBehaviour
{
    public Animator mAnimator;
    
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            mAnimator.CrossFade("turtleRunning", 1); 
        }   
    }
    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            mAnimator.CrossFade("STurtle_Idle_Anim", 1);
        }
    }
}


