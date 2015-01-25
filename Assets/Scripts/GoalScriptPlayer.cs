using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GoalScriptPlayer : MonoBehaviour
{
    
    public int goal2;
    int goal1;
    public Text scoreText;
    public Text winText;
    public Animator anim;
    string name;
    int goalCount = 5;
    
    void Start()
    {
        goal1 = GameObject.FindGameObjectWithTag("LineComputer").GetComponent<GoalScriptComp>().goal1;
        name = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<PlayerName>().name;
    }
    void Update()
    {
        goal1 = GameObject.FindGameObjectWithTag("LineComputer").GetComponent<GoalScriptComp>().goal1;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            goal2++;
            scoreText.text = name +" - "+ goal1 + " : " + goal2 + " - Computer";
            scoreText.color = Color.red;
            audio.Play();
            anim.SetTrigger("Goal");
            GameController.Destroy(GameObject.FindWithTag("Player"), 0.3f);
            GameController.Destroy(GameObject.FindWithTag("Computer"), 0.3f);
            GameController.Destroy(GameObject.FindWithTag("Ball"), 0.3f);
            if (goal1 == goalCount || goal2 == goalCount)
            {
                if (goal2 == goalCount)
                {
                    winText.text = "computer win!!!";
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
