using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    
    void Update () {
            //float PositionX = Camera.main.transform.rotation.x;
            //PositionX  -= 5.0f;
            //Camera.main.transform.rotation = Quaternion.Euler(PositionX, 0.0f, 0.0f);
            Vector3 movement = new Vector3(Input.GetAxis("Vertical") * (-1), Input.GetAxis("Horizontal"), 0.0f);
            transform.Rotate(movement * 20 * Time.deltaTime);
    }
}
