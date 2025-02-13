using UnityEngine;

public class HeroInjector : MonoBehaviour
{
    [SerializeField] private HeroMovmentController controller;
    private Dash dash;
    private Jump jump;
    public bool JumpPressed => Input.GetButtonDown("Jump");
    public bool DashPressed => Input.GetButtonDown("Dash");

    private void Awake()
    {
        dash = GetComponent<Dash>();
        jump = GetComponent<Jump>();
    }

    private void Update()
    {
        if(dash.IsDashing) return;
        if(jump.JumpReqest) return;

        if (JumpPressed)
            controller.Inject(jump);

        else if (DashPressed)
        {
            controller.Inject(dash);
        }

        else
            controller.Inject(GetComponent<Movement>());
    }
}
