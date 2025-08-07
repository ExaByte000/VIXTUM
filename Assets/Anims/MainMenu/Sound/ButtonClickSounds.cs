using FMODUnity;
using UnityEngine;

public class ButtonClickSounds : MonoBehaviour
{
    public void PlayPaperClickSound()
    {
        RuntimeManager.PlayOneShot("event:/Main_Menu_Click");
    }
}
