using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class FallTriggerScript : MonoBehaviour
{
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private GameObject camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        camera.GetComponent<Animator>().enabled = false;
        collision.transform.position = new(xPos, yPos);
        camera.GetComponent<CinemachinePositionComposer>().Composition.ScreenPosition = new(0, 0.4f);
        StartCoroutine(FixCameraRoutine());
    }

    private IEnumerator FixCameraRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        camera.GetComponent<CinemachinePositionComposer>().Composition.ScreenPosition = new(0, 0);
        camera.GetComponent<Animator>().enabled = true;
    }
}
