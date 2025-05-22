using UnityEngine;
using UnityEngine.Audio;

public class HeroAnimController : MonoBehaviour
{
    [SerializeField] private Jump jump;
    [SerializeField] private Dash dash;
    private Rigidbody2D rigidbody;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        anim.SetFloat("VerticalVelocity", rigidbody.linearVelocityY);
        anim.SetBool("IsGrounded", jump.IsGrounded);
        anim.SetBool("MovmentFalg", rigidbody.linearVelocityX != 0);
        anim.SetBool("IsDashing", dash.IsDashing);

    }
}
