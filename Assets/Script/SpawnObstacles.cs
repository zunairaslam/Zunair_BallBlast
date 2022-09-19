using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : ObstacleController
{
    public GameObject[] divine;
    public float[] leftAndRight = new float[2] { -1f, 1f };
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void destoryObstacle()
    {

        seperatObstacle();
        Destroy(gameObject);
    }
    void seperatObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            GameObject Obs;
            for (int i = 0; i < divine.Length; i++)
            {
                Obs = Instantiate(divine[i], transform.position, Quaternion.identity, SpawnPosition.spawnPosition.transform);
                Obs.GetComponent<Rigidbody>().velocity = new Vector3(leftAndRight[i], 5f, 0);

            }
        }
    }
}
