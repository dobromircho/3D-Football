using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    public string name;
    public InputField input;
    public Text displayName;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }
	
	// Update is called once per frame
	void Update () 
    {
        name = input.text.Clone().ToString();
        displayName.text = name;
	}
}
