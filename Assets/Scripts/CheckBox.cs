using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour {
    public GameObject pen;
    public bool isChecked = false;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject == pen && pen.name == "PenDown") {
            isChecked = true;
        }
    }
}
