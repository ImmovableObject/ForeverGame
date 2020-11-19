using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	public bool realTime;
	public bool simpleTime;
	float simpleHour;
	
	public static int currentHour;
	public static int currentMinute;
	public static int currentSecond;

	public int fakeHour;
	public int fakeMinute;
	public int fakeSecond;

	string hourString;
	string minuteString;
	string secondString;

	string timeOfDay;

	public int timeSpeed;
	private Text textClock;

	void OnEnable()
	{
		textClock = GetComponent<Text>();
		StartCoroutine(CalculateFalseTime());
	}

	//A Function that is set to loop
	void Update()
	{
		if (realTime)
		{
			RealTime();
		}
		else
		{
			FalseTime();
		}

		if (simpleTime)
		{
			SimplfyTime();
			textClock.text = simpleHour + ":" + minuteString + ":" + secondString + timeOfDay;
		}
		else
			textClock.text = hourString + ":" + minuteString + ":" + secondString;
	}

	void RealTime()
	{
		DateTime time = DateTime.Now;
		hourString = time.Hour.ToString();
		minuteString = LeadingZero(time.Minute);
		secondString = LeadingZero(time.Second);
		textClock.text = hourString + ":" + minuteString + ":" + secondString;

		currentHour = DateTime.Now.Hour;
		currentMinute = DateTime.Now.Minute;
		currentSecond = DateTime.Now.Second;
	}

	IEnumerator CalculateFalseTime()
	{
		yield return new WaitForSeconds(1f);

		fakeMinute = fakeMinute + timeSpeed;

		if (fakeSecond > 59)
		{
			fakeSecond = 0;
			++fakeMinute;
		}
		if (fakeMinute > 59)
		{
			fakeMinute = 0;
			++fakeHour;
		}
		if (fakeHour > 23)
		{
			fakeHour = 0;
		}
		StartCoroutine(CalculateFalseTime());
	}

	void FalseTime()
	{
		currentHour = fakeHour;
		currentMinute = fakeMinute;
		currentSecond = fakeSecond;

		hourString = currentHour.ToString();
		minuteString = LeadingZero(currentMinute);
		secondString = LeadingZero(currentSecond);
	}

	void SimplfyTime()
	{
		simpleHour = currentHour;

		if (currentHour <= 11)
		{
			timeOfDay = " AM";
		}
		if (currentHour >= 12)
		{
			timeOfDay = " PM";
		}

		switch (currentHour)
		{
			case 0:
				simpleHour = 12;
			return;
			case 13:
				simpleHour = 1;
			return;
			case 14:
				simpleHour = 2;
				return;
			case 15:
				simpleHour = 3;
				return;
			case 16:
				simpleHour = 4;
				return;
			case 17:
				simpleHour = 5;
				return;
			case 18:
				simpleHour = 6;
				return;
			case 19:
				simpleHour = 7;
				return;
			case 20:
				simpleHour = 8;
				return;
			case 21:
				simpleHour = 9;
				return;
			case 22:
				simpleHour = 10;
				return;
			case 23:
				simpleHour = 11;
				return;

		}
	}

	string LeadingZero(int n)
    {
		return n.ToString().PadLeft(2, '0');
    }
}
