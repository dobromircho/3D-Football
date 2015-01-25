using UnityEngine;
using System.Collections;

public class BallFinder : MonoBehaviour {

    GameObject ball;
    private NavMeshAgent navComponent;
    
    
    void Start()
    {
        navComponent = this.transform.GetComponent<NavMeshAgent>();
        ball = GameObject.FindWithTag("Ball");
    }


    void Update()
    {
        if (ball)
        {
            navComponent.SetDestination(ball.transform.position);

        }
        
    }
}
