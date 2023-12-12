using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

    Animator playerAnimator;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
   
}
