using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    float scrollSpeed = 0.1f;
    Renderer rend;
    bool toDown = true;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {   float offset = Time.deltaTime * scrollSpeed;
        if (toDown)
        {
            rend.material.mainTextureOffset += new Vector2(offset, 0);
            if (rend.material.mainTextureOffset.x >= 0.3f)
            {
                toDown = false;
            }
        }
        else
        {
            rend.material.mainTextureOffset -= new Vector2(offset, 0);
            if (rend.material.mainTextureOffset.x <= 0)
            {
                toDown = true;
            }
        }
        
        
        
    }
}
