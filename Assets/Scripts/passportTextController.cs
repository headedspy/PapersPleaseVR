using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passportTextController : MonoBehaviour {
	void Start () {
		gameObject.transform.Find ("passID").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().passportID;
		gameObject.transform.Find ("lastName").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().lastName;
		gameObject.transform.Find ("firstName").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().firstName;
		gameObject.transform.Find ("gender").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().gender.ToString();
		gameObject.transform.Find ("birth").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().birthDay;
		gameObject.transform.Find ("country").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().country;
		gameObject.transform.Find ("city").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().city;
		gameObject.transform.Find ("expire").GetComponent<TextMesh> ().text = gameObject.transform.parent.parent.gameObject.GetComponent<Immigrant> ().expireDate;
	}
}
