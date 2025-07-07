using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//public class SpawnEnemies : MonoBehaviour
//{
//    [SerializeField] private ScoreSystem scoreSystem;
//    private Transform spawnPoint;
//    private Coroutine spawn;
//    [SerializeField] private GameObject[] Enemy;
//    [SerializeField] private int spawnTime = 2;
//    void Start()
//    {
//        spawnPoint = GetComponent<Transform>();
//        foreach(GameObject en in Enemy)
//        {
//            en.GetComponent<Enemy>().scoreSystem = scoreSystem;

//        }
//    }

//    private void OnEnable()
//    {
//        WaveSystem.StartWave += StartSpawn;
//        WaveSystem.StopWave += StopSpawn;
//    }
//    private void OnDisable()
//    {
//        WaveSystem.StopWave -= StopSpawn;
//        WaveSystem.StartWave -= StartSpawn;
//    }

//    private void StartSpawn()
//    {
//        spawn = StartCoroutine(nameof(SpawnTimer));
//    }
//    private void StopSpawn()
//    {
//        if (spawn != null)
//        {
//            StopCoroutine(spawn);
//        }
//    }
    
//    private IEnumerator SpawnTimer()
//    {
//        int enimies = 1;
//        while (true)
//        {
//            if (scoreSystem.Score < 500)
//            {
//                enimies = 1;
//            }
//            else if(scoreSystem.Score >= 500 && scoreSystem.Score < 1000)
//            {
//                enimies = 2;
//            }
//            else if (scoreSystem.Score >= 1000)
//            {
//                enimies = 3;
//            }

//            for (int i = 0; i < enimies; i++) 
//            {
//                Instantiate(Enemy[Random.Range(0, Enemy.Count())], new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), Quaternion.identity);
//            }

//            yield return new WaitForSeconds(spawnTime);
//        }
        

//    }
    
//}
