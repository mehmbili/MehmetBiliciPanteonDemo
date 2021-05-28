using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    bool goingRight = false;
    [SerializeField] float moveLimit,speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (goingRight)
        {
            gameObject.transform.position += new Vector3(0,0,1) * Time.deltaTime*speed;
            if (gameObject.transform.position.z > moveLimit)
            {
                goingRight = false;
            }
        }
        else
        {
            gameObject.transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
            if (gameObject.transform.position.z < -moveLimit)
            {
                goingRight = true;
            }
        }
    }
}
