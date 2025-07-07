using UnityEngine;

public class EnemyInputSource : MonoBehaviour, ICommandMovmentSource
{
    private float direction = 0f;

    private void OnEnable()
    {
        DetectObjects.EnemyMovmentDetectorEvent += GetDirection;
    }
    private void OnDisable()
    {
        DetectObjects.EnemyMovmentDetectorEvent -= GetDirection;
    }

    public bool GetDashPressed()
    {
        return false;
    }

    public bool GetJumpPressed()
    {
        return false;
    }

    public float GetMoveInput()
    {
        return direction;
    }

    private void GetDirection(float direction)
    {
        this.direction = direction;
    }
}
