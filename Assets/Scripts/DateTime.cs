using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTime : MonoBehaviour {
	public int level = 1;
    public int day = 29;
    public int month = 11;
    public int year = 1982;

	//8-20?

	//8 -> X2.3 Y117 Z-17

	//20 -> X-10 Y-65 Z-162

	//DIFF X12.3 Y182 Z145

	//ON_IT X0.017 Y0.253 Z0.201

	public int hour = 8;
	public int minute = 0;

	public GameObject clock;
	public GameObject sun;

	private double sunX = 2.3;
	private double sunY = 117;
	private double sunZ = -17;

	private bool nextHourChange = false;

    void Increment() {
		level++;
        day++;
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
            if (day == 32) {
                day = 1;
                month++;
            }
        } else if (month == 2) {
            if (day == 29) {
                day = 1;
                month++;
            }
        } else {
            if (day == 31) {
                day = 1;
                month++;
            }
        }
        if (month == 13) {
            month = 1;
            year++;
        }
    }

	IEnumerator advanceTime(){
		while (hour != 20) {
			yield return new WaitForSeconds (1);
			minute++;
			if (minute == 60) {
				minute = 0;
				hour++;
				clock.transform.Find ("hourArrow").transform.Rotate(Vector3.up, 30);

				if (!nextHourChange)
					nextHourChange = true;
				else {
					GameObject.Find ("RULEBOOK").GetComponent<RulesManager> ().ChangeRules ();
					nextHourChange = false;
				}
			}
			clock.transform.Find ("minuteArrow").transform.Rotate(Vector3.up, 6);

			/*
			sun.transform.rotation = Quaternion.Euler ((float)sunX, (float)sunY, (float)sunZ);
			sunX += 0.2;
			sunY -= 0.253;
			sunZ -= 0.201;
			*/
		}
	}

	void Start(){
		clock.transform.Find ("hourArrow").transform.Rotate(Vector3.up, 8*30);
		StartCoroutine (advanceTime ());

		sunX += 0.2;
		sunY -= 0.253;
		sunZ -= 0.201;
	}

    public string GetDate(int age) {
        int birthYear = year - age;
        int birthMonth = UnityEngine.Random.Range(1, 13);
        int birthDay;

        if (birthMonth == 1 || birthMonth == 3 || birthMonth == 5 || birthMonth == 7 || birthMonth == 8 || birthMonth == 10 || birthMonth == 12) {
            birthDay = UnityEngine.Random.Range(1, 32);
        } else if (birthMonth == 2) {
            birthDay = UnityEngine.Random.Range(1, 29);
        } else {
            birthDay = UnityEngine.Random.Range(1, 31);
        }

        return birthDay.ToString() + "-" + birthMonth.ToString() + "-" + birthYear.ToString();
    }
}
