using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;

    public void BreakdownDoor()
    {
        animator.SetBool("break", true);
    }
}