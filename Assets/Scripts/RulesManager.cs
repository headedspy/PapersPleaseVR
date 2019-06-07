using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesManager : MonoBehaviour {

	private int ruleOne, ruleTwo;
	private GameObject textOne, textTwo;

	public GameObject bookObject;

	public AudioClip printSound;

	string country = "";
	string secondCountry = "";

	public static RulesManager Instance { get; private set;}

	void Awake(){
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start(){
		ChangeRules ();
	}

	public void ChangeRules () {
		bookObject.GetComponent<Animation> ().Play ();
		textOne = bookObject.transform.GetChild (0).gameObject;
		textTwo = bookObject.transform.GetChild (1).gameObject;
		ruleOne = Random.Range (0, 4);
		ruleTwo = Random.Range (0, 4);

		int countryOneNumber = Random.Range (0, 4);

		int countryTwoNumber = Random.Range (0, 4);
		while(countryTwoNumber == countryOneNumber) countryTwoNumber = Random.Range (0, 4);

		switch (countryOneNumber) {
		case 0:
			country = "Kamevgrad";
			break;
		case 1:
			country = "Goretsk";
			break;
		case 2:
			country = "Yeladovo";
			break;
		case 3:
			country = "Gelevostok";
			break;
		}

		switch (countryTwoNumber) {
		case 0:
			secondCountry = "Kamevgrad";
			break;
		case 1:
			secondCountry = "Goretsk";
			break;
		case 2:
			secondCountry = "Yeladovo";
			break;
		case 3:
			secondCountry = "Gelevostok";
			break;
		}

		//10
		switch (ruleOne) {
		case 0:
			textOne.GetComponent<TextMesh> ().text = "Detain all\nimmigrants\nfrom\n"+country;
			break;
		case 1:
			textOne.GetComponent<TextMesh> ().text = "Deny all\nimmigrants\nfrom\n"+country;
			break;
		case 2:
			textOne.GetComponent<TextMesh> ().text = "Search all\nimmigrants\nfrom\n"+country;
			break;
		case 3:
			textOne.GetComponent<TextMesh> ().text = "Accept\nonly from\n"+country+"\nand\n"+secondCountry;
			break;
		}
		switch (ruleTwo) {
		case 0:
			textTwo.GetComponent<TextMesh> ().text = "Foreigners\nrequire an\nentry\npermit";
			break;
		case 1:
			textTwo.GetComponent<TextMesh> ().text = "Foreigners\nrequire an\nentry\npermit\nand locals\nrequire ID\ncard";
			break;
		case 2:
			textTwo.GetComponent<TextMesh> ().text = "All\nrequire ID\ncard";
			break;
		case 3:
			textTwo.GetComponent<TextMesh> ().text = "Foreigners\nmust be 25\nor older";
			break;
		}

		StartCoroutine (PlayAudio ());
	}

	IEnumerator PlayAudio(){
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (printSound);
		yield return new WaitForSeconds (0.7f);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (printSound);
		yield return new WaitForSeconds (0.7f);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (printSound);
	}

	public Choice.State CheckImmigrant(GameObject immigrantObject){

		Immigrant immigrant = immigrantObject.GetComponent<Immigrant> ();

		switch (ruleTwo) {
		case 0:
			if (!immigrant.hasEntryPermit)
				return Choice.State.DENY;
			break;
		case 1:
			if (immigrant.country == "Poleryol") {
				if (!immigrant.hasId) {
					return Choice.State.DENY;
				}
			} else {
				if (!immigrant.hasEntryPermit) {
					return Choice.State.DENY;
				}
			}
			break;
		case 2:
			if (!immigrant.hasId)
				return Choice.State.DENY;
			break;
		case 3:
			if (immigrant.age < 25)
				return Choice.State.DENY;
			break;
		}

		switch (ruleOne) {
		case 0:
			if (immigrant.country == country)
				return Choice.State.DETAIN;
			break;
		case 1:
			if (immigrant.country == country)
				return Choice.State.DENY;
			break;
		case 2:
			if (immigrant.country == country)
				return Choice.State.SEARCH;
			break;
		case 3:
			if (immigrant.country == country || immigrant.country == secondCountry)
				return Choice.State.ACCEPT;
			else
				return Choice.State.DENY;
		}

		return Choice.State.ACCEPT;
	}
}
