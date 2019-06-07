using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdCardController : MonoBehaviour {

	void Start () {
		GameObject immigrant = GameObject.Find ("IMMIGRANTS").GetComponent<ImmigrantsController> ().createdPerson;

		gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = immigrant.GetComponent<Immigrant> ().firstName;
		gameObject.transform.GetChild(2).GetComponent<TextMesh>().text = immigrant.GetComponent<Immigrant> ().lastName;
	}
}
