using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicInstance;

    [SerializeField] private string eventWay;

    public void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(eventWay);
        musicInstance.start();
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
        StopMusic();
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        StopMusic();
    }

    private void StopMusic()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicInstance.release();
        }
    }

}
