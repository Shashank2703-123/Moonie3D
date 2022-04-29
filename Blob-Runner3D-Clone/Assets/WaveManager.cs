using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string WaveName;
        public int NoOfenemies;
        public GameObject[] typeOfEnemies;
        public float spawnInterval;
        public Transform[] SpawnTransform;
        public float ShootInterval;
        public bool isBossWave;
        public float Rotoffset;
        public int NoOfEnemiesStatic;
    }

    public Wave[] waves;
    private Wave currentWave;
    private int CurrentWaveNumber;
    private bool canSpawn = true;
    public GameObject[] EnemieObj;
    private float nextspawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemieObj = GameObject.FindGameObjectsWithTag("Enemy");
        currentWave = waves[CurrentWaveNumber];      
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (totalEnemies.Length == 0 && !canSpawn)
        {
            canSpawn = true;
          
            CurrentWaveNumber++;
       //     PlayerCharac.Health = PlayerCharac.MaxHp;
         //   HealthBars.RestartHp();
            //   Enemies.text = "";
            //   WaveTransition();
        }
        else
        {
           // Enemies.text = totalEnemies.Length + "/" + currentWave.NoOfEnemiesStatic;
        }
    }

    private void SpawnWave()
    {
        if (canSpawn && nextspawnTime < Time.time)
        {
          
            GameObject Enemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
         //   Enemy.GetComponent<EnemyNewMovement>().movespot = moveSpt.transform;
        //    Enemy.GetComponent<EnemyNewMovement>().Mover = moveSpt;
            for(int i = 0; i < currentWave.SpawnTransform.Length;i++)
            {
                Enemy.GetComponent<enemyAI>().wayPoints[i] = currentWave.SpawnTransform[i];
            }
            int Rand = Random.Range(0, currentWave.SpawnTransform.Length);
            Enemy.GetComponent<enemyAI>().StartPointIndex = Rand;
            Transform randomPoint = currentWave.SpawnTransform[Random.Range(0, currentWave.SpawnTransform.Length)];
            Instantiate(Enemy, randomPoint.position, Quaternion.identity);
            currentWave.NoOfenemies--;
            nextspawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.NoOfenemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
