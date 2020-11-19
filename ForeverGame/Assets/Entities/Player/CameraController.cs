using Mirror.Examples.OneK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Examples.Pong
{
	public class CameraController : MonoBehaviour
	{
		private float refreshRate = 0.001f;
		public Transform playerTransform;
		public bool Initionalized;
		public Vector3 CameraPosition;

		void OnEnable()
		{
			//StartCoroutine(Refresh());
		}
		//A Function that is set to loop
		void Update()
		{
			//Wait for the time to pass in seconds
			//yield return new WaitForSeconds(refreshRate);
			if (playerTransform == null)
			{
				playerTransform = FindObjectOfType<PlayerMovement>().transform;
			}
			else
			{
				//Initionalized = true;
				transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
				//StartCoroutine(Refresh());
			}
		}
	}
}
