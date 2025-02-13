using System;
using System.Collections;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [HideInInspector] public static event Action StartWave;
    [HideInInspector] public static event Action StopWave;
    private int waveCounter = 0;
    [SerializeField] private int waveDuration;
    [SerializeField] private int chillDuration;

    private void Start()
    {
        StartCoroutine(WaveCoroutine());
    }

    private IEnumerator WaveCoroutine()
    {
        yield return new WaitForSeconds(10);
        StartWave?.Invoke();
        waveCounter++;

        while (true)
        {

            yield return new WaitForSeconds(waveDuration);
            StopWave?.Invoke();

            yield return new WaitForSeconds(chillDuration);
            StartWave?.Invoke();
            waveCounter++;
        }


    }
}
