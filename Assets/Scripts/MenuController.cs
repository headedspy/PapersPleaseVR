using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public int chosen = 1;
    public GameObject keyboard;
    public GameObject days;
    private string UserName;

    public Material button;
    public Material buttonSelected;

    private void Start() {
    }

    private void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)) {
            if(hit.transform.gameObject.name == "PLAY_TUT"){
                hit.transform.gameObject.GetComponent<Renderer>().material = buttonSelected;
                GameObject.Find("QUIT").GetComponent<Renderer>().material = button;

                hit.transform.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = Color.black;
                GameObject.Find("QUIT").transform.GetChild(0).GetComponent<TextMesh>().color = Color.white;
                chosen = 1;
            } else if(hit.transform.gameObject.name == "QUIT"){
                hit.transform.gameObject.GetComponent<Renderer>().material = buttonSelected;
                GameObject.Find("PLAY_TUT").GetComponent<Renderer>().material = button;
                hit.transform.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = Color.black;
                GameObject.Find("PLAY_TUT").transform.GetChild(0).GetComponent<TextMesh>().color = Color.white;
				chosen = 2;
            }
        }
    }

}