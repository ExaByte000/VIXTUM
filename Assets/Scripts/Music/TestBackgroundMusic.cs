using UnityEngine;
using FMODUnity;

public static class TestBackgroundMusic
{
    private static FMOD.Studio.EventInstance musicInstance;
    static TestBackgroundMusic()
    {
        musicInstance = RuntimeManager.CreateInstance("event:/BackgroundMusic");
    }

    public static void Play()
    {
        musicInstance.start();
    }
    public static void PlayFront()
    {
        Debug.Log("��������!");
        musicInstance.setParameterByName("AddFront", 1f);
    }

    public static void StopFront()
    {
        Debug.Log("�� ��������� (");
        musicInstance.setParameterByName("AddFront", 0f);
    }

}
