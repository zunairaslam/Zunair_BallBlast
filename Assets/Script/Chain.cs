using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public Transform player;
    public float speed = 1.5f;
    public static bool isFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
        {
            isFire = true;
        }if (isFire)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime;
        }
        else
        {
            transform.position = player.position;
            transform.localScale = new Vector3(1f, 0 ,1f);
        } 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isFire = false;
        }
    }
}
