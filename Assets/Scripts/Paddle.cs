using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

	// Use this for initialization

	public bool autoplay;

	private Ball ball;


	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		print(autoplay);

		if (autoplay == true) {
			AutoPlay ();
		} else {
			MoveWithMouse ();		
		}

	}

	void AutoPlay ()
	{
		Vector3 paddlePos = new Vector3 (0.0f, this.transform.position.y, 0.0f);

		float mousePosInBlocks = ball.transform.position.x;

		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);

		this.transform.position = paddlePos;

	}


	void MoveWithMouse ()
	{
		Vector3 paddlePos = new Vector3 (0.0f, this.transform.position.y, 0.0f);

		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);

		this.transform.position = paddlePos;
	}
}
