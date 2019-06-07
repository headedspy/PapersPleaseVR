using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public GameObject controller;
    public GameObject input;
    public GameObject selectionOne;
    public GameObject selectionTwo;
    public GameObject selectionThree;

    public GameObject noName;

    void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(StartTheGame);
    }

    void StartTheGame(){
        int option = controller.GetComponent<MenuController>().chosen;
		if (option == 1) {
			SceneManager.LoadScene ("game");
		} else {
			Application.Quit ();
		}
    }
}
