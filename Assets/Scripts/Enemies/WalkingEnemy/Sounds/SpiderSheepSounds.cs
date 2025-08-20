using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SpiderSeepSounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance spiderSounds;

    private const string eventPath = "event:/Spider_Effects";

    private float minDistance;
    private float maxDistance;

    private void Start()
    {
        spiderSounds = RuntimeManager.CreateInstance(eventPath);
        spiderSounds.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        spiderSounds.start();
    }

    private void OnDrawGizmosSelected()
    {
        
        if (string.IsNullOrEmpty(eventPath)) return;

        // Получаем EventDescription
        RuntimeManager.StudioSystem.getEvent(eventPath, out EventDescription eventDescription);
        if (eventDescription.isValid())
        {
            eventDescription.getMinMaxDistance(out minDistance, out maxDistance);

            Gizmos.color = Color.pink;
            Gizmos.DrawWireSphere(transform.position, minDistance);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, maxDistance);
        }
    }
    
}
