using FMODUnity;
using UnityEngine;

public class SpidersheepAttackSound: MonoBehaviour
{
    public void PlayAttack()
    {
        RuntimeManager.PlayOneShot("event:/Spider_attack");
    }
}
