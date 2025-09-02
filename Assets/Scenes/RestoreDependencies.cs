using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestoreDependencies : MonoBehaviour
{

    [SerializeField] private GameObject camera;

    private CinemachineConfiner2D CCamConfinder;

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
        Hero hero = GetComponent<Hero>();


        if (camera.TryGetComponent<CinemachineCamera>(out var CCam) && scene.name == "MainScene")
        {
            
            hero.Health = 10;
            transform.position = new(1.5f, transform.position.y, transform.position.z);
            CCam.ForceCameraPosition(transform.position, transform.rotation);
            CCamConfinder = CCam.GetComponent<CinemachineConfiner2D>();
            CCamConfinder.BoundingShape2D = GameObject.Find("CameraLimits").GetComponent<Collider2D>();
        }
    }

}

