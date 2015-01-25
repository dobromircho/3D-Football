using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject computer;
    public GameObject ball;
    
	void Start () 
    {
        Respawn();
        GameObject.FindGameObjectWithTag("PlayerName").GetComponent<AudioSource>().volume = 0.1f;
	}
    
    public void Respawn()
    {
        Instantiate(player, new Vector3(-16f, 0.75f, 0.0f), Quaternion.identity);
        Instantiate(ball, new Vector3(0.0f, 0.75f, 0.0f), Quaternion.identity);
        Instantiate(computer, new Vector3(16f, 0.75f, 0.0f), Quaternion.identity);
    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(6.5f);
        Respawn();
    }
    public IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(13f);
        Destroy(GameObject.FindGameObjectWithTag("PlayerName"));
        Application.LoadLevel(0);
    }
}
