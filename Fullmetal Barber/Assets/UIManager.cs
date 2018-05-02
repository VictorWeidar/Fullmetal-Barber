using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Text CountdownTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        CountdownTxt.text = Mathf.Round(Gamemanager.Instance.GameTimer).ToString();
	}

    public void OnButtonReset()
    {
        Gamemanager.Instance.Reset();
    }
}
