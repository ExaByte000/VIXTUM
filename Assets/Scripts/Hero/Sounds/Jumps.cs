using UnityEngine;
using FMODUnity;
using UnityEngine.Audio;
using System.Collections;

public class Jumps : MonoBehaviour
{
    [SerializeField] private Jump jump;

    private bool previousGroundedState = true;

    public void PlayJumpUp()
    {
        RuntimeManager.PlayOneShot("event:/Jump_UP");
    }

    public void Update()
    {
        if (!previousGroundedState && jump.IsGrounded)
        {
            RuntimeManager.PlayOneShot("event:/Jump_DOWN");
        }
        previousGroundedState = jump.IsGrounded;
    }

}
