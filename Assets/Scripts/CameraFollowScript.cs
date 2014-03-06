using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public Transform player;
	const int minCameraValueY = -4;
	const int moveCameraValueX = 4;
	const int moveCameraValueY = 2;

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (player.position.x +6, transform.position.y, -20);

//		float distX = transform.position.x - player.transform.position.x;
//		float distY = transform.position.y - player.transform.position.y;
//
//		if (player.transform.position.y < minCameraValueY)
//			return;
//
//		if (distX > moveCameraValueX) 
//		{
//			transform.position = new Vector3 (player.transform.position.x + moveCameraValueX, transform.position.y, -20);
//		}
//
//		else if (distX < -moveCameraValueX) 
//		{
//			transform.position = new Vector3 (player.transform.position.x - moveCameraValueX, transform.position.y, -20);
//		}
//
//		if (distY > moveCameraValueY) 
//		{
//			transform.position = new Vector3 (transform.position.x, player.transform.position.y + moveCameraValueY, -20);
//		}
//
//		else if (distY < -moveCameraValueY) 
//		{
//			transform.position = new Vector3 (transform.position.x, player.transform.position.y - moveCameraValueY, -20);
//		}

	}
}
