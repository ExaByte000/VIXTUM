using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Footsteps : MonoBehaviour
{
    public void PlayFootsteps()
    {
        RuntimeManager.PlayOneShot("event:/Footsteps_In_Tutorial");
    }

}
