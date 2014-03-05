using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public GameObject player;


	// Update is called once per frame
	void Update () {
		const int moveCameraValueX = 4;
		const int moveCameraValueY = 2;
		float distX = transform.position.x - player.transform.position.x;
		float distY = transform.position.y - player.transform.position.y;
		if (distX > moveCameraValueX) 
		{
			transform.position = new Vector3 (player.transform.position.x + moveCameraValueX, transform.position.y, -20);
		}

		else if (distX < -moveCameraValueX) 
		{
			transform.position = new Vector3 (player.transform.position.x - moveCameraValueX, transform.position.y, -20);
		}

		if (distY > moveCameraValueY) 
		{
			transform.position = new Vector3 (transform.position.x, player.transform.position.y + moveCameraValueY, -20);
		}

		else if (distY < -moveCameraValueY) 
		{
			transform.position = new Vector3 (transform.position.x, player.transform.position.y - moveCameraValueY, -20);
		}
	}
}
