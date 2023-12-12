using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public Animator playerAnimator;


    private void Start()
    {
        RayController.OnCursorPositionChange += SetLookAt;
        playerAnimator.SetTrigger("Idle");
    }


    protected Vector3 localRot;
    protected float cameraDist = 10f;

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
            playerAnimator.SetTrigger("Run");
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position = new Vector3(player.transform.position.x - speed, player.transform.position.y, player.transform.position.z);
            playerAnimator.SetTrigger("Run");


        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + speed);
            playerAnimator.SetTrigger("Run");


        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - speed);
            playerAnimator.SetTrigger("Run");

        }

    }

    private void SetLookAt(Vector3 cursorPosition)
    {
        Vector3 targetPostition = new Vector3(cursorPosition.x,
                                     player.transform.position.y,
                                    cursorPosition.z);
        player.transform.LookAt(targetPostition);
    }



}
