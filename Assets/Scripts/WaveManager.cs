using NUnit.Framework;
using System;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //Instance
    public static WaveManager Instance;
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; 
    }

    //Event
    public event Action OnHealthChanged;



    public GameObject enemyPrefab;
    public int healthCore = 10;

    private int enemyCount = 3; //public ici ? + flexible
    private int enemySpawned = 0;
    private float spawnCooldown = 2f; //public ici ? + flexible
    private float timeSinceLastSpawn;
    //private int currentWave = 1;

    
    public Transform[] path;
    private Transform startPoint;
    private Transform endPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (path.Length == 0)
        {
            Debug.Log("PAS DE PATH");
            return;
        }
        startPoint = path[0];
        endPoint = path[^1];



    }

    // Update is called once per frame
    void Update()
    {
        if (healthCore <= 0)
        {
            Debug.Log("Perdu ! ");
            //LevelManager.Instance.gameOver();
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;
 
        if (timeSinceLastSpawn > spawnCooldown && enemySpawned < enemyCount)
        {
            timeSinceLastSpawn = 0;
            GameObject enemy = Instantiate(enemyPrefab, startPoint.position, startPoint.rotation);
            enemy.GetComponent<EnemyScript>().path = path;
            enemySpawned++;
        }
    }

    public void HitCore()
    {
        healthCore--;
        OnHealthChanged?.Invoke();
        print($"reste {healthCore} hp");
    }



}
