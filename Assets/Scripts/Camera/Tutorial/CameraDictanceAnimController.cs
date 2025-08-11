using UnityEngine;

public class CameraDictanceAnimController : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;

    public void StartDistanceAnim()
    {
        cameraAnimator.SetTrigger("StartAnim");
    }
}
