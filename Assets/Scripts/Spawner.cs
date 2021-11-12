
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //================================= Objects 
    public Transform[] spawnPoints; //Will hold the Postion details of the spawnPoints
    public GameObject[] hazards; //Holds enemy types collected from PreFab that were spawned
    private GameObject _original;
    public GameObject enemyDeathZone; 

    //============================== Timers 
    private float _spawnTime;   //The timer
    public float startSpawn;   //Max time the timer can be a
    public float minTime;     //The min time that timer can be set to 
    public float decreaseTime; //The amount the timer will be lowered by till it hits MIN_TIME
    
        
    //========================= Flags 
    public bool isSpawning;  //Tells us if we're spawning regular balls or all the hazards 
    
    //============================ Code 

    private void Start()
    {
        _original = new GameObject
        {
            name = "EnemyBox"
        };
        Instantiate(_original, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    /**
    *Purpose: Count down and spawn a ball 
    */
    private void Update()
    {
        if (!isSpawning) return;
        if (_spawnTime <= 0)
        {
            //Grabs the random location where we're going to spawn it 
            var spawnPoint = Random.Range(0, spawnPoints.Length);
            var randomSpawnPoint = spawnPoints[spawnPoint];
            //Gets the type of hazard we're spawning 
            var randomHazard = hazards[0];
            randomHazard.GetComponent<WallWalker>().x = spawnPoint == 0 ? Random.Range(-1, -2.5f) : Random.Range(1, 2.5f);

            var enemy = Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);
            enemy.transform.SetParent(_original.transform);
                
            //Makes the speed of spawning faster as the game goes on 
            if (startSpawn >= minTime)
            {
                startSpawn -= decreaseTime;
            }

            //Resets the spawn timer 
            _spawnTime = startSpawn;
        }
        else
        {
            //Updates the spawn timer 
            _spawnTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        isSpawning = true;
    }

    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        isSpawning = false;
        //Destroy all enemies 
        Destroy(_original);
        //Set up new box for enemies to spawn in
        _original = new GameObject
        {
            name = "EnemyBox"
        };
        Instantiate(_original, new Vector3(0,0,0), Quaternion.identity);
        
        if(enemyDeathZone.GetComponent<EnemyDeathZone>().score < enemyDeathZone.GetComponent<EnemyDeathZone>().scoreGoal)
        {
            enemyDeathZone.GetComponent<EnemyDeathZone>().Reset();
        }
    }
}