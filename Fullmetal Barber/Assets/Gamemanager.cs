using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {

    public static Gamemanager Instance;

    

    public bool CanShoot = true;

    public float GametimerMax = 30;
    public float GameTimer;

    public float ResetTimerMax = 90f;
    public float ResetTimer;

	// Use this for initialization
	void Start ()
    {
        Instance = this;

        GameTimer = GametimerMax;
        ResetTimer = ResetTimerMax;
        CanShoot = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        GameTimer -= Time.deltaTime;
        ResetTimer -= Time.deltaTime;

        if(GameTimer <= 0)
        {
            CanShoot = false;
            GameTimer = 0;
        }

        if(ResetTimer <= 0)
        {
            Reset();
        }
	}

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
