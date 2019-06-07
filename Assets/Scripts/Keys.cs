using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
    public bool LU = false;
    public bool LD = false;
    public bool RU = false;
    public bool RD = false;

	public bool PU = false;
	public bool PD = false;

    private void Update(){
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))LU = true;
        else LU = false;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.B)) LD = true;
        else LD = false;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C)) RU = true;
        else RU = false;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)) RD = true;
        else RD = false;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E)) PU = true;
		else PU = false;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F)) PD = true;
		else PD = false;
    }
}
