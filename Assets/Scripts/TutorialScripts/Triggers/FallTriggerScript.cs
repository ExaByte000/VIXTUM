using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class FallTriggerScript : MonoBehaviour
{
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private CinemachinePositionComposer camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new(xPos, yPos);
        camera.Composition.ScreenPosition = new(0, 0.4f);
        StartCoroutine(FixCameraRoutine());
    }

    private IEnumerator FixCameraRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        camera.Composition.ScreenPosition = new(0, 0);
    }
}
