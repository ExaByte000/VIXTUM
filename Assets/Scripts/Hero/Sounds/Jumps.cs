using UnityEngine;
using FMODUnity;
using UnityEngine.Audio;
using System.Collections;
using System;

public class Jumps : MonoBehaviour
{
    [SerializeField] private Jump jump;

    private string jumpUpLink = "event:/Tutorial_Jump_Up";
    private string jumpDownLink = "event:/Tutorial_Jump_Down";

    public string JumpUpLink { get { return jumpUpLink; } set { jumpUpLink = value; } }
    public string JumpDownLink { get { return jumpDownLink; } set { jumpDownLink = value; } }


    private bool previousGroundedState = true;

    public void PlayJumpUp()
    {
        RuntimeManager.PlayOneShot(jumpUpLink);
    }

    public void Update()
    {
        if (!previousGroundedState && jump.IsGrounded)
        {
            RuntimeManager.PlayOneShot(JumpDownLink);
        }
        previousGroundedState = jump.IsGrounded;
    }

}
