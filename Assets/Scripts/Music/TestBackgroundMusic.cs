using UnityEngine;
using FMODUnity;

public static class TestBackgroundMusic
{
    private static FMOD.Studio.EventInstance musicInstance;
    static TestBackgroundMusic()
    {
        musicInstance = RuntimeManager.CreateInstance("event:/Sleep_Music");
    }

    public static void Play()
    {
        musicInstance.start();
    }
    //public static void PlayFront()
    //{
    //    Debug.Log("Работаем!");
    //    musicInstance.setParameterByName("Parameter 1", 1f);
    //}

    //public static void StopFront()
    //{
    //    Debug.Log("Не Работаетм (");
    //    musicInstance.setParameterByName("Parameter 1", 0f);
    //}

}
