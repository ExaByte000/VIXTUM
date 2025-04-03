using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Footsteps : MonoBehaviour
{
    public void PlayFootsteps()
    {
        RuntimeManager.PlayOneShot("event:/FootstepsInTutorial");
    }

}
