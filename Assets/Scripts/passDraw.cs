using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passDraw : MonoBehaviour {
    public GameObject pen;

    public void OnTriggerStay(Collider other) {
        if (other.gameObject == pen) {
            gameObject.name = "PaperIn";
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject == pen) {
            gameObject.name = "Paper";
        }
    }
}
