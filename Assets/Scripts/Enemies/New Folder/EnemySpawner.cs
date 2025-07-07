using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private int spawnrate;

    private Transform spawnPoint;
    private Coroutine coroutine;

    private void Start()
    {
        spawnPoint = GetComponent<Transform>();
        StartSpawning();
        
    }

    public void StartSpawning()
    {
        if (coroutine != null)
        {
            StopSpawning();
        }
        coroutine = StartCoroutine(nameof(SpawnTine));
    }
    public void StopSpawning()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator SpawnTine()
    {
        while (true)
        {
            int i = 0;
            while (i < spawnrate)
            {
                Debug.Log("—павню");
                Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoint);
                i++;
            }
            Debug.Log("∆дем");
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        

    }
}
