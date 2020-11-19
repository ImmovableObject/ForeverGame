using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    //private string currentTime;
	//public float hours;
	public Color[] Fazes;

	Light lightSource;

	SpriteRenderer Sprite;

	public bool LightSource;

	void OnEnable()
	{

		if (LightSource)
		{
			lightSource = GetComponent<Light>();
		}
		if (!LightSource)
		{ 
			Sprite = GetComponent<SpriteRenderer>();
		}
		StartCoroutine(Refresh());
	}

	//A Function that is set to loop
	IEnumerator Refresh()
	{
		//Wait for the time to pass in seconds
		yield return new WaitForSeconds(0.1f);

		if (LightSource)
		{
			SetLight();
		}
		if (!LightSource)
		{
			SetLightSprite();
		}

		StartCoroutine(Refresh());
	}

	private void SetLight()
	{
		if (Clock.currentHour >= 0 && Clock.currentHour <= 5)
		{
			//Night 1
			lightSource.color = Fazes[5];
			return;
		}

		if (Clock.currentHour == 6 || Clock.currentHour == 7)
		{
			//Dawn
			lightSource.color = Fazes[0];
			return;
		}

		if (Clock.currentHour >= 8 && Clock.currentHour <= 11)
		{
			//Morning
			lightSource.color = Fazes[1];
			return;
		}
		if (Clock.currentHour >= 12 && Clock.currentHour <= 16)
		{
			//Day
			lightSource.color = Fazes[2];
			return;
		}
		if (Clock.currentHour == 17 || Clock.currentHour == 18)
		{
			//Twilight
			lightSource.color = Fazes[3];
			return;
		}
		if (Clock.currentHour >= 19 && Clock.currentHour <= 21)
		{
			//Evening
			lightSource.color = Fazes[4];
			return;
		}
		if (Clock.currentHour == 22 || Clock.currentHour == 23)
		{
			//Night 2
			lightSource.color = Fazes[5];
			return;
		}
	}

	private void SetLightSprite()
	{
		if (Clock.currentHour >= 0 && Clock.currentHour <= 5)
		{
			//Night 1
			Sprite.color = Fazes[5];
			return;
		}

		if (Clock.currentHour == 6 || Clock.currentHour == 7)
		{
			//Dawn
			Sprite.color = Fazes[0];
			return;
		}

		if (Clock.currentHour >= 8 && Clock.currentHour <= 11)
		{
			//Morning
			Sprite.color = Fazes[1];
			return;
		}
		if (Clock.currentHour >= 12 && Clock.currentHour <= 16)
		{
			//Day
			Sprite.color = Fazes[2];
			return;
		}
		if (Clock.currentHour == 17 || Clock.currentHour == 18)
		{
			//Twilight
			Sprite.color = Fazes[3];
			return;
		}
		if (Clock.currentHour >= 19 && Clock.currentHour <= 21)
		{
			//Evening
			Sprite.color = Fazes[4];
			return;
		}
		if (Clock.currentHour == 22 || Clock.currentHour == 23)
		{
			//Night 2
			Sprite.color = Fazes[5];
			return;
		}
	}

}
