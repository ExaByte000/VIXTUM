using FMODUnity;
using UnityEngine;

public class FirstAttack : MonoBehaviour
{
    public void PlayAttack()
    {
        RuntimeManager.PlayOneShot("event:/Sword_Attack");
    }
}
