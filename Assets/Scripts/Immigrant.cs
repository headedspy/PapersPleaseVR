using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immigrant : MonoBehaviour{
	private bool debug = false;

//-------------------------------------------P-A-S-S---I-N-F-O-------------------------------------------------------
    public string firstName = "FNAME";
    public string lastName = "LNAME";
    public char gender = 'G';

    public string birthDay = "DD-MM-YYYY";
    public string expireDate = "DD-MM-YYYY";

    public string country = "COUNTRY";
    public string city = "CITY";
    public string passportID = "00000-00000";
//-------------------------------------------------------------------------------------------------------------------

	private GameObject CardObj, PermitObj;

	public int age;

	private int skinColor = 0;
	public Material[] skinColors = new Material[4];

    public int hairType = 0;
	private int hairColor = 0;

	public Material[] hairColors = new Material[4];

    public GameObject data;

	private int noseType = 0;

	public Material[] eyesColors = new Material[3];
	private int eyesColor = 0;

	public Material[] beardColors = new Material[2];

	public bool shouldAccept = true;
	public bool shouldSearch = false;
	public bool shouldDetain = false;

	public bool hasEntryPermit = false;
	public bool hasId = false;

	private int percentExpired = 5;
	private int percentWrongPhoto = 10;
	private int percentWrongCity = 20;
	private int percentContraband = 35;
	private int percentMissingId = 10;
	private int percentMissingPermit = 10;

    void Start () {
		CardObj = GameObject.Find("Idcard").gameObject;
		CardObj.SetActive (false);

		PermitObj = GameObject.Find ("Permit").gameObject;
		PermitObj.SetActive (false);

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  GENDER & NAMES
        int genderNum = UnityEngine.Random.Range(0, 2);
        if (genderNum == 0){
            gender = 'F';
            int fNameNum = UnityEngine.Random.Range(0, data.GetComponent<RandomInfo>().GetFemaleFirstNameSize());
            int lNameNum = UnityEngine.Random.Range(0, data.GetComponent<RandomInfo>().GetFemaleLastNameSize());
            firstName = data.GetComponent<RandomInfo>().GetFemaleFirstName(fNameNum);
            lastName = data.GetComponent<RandomInfo>().GetFemaleLastName(lNameNum);
            gameObject.transform.Find("Armature/Torso/Neck/Head/Head/HEAD_F").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/Neck/Head/Head/R_EAR_F").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/Neck/Head/Head/L_EAR_F").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/BODY_F").gameObject.SetActive(true);
        }
        else{
            gender = 'M';
            int fNameNum = UnityEngine.Random.Range(0, data.GetComponent<RandomInfo>().GetMaleFirstNameSize());
            int lNameNum = UnityEngine.Random.Range(0, data.GetComponent<RandomInfo>().GetMaleLastNameSize());
            firstName = data.GetComponent<RandomInfo>().GetMaleFirstName(fNameNum);
            lastName = data.GetComponent<RandomInfo>().GetMaleLastName(lNameNum);
			gameObject.transform.Find("Armature/Torso/Neck/Head/Head/HEAD_M").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/Neck/Head/Head/R_EAR_M").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/Neck/Head/Head/L_EAR_M").gameObject.SetActive(true);
			gameObject.transform.Find("Armature/Torso/BODY_M").gameObject.SetActive(true);
        }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  BIRTH DATE

        age = UnityEngine.Random.Range(18, 81);
        birthDay = data.GetComponent<DateTime>().GetDate(age);


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  EXPIRE DATE

        int expirePercentNum = UnityEngine.Random.Range(1, 101);
		if (expirePercentNum <= percentExpired) {
			expireDate = data.GetComponent<DateTime> ().GetDate (UnityEngine.Random.Range(2, 6));
			shouldAccept = false;
		}
		else expireDate = data.GetComponent<DateTime>().GetDate(UnityEngine.Random.Range(-6, -2));


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ PASSPORT ID

        passportID = GetRandomPassportID();

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ COUNTRY & CITY

        int countryNum = UnityEngine.Random.Range(0, data.GetComponent<RandomInfo>().GetCountriesSize());
		int cityPercentNum = UnityEngine.Random.Range (0, 101);
		country = data.GetComponent<RandomInfo> ().GetCountries (countryNum);
		if (cityPercentNum <= percentWrongCity) {
			shouldAccept = false;
			int anotherCountryNum = UnityEngine.Random.Range (0, data.GetComponent<RandomInfo> ().GetCountriesSize ());
			while(anotherCountryNum == countryNum)anotherCountryNum = UnityEngine.Random.Range (0, data.GetComponent<RandomInfo> ().GetCountriesSize ());
			city = data.GetComponent<RandomInfo> ().GetCity (data.GetComponent<RandomInfo> ().GetCountries (anotherCountryNum), UnityEngine.Random.Range (0, 4));
		} else {
			city = data.GetComponent<RandomInfo> ().GetCity (country, UnityEngine.Random.Range (0, 4));
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ NOSE

		noseType = UnityEngine.Random.Range (1, 3);
		gameObject.transform.Find ("Armature/Torso/Neck/Head/Head/nose").transform.GetChild (noseType - 1).gameObject.SetActive (true);

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ EYES

		eyesColor = UnityEngine.Random.Range (0, 3);
		gameObject.transform.Find("Armature/Torso/Neck/Head/Head/eyes/color").gameObject.GetComponent<Renderer> ().material = eyesColors [eyesColor];

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ BEARD

		if (gender == 'M') {
			int beardType = UnityEngine.Random.Range(1, 8);
			int beardColor = UnityEngine.Random.Range(0, 2);
			gameObject.transform.Find ("Armature/Torso/Neck/Head/Head/beard").transform.GetChild (beardType - 1).gameObject.SetActive (true);
			if(beardType != 7)gameObject.transform.Find("Armature/Torso/Neck/Head/Head/beard/").transform.GetChild (beardType - 1).gameObject.GetComponent<Renderer> ().material = beardColors [beardColor];
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ SKIN COLOR

		skinColor = UnityEngine.Random.Range (0, 4);
		gameObject.transform.Find("Armature/Torso/Neck/Head/Head/HEAD_"+gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [skinColor];
		gameObject.transform.Find("Armature/Torso/BODY_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [skinColor];
		gameObject.transform.Find("Armature/Torso/Neck/Head/Head/L_EAR_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [skinColor];
		gameObject.transform.Find("Armature/Torso/Neck/Head/Head/R_EAR_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [skinColor];
		gameObject.transform.Find("Armature/Torso/BODY_" + gender.ToString() + "/ARMS").gameObject.GetComponent<Renderer>().material = skinColors[skinColor];
		gameObject.transform.Find("Armature/Torso/Neck/Head/Head/nose").transform.GetChild (noseType - 1).gameObject.GetComponent<Renderer> ().material = skinColors [skinColor];


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ HAIR TYPE & COLOR

		hairType = UnityEngine.Random.Range(1, 11);
		hairColor = UnityEngine.Random.Range (0, 4);
		if (gender == 'M') {
			GameObject hair = gameObject.transform.Find("Armature/Torso/Neck/Head/Head/male_hair/" + hairType).gameObject;
			hair.SetActive (true);
			hair.transform.GetChild(0).GetComponent<Renderer> ().material = hairColors [hairColor];
		} else if (gender == 'F') {
			GameObject hair = gameObject.transform.Find("Armature/Torso/Neck/Head/Head/female_hair/" + hairType).gameObject;
            hair.SetActive (true);
			hair.transform.GetChild(0).GetComponent<Renderer> ().material = hairColors [hairColor];
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CLOTHING

		gameObject.transform.Find ("Armature/Torso/BODY_" + gender.ToString () + "/Clothes/tshirt").gameObject.GetComponent<Renderer> ().material.color = new Color (Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ PASSPORT PHOTO

		int photoPercentNum = UnityEngine.Random.Range(1, 101);
		GameObject tempHead = Instantiate (gameObject.transform.Find ("Armature"), new Vector3 (0, 7, -350), Quaternion.Euler(-90,0,0), gameObject.transform).gameObject;
		if (photoPercentNum <= percentWrongPhoto) {
			shouldAccept = false;
			int tempHairType = UnityEngine.Random.Range(1, 11);
			int tempHairColor = UnityEngine.Random.Range(0, 4);
			int tempSkinTone = UnityEngine.Random.Range (0, 4);

			if (gender == 'M') {
				tempHead.transform.GetChild (0).GetChild (hairType - 1).gameObject.SetActive (false);
				GameObject photoHair = gameObject.transform.Find("Head(Clone)").GetChild (0).GetChild (tempHairType - 1).gameObject;
				photoHair.SetActive (true);
				photoHair.transform.GetChild(0).GetComponent<Renderer> ().material = hairColors [tempHairColor];
				int tempBeardType = UnityEngine.Random.Range(1, 8);
				int tempBeardColor = UnityEngine.Random.Range(0, 2);
				tempHead.transform.Find ("beard").transform.GetChild (tempBeardType - 1).gameObject.SetActive (true);
				if(tempBeardType != 7)tempHead.transform.Find("beard/").transform.GetChild (tempBeardType - 1).gameObject.GetComponent<Renderer> ().material = beardColors [tempBeardColor];
			} else if (gender == 'F') {
				tempHead.transform.GetChild (1).GetChild (hairType - 1).gameObject.SetActive (false);
				GameObject photoHair = gameObject.transform.Find("Head(Clone)").GetChild (1).GetChild (hairType - 1).gameObject;
				photoHair.SetActive (true);
				photoHair.transform.GetChild(0).GetComponent<Renderer> ().material = hairColors [tempHairColor];
			}

			tempHead.transform.Find("HEAD_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [tempSkinTone];
			tempHead.transform.Find("R_EAR_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [tempSkinTone];
			tempHead.transform.Find("L_EAR_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [tempSkinTone];
			tempHead.transform.Find("BODY_" + gender.ToString()).gameObject.GetComponent<Renderer> ().material = skinColors [tempSkinTone];
			tempHead.transform.Find("BODY_" + gender.ToString() + "/ARMS").gameObject.GetComponent<Renderer>().material = skinColors[tempSkinTone];
            tempHead.transform.Find("nose").transform.GetChild (noseType - 1).gameObject.GetComponent<Renderer> ().material = skinColors [tempSkinTone];
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ID

		int IdNum = Random.Range (0, 101);
		if (IdNum > percentMissingId) {
			hasId = true;
			CardObj.SetActive (true);
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ PERMIT

		int permitNum = Random.Range (0, 101);
		if (permitNum > percentMissingPermit && country != "Poleryol") {
			hasEntryPermit = true;
			PermitObj.SetActive (true);
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		Choice.State stateAfterRules = RulesManager.Instance.CheckImmigrant(gameObject);

		if (stateAfterRules == Choice.State.SEARCH)
			shouldSearch = true;
		else if (stateAfterRules == Choice.State.DENY)
			shouldAccept = false;
		else if (stateAfterRules == Choice.State.DETAIN)
			shouldDetain = true;


		if (shouldSearch) {
			int contrabandNum = Random.Range (1, 101);
			if (contrabandNum <= percentContraband) {
				shouldDetain = true;
				int contrabandChose = Random.Range (1, 4);
				if(contrabandChose == 1)gameObject.transform.Find ("Contraband/pistol").gameObject.SetActive (true);
				else if(contrabandChose == 2)gameObject.transform.Find ("Contraband/coke").gameObject.SetActive (true);
				else if(contrabandChose == 3)gameObject.transform.Find ("Contraband/grenade").gameObject.SetActive (true);
				else gameObject.transform.Find ("Contraband/bomb").gameObject.SetActive (true);
			}
		}


		if (debug) {
			GameObject textObj = new GameObject ();
			TextMesh textMesh = textObj.AddComponent <TextMesh>();
			if(shouldAccept)textMesh.text += "Accept\n";
			else textMesh.text += "Deny\n";
			if(shouldSearch)textMesh.text += "Search\n";
			if(shouldDetain)textMesh.text += "Detain\n";
			Destroy (textObj, 3);
		}

    }

    private string GetRandomPassportID() {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string str = "";
        char[] stringChars = new char[11];

        for (int i = 0; i < 5; i++) {
            stringChars[i] = chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        stringChars[5] = '-';
        for (int i = 6; i < 11; i++) {
            stringChars[i] = chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        for (int i = 0; i < stringChars.Length; i++) {
            str += stringChars[i].ToString();
        }
        return str;
    }
}
