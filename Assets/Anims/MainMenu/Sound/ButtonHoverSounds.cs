using FMODUnity;
using UnityEngine;

public class ButtonHoverSounds : MonoBehaviour
{
    public void PlayPaperHoverSound()
    {
        RuntimeManager.PlayOneShot("event:/Main_Menu_Hover");
    }
}
