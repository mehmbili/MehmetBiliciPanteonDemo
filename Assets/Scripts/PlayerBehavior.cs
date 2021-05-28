using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject player,joystickController,wall,gameController,wallPercentage;
    public GameObject[] ais;
    bool gameFinished = false;
    
    private void Update()
    {
        if (gameFinished)
        {
            wall.transform.position = Vector3.Lerp(wall.transform.position,new Vector3(-10,1.5f,0),Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.position = new Vector3(-1.3f,0.1f,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            player.GetComponent<PlayerMove>().inPlatform = false;
            joystickController.SetActive(false);
            Camera.main.GetComponent<paint>().enabled = true;
            wall.SetActive(true);
            wallPercentage.SetActive(true);
            gameFinished = true;
            for (int i = 0; i < ais.Length; i++)
            {
                ais[i].GetComponent<GirlAi>().running = false;
                ais[i].SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            for(int i = 0; i < ais.Length; i++)
            {
                ais[i].GetComponent<GirlAi>().running = true;
            }
        }
    }
}
