using UnityEngine;
using UnityEngine.Audio;

public class HeroAnimController : MonoBehaviour
{
   [SerializeField] private Jump jump;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("VerticalVelocity", GetComponentInParent<Rigidbody2D>().linearVelocityY);
        anim.SetBool("IsGrounded", jump.IsGrounded);
        
    }
}
