using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    GameObject ball;
    GameObject player;
    GameObject goalTarget;
    GameObject computer;
    public float ballSpeed;
    private NavMeshAgent ballNav;
    
    void Start()
    {
        
        ball = GameObject.FindWithTag("Ball");
        ballNav = this.transform.GetComponent<NavMeshAgent>();
        ballNav.enabled = false;
        player = GameObject.FindWithTag("Player");
        computer = GameObject.FindWithTag("Computer");
        goalTarget = GameObject.FindWithTag("GoalTarget");
    }
    
    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 shootDir = ball.transform.position - player.transform.position;
                shootDir.Normalize();
                ball.rigidbody.AddForce(shootDir * ballSpeed,ForceMode.Impulse);
                audio.Play();
            }
        }
        if (coll.gameObject.tag == "Computer")
        {
            if (ballNav.enabled)
            {
                if (computer.transform.position.x - goalTarget.transform.position.x > ball.transform.position.x - goalTarget.transform.position.x)
                {
                    if (computer.transform.position.x - goalTarget.transform.position.x < 12f && computer.transform.position.z < 3f && computer.transform.position.z > -3f && computer.transform.position.x - goalTarget.transform.position.x > 2f)
                    {
                        Vector3 compShootDir = ball.transform.position - computer.transform.position;
                        compShootDir.Normalize();
                        ball.rigidbody.AddForce(compShootDir * ballSpeed , ForceMode.Impulse);
                        audio.Play();
                    }
                }
            }
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Computer")
        {
            ballNav.enabled = true;
            ballNav.SetDestination(goalTarget.transform.position);
        }
        if (coll.gameObject.tag == "Boundry")
        {
            audio.Play();
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Computer")
        {
            ballNav.enabled = false;
        }
    }
    
}
