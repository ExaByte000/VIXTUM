using UnityEngine;
using FMODUnity;

public class Footsteps : MonoBehaviour
{
   public void PlayFootsteps()
    {
        RuntimeManager.PlayOneShot("event:/Foot_Step_Sleep");
    }
}
