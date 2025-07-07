using FMODUnity;
using UnityEngine;

public class Dashes : MonoBehaviour
{
    [SerializeField] private Dash dash;

    private bool previousDashState = true;
    public void Update()
    {
        if (!previousDashState && dash.IsDashing)
        {
            RuntimeManager.PlayOneShot("event:/Tutorial_Dash");
        }
        previousDashState = dash.IsDashing;
    }
}
