using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestoreDependencies : MonoBehaviour
{

    [SerializeField] private GameObject camera;

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
            transform.position = new(88f, transform.position.y, transform.position.z);
            CCam.ForceCameraPosition(transform.position, transform.rotation);
        }
        
        
    }

}

