using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject target;

    public void StartFadeInAnim()
    {
        target.SetActive(true);
        anim.SetTrigger("StartFade");
    }
}
