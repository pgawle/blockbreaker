using UnityEngine;
using System.Collections;

public class MusicPLayer : MonoBehaviour
{

	static MusicPLayer instant = null;


	void Awake ()
	{
		if (instant != null) {
			Destroy (gameObject);
		} else {
			instant = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	// Use this for initialization
	void Start ()
	{

		


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
