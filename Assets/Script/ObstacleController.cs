using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ObstacleController : MonoBehaviour
{
    

    public static GameManager gameManager;
    private Chain Fire;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // collision withfire of obstacles 
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Chain"))
         {
            GameManager.score++;
            destoryObstacle();
            Chain.isFire = false;
         }
    }

    // destroy obstacles
    virtual public void destoryObstacle()
    {
        Destroy(gameObject);
    }

    
}
