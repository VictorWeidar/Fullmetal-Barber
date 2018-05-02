using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {

    public Transform RotatePoint;
    public float RotateSpeed;
    float h = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        float MovH = h * RotateSpeed * Time.deltaTime;

        transform.RotateAround(RotatePoint.transform.position, new Vector3(0, MovH, 0), 2);

	}


    public void OnButtonLeft()
    {
        h = 1;
        StartCoroutine(WaitTime());
        
    }

    public void OnButtonRight()
    {
        h = -1;
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
        h = 0;
    }
}

