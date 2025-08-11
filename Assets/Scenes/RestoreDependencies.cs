using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestoreDependencies : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject camera = GameObject.FindGameObjectWithTag("CinemachineCamera");
        SpriteRenderer hero = GetComponentInChildren<SpriteRenderer>();


        if (camera.TryGetComponent<CinemachineCamera>(out var CCam))
        {
            CCam.Follow = transform;
            CCam.LookAt = transform;
        }
        if(scene.name == "MainScene")
        {
            transform.position = new(88f, transform.position.y, transform.position.z);
        }
        
    }

}

