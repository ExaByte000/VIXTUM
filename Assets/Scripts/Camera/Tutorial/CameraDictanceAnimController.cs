using UnityEngine;

public class CameraDictanceAnimController : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;

    public void StartDistanceAnim()
    {
        cameraAnimator.enabled = true;
        cameraAnimator.SetTrigger("StartAnim");
    }
}
