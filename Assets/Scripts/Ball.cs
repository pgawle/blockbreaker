using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

	private Paddle paddle;

	private Vector3 paddleToVector;

	private bool hasStarted = false;

	private Rigidbody2D rigi;


	private AudioSource audioS;
	public AudioClip boing;
	public AudioClip crack;


	private void Awake ()
	{
		rigi = GetComponent<Rigidbody2D> ();
	}



	// Use this for initialization
	void Start ()
	{

		paddle = GameObject.FindObjectOfType<Paddle> ();
		audioS = GetComponent<AudioSource> ();

		paddleToVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (hasStarted == false) {
			this.transform.position = paddle.transform.position + paddleToVector;
		}


		if (Input.GetMouseButtonDown (0) && hasStarted != true) {
			hasStarted = true;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
		}


	}



	float hitFactor (Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
	{
		return (ballPos.x - paddlePos.x) / paddleHeight;
	}

	void OnCollisionEnter2D (Collision2D col)
	{


//	print(col.collider.tag);
//		if (col.collider.tag == "Paddle") {
//			float x = hitFactor (transform.position,
//				col.transform.position,
//				col.collider.bounds.size.x);
//
//			Vector2 dir = new Vector2(1, x).normalized;
//
//        // Set Velocity with dir * speed
//				rigi.velocity += dir;
//		}
//


		Vector2 tweak = new Vector2 (Random.Range (0.0f, 0.2f), Random.Range (0.0f, 0.2f));
		audioS.PlayOneShot (boing);
		if (col.collider.tag == "Breakable") {
			audioS.PlayOneShot (crack);
		}
	
		rigi.velocity += tweak;

	}
}
