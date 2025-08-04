using FMODUnity;
using UnityEngine;

public class SpiderSheepWalkSound : MonoBehaviour
{
    public void PlayMovment()
    {
        RuntimeManager.PlayOneShot("event:/Spider_attack");
        
    }
}
