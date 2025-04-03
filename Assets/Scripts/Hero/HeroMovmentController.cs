using UnityEngine;


public class HeroMovmentController : MonoBehaviour
{
    private MovmentBase _moveReqest;
    private MovmentBase _moveLogic;

    public void Inject(MovmentBase move)
    {
        _moveReqest = move;
    }

    private void Update()
    {
        if (_moveReqest != null)
        {
            _moveReqest.ActionRequest(Input.GetAxisRaw("Horizontal"));
            _moveLogic = _moveReqest;
            _moveReqest = null;
        }
    }

    private void FixedUpdate()
    {
        if (_moveLogic != null)
        {
            _moveLogic.ActionLogic();
            _moveLogic = null;
        }
            
    }
}
