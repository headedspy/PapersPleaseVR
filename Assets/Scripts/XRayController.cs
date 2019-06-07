using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayController : MonoBehaviour{

	public GameObject keys;
	public GameObject FrontPic;
	public GameObject BackPic;

	public GameObject curtain;
	public GameObject light;

	public AudioClip sound;

	private bool locked = false;

	void Start(){
		FrontPic.SetActive (false);
		BackPic.SetActive (false);
	}

	void Update(){
		if (keys.GetComponent<Keys> ().LD) {
			if (!locked) {
				locked = true;
				StartCoroutine (Show ());
			}
		}

		if (keys.GetComponent<Keys> ().LU) {
			FrontPic.SetActive (false);
			BackPic.SetActive (false);
		}

	}

	IEnumerator Show(){
		curtain.GetComponent<Animation>().Play ();
		yield return new WaitForSeconds (1);
		light.SetActive (true);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (sound);
		yield return new WaitForSeconds (0.2f);
		light.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		light.SetActive (true);
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (sound);
		yield return new WaitForSeconds (0.2f);
		light.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		FrontPic.SetActive (true);
		BackPic.SetActive (true);
		locked = false;
	}
}