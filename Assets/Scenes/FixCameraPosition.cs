using UnityEngine;
using Unity.Cinemachine;
using Unity.VisualScripting;
using System.Collections;

public class FixCameraPosition : MonoBehaviour
{
    private CinemachinePositionComposer camera;

    private void Start()
    {
        camera = GameObject.Find("CinemachineCamera").GetComponent<CinemachinePositionComposer>();
    }

    public void FixCameraPos()
    {
        camera.Composition.ScreenPosition = new(0, 0.4f);
        StartCoroutine(FixCameraRoutine());
    } 
   

    private IEnumerator FixCameraRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        camera.Composition.ScreenPosition = new(0, 0);
    }
}
