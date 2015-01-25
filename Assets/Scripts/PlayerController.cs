using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

    public float speed;
    
   
    
    float moveHorizontal;
    float moveVertical;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(moveHorizontal * speed,0.0f, moveVertical * speed);
        

    }
}
