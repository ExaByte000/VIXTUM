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


        if (camera.TryGetComponent<CinemachineCamera>(out var CCam))
        {
            Vector3 cameraPos = new(88f, hero.transform.position.y + 4.0f, 0f);
            CCam.ForceCameraPosition(cameraPos, hero.transform.rotation);
            CCam.Follow = transform;
            CCam.LookAt = transform;
        }
        if(scene.name == "MainScene")
        {
            hero.Health = 10;
            transform.position = new(88f, transform.position.y, transform.position.z);
        }
        
    }

}

