using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passport : MonoBehaviour {
    public bool accepted = false;
    public bool declined = false;

    public GameObject greenField;
    public GameObject redField;

    public bool chosen = false;
	
	void Update(){
        if(!chosen){
            if(greenField.GetComponent<CheckBox>().isChecked){
                accepted = true;
                chosen = true;
            }
            else if(redField.GetComponent<CheckBox>().isChecked){
                declined = true;
                chosen = true;
            }
        }
		
	}
}
