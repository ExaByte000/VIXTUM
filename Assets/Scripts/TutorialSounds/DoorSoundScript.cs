using FMODUnity;
using UnityEngine;

public class DoorSoundScript : MonoBehaviour
{
    public void PlayDoorSound()
    {
        RuntimeManager.PlayOneShot("event:/Door_Sleep");
    }
}
