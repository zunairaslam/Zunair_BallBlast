using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] life;
    public static int lifeLimit = 3;
    public TMP_Text Number;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Number.text = score.ToString();
        if (lifeLimit == 0)
        {
            life[0].SetActive(false);
            life[1].SetActive(false);
            life[2].SetActive(false);
        }
        else if (lifeLimit == 1)
        {
            life[0].SetActive(true);
            life[1].SetActive(false);
            life[2].SetActive(false);
        }
        else if (lifeLimit == 2)
        {
            life[0].SetActive(true);
            life[1].SetActive(true);
            life[2].SetActive(false);

        }
        else if (lifeLimit >= 3)
        {
            life[0].SetActive(true);
            life[1].SetActive(true);
            life[2].SetActive(true);
            lifeLimit = 3;
        }

    }
}

