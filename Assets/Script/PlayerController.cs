using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInputs;
    public float speed = 10f;
    private float xRangeNegative = -5f;
    private float xRangePositive = 29f;
    public bool isGameOver = false;
    private Animator playerAmin;
    public ParticleSystem DirtPartical;

    // Start is called before the first frame update
    void Start()
    {
        playerAmin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver != true)
        {
            if (transform.position.x < xRangeNegative)
            {
                transform.position = new Vector3(xRangeNegative, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRangePositive)
            {
                transform.position = new Vector3(xRangePositive, transform.position.y, transform.position.z);
            }
            horizontalInputs = Input.GetAxis("Horizontal");
            
            if (horizontalInputs == 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                playerAmin.SetFloat("RunSpeed",0);
                playerAmin.SetFloat("RunLeft", 0);
                DirtPartical.Stop();
                transform.Translate(Vector3.forward * horizontalInputs * Time.deltaTime * speed);
                

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                playerAmin.SetFloat("RunSpeed", 0.2f);
                
                transform.eulerAngles = new Vector3(0, 90, 0);
                DirtPartical.Play();
                transform.Translate(Vector3.forward * horizontalInputs * Time.deltaTime * speed);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerAmin.SetFloat("RunLeft", -0.2f);
                transform.eulerAngles = new Vector3(0, 270, 0);
                DirtPartical.Play();
                transform.Translate(Vector3.back * horizontalInputs * Time.deltaTime * speed);

            }
           
        }else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            playerAmin.SetFloat("RunSpeed", 0);
            playerAmin.SetFloat("RunLeft", 0);
            DirtPartical.Stop();
        }
    }
    // player collision with obstacles
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameManager.lifeLimit--;
        }
        if (collision.gameObject.CompareTag("life"))
        {
            GameManager.lifeLimit++;
            Destroy(collision.gameObject);
        }
        if(GameManager.lifeLimit == 0)
        {
            playerAmin.SetBool("Death", true);
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
}
