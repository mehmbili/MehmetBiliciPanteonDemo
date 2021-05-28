using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlAi : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform aiDestination;
    Animator anim;
    public bool running = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (running)
        {
            anim.SetBool("Running", true);
            agent.enabled = true;
            agent.SetDestination(aiDestination.position);
        }
        else
        {
            anim.SetBool("Running", false);
            agent.enabled = false;
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.position = new Vector3(0,1,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            running = false;
            gameObject.transform.position -= new Vector3(10, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
