using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ImmigrantsController : MonoBehaviour{
    public GameObject keys;
    public GameObject person;

    public GameObject data;

    public GameObject createdPerson;

    public GameObject penObject;

	public GameObject bars;

	public GameObject stats;

	public AudioClip soundDetain;
	public AudioClip soundCall;

	private int passed = 0;
	private int accepted = 0;
	private int declined = 0;
	private int detained = 0;

	private bool locked = false;

	void Awake(){
		bars.SetActive (false);
	}

	void Update(){
		if (keys.GetComponent<Keys> ().LU && createdPerson == null) {
			Camera.main.GetComponent<AudioSource> ().PlayOneShot (soundCall);
			createdPerson = Instantiate (person);
			createdPerson.GetComponent<Immigrant> ().data = data;
			createdPerson.transform.GetChild (0).GetComponent<passDraw> ().pen = penObject;
			createdPerson.transform.GetChild (0).GetChild (0).GetComponent<CheckBox> ().pen = penObject;
			createdPerson.transform.GetChild (0).GetChild (1).GetComponent<CheckBox> ().pen = penObject;
		} else if (keys.GetComponent<Keys>().RU && createdPerson != null) {
			if (!locked) {
				locked = true;
				StartCoroutine (Detain ());
			}
		}
		if (keys.GetComponent<Keys>().LU && createdPerson.transform.GetChild(0).GetComponent<Passport>().chosen) {

			if (createdPerson.transform.GetChild (0).GetComponent<Passport> ().accepted) {
				if (createdPerson.GetComponent<Immigrant> ().shouldAccept) {
					if(!createdPerson.GetComponent<Animation>().isPlaying)accepted++;
				} else {
					if(!createdPerson.GetComponent<Animation>().isPlaying)declined++;
				}
				createdPerson.transform.GetChild (0).gameObject.SetActive (false);
				createdPerson.transform.GetChild (1).gameObject.SetActive (false);
				createdPerson.transform.GetChild (2).gameObject.SetActive (false);
				createdPerson.GetComponent<Animation> ().Play ("ExitRight");
			} else if (createdPerson.transform.GetChild (0).GetComponent<Passport> ().declined) {
				if (!createdPerson.GetComponent<Immigrant> ().shouldAccept) {
					if(!createdPerson.GetComponent<Animation>().isPlaying)accepted++;
				} else {
					if(!createdPerson.GetComponent<Animation>().isPlaying)declined++;
				}
				createdPerson.transform.GetChild (0).gameObject.SetActive (false);
				createdPerson.transform.GetChild (1).gameObject.SetActive (false);
				createdPerson.transform.GetChild (2).gameObject.SetActive (false);
				createdPerson.GetComponent<Animation> ().Play ("ExitLeft");
			}

            Destroy(createdPerson, 9);
            penObject.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();
			if(!createdPerson.GetComponent<Animation>().isPlaying)passed++;
			UpdateText ();
        }
	}

	IEnumerator Detain(){
		if (createdPerson.GetComponent<Immigrant> ().shouldDetain) {
			if(!createdPerson.GetComponent<Animation>().isPlaying)accepted++;
		} else {
			if(!createdPerson.GetComponent<Animation>().isPlaying)declined++;
		}
		if(!createdPerson.GetComponent<Animation>().isPlaying)detained++;
		penObject.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

		Camera.main.GetComponent<AudioSource> ().PlayOneShot (soundDetain);
		bars.SetActive (true);
		yield return new WaitForSeconds (1);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (soundDetain);
		Camera.main.transform.GetChild (0).gameObject.SetActive (true);
		yield return new WaitForSeconds (1);
		Destroy (createdPerson);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (soundDetain);
		Camera.main.transform.GetChild (0).gameObject.SetActive (false);
		yield return new WaitForSeconds (1);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (soundDetain);
		bars.SetActive (false);
		locked = false;
		UpdateText ();
	}

	void UpdateText(){
		passed = accepted + declined;
		stats.transform.GetChild (0).GetComponent<TextMesh> ().text = passed.ToString ();
		stats.transform.GetChild (1).GetComponent<TextMesh> ().text = accepted.ToString ();
		stats.transform.GetChild (2).GetComponent<TextMesh> ().text = declined.ToString ();
		stats.transform.GetChild (3).GetComponent<TextMesh> ().text = detained.ToString ();
	}
}
