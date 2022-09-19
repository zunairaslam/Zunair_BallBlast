using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpward : MonoBehaviour
{
    public float speed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // fire movement
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
