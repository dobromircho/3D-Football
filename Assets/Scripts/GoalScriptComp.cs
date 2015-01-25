using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScriptComp : MonoBehaviour 
{
    public int goal1;
    int goal2;
    public Text scoreText;
    public Text winText;
    public Animator anim;
    string name;
    int goalCount = 5;

    void Start()
    {
        goal2 = GameObject.FindGameObjectWithTag("LinePlayer").GetComponent<GoalScriptPlayer>().goal2;
        if (GameObject.FindGameObjectWithTag("PlayerName").GetComponent<PlayerName>().name == "")
        {
            name = "PLAYER";
        }
        else
        {
            name = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<PlayerName>().name;
        }
        scoreText.text = name + " - " + goal1 + " : " + goal2 + " - Computer";

    }

    void Update()
    {
        goal2 = GameObject.FindGameObjectWithTag("LinePlayer").GetComponent<GoalScriptPlayer>().goal2;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            goal1++;
            scoreText.text = name + " - " + goal1 + " : " + goal2 + " - Computer";
            scoreText.color = Color.blue;
            audio.Play();
            anim.SetTrigger("Goal");
            GameController.Destroy(GameObject.FindWithTag("Player"), 0.3f);
            GameController.Destroy(GameObject.FindWithTag("Computer"), 0.3f);
            GameController.Destroy(GameObject.FindWithTag("Ball"), 0.3f);
            if (goal1 == goalCount || goal2 == goalCount)
            {
                if (goal1 == goalCount)
                {
                    winText.text = name + " win!!!";
                    anim.SetTrigger("Win");
                    GameObject.FindGameObjectWithTag("GoalTarget").GetComponent<AudioSource>().audio.PlayDelayed(7f);
                    
                    GameObject.FindGameObjectWithTag("Field").GetComponent<AudioSource>().audio.Stop();
                    StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ReloadGame());
                }
                
                
            }
            else
            {
                StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Restart());
            }
        }
        
    }





   
}
