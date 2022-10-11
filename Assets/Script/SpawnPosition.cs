using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public GameObject[] ObstaclePrefab;
    public int ObstacleNumbers;
    public float spawnDelay;
    GameObject[] obstacles;
    public static SpawnPosition spawnPosition;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        spawnPosition = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        startObstacles();
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // spawn obstacles with time delay
    IEnumerator SpawnObstacle()
    {
        for(int i = 0; i < ObstacleNumbers; i++)
        {
            if (playerControllerScript.isGameOver != true)
            {
                obstacles[i].SetActive(true);
                yield return new WaitForSeconds(spawnDelay);

            }

        }
    }
    // random selection of obstacle
    void startObstacles()
    {
        if (playerControllerScript.isGameOver == false)
        {
            int prefabTotal = ObstaclePrefab.Length;
            obstacles = new GameObject[ObstacleNumbers];
            for (int i = 0; i < ObstacleNumbers; i++)
            {
                obstacles[i] = Instantiate(ObstaclePrefab[Random.Range(0, prefabTotal)], transform);
                obstacles[i].SetActive(false);
            }
        }
    }
}
