using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour
{

	// Use this for initialization
	public AudioClip crack;
	public static int brickCount = 0;
	public Sprite[] hitSprites;

	private int maxHits;
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;

	private AudioSource audioS;


  


	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			brickCount++;
		}

		maxHits = hitSprites.Length + 1;
		timesHit = 0;

		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void LoadSprites (int spriteNumber)
	{

		if (hitSprites [spriteNumber]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteNumber];
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{
//		audioS.PlayOneShot(crack);
//		print (audioS);
		if (isBreakable) {
			HandleHits ();
		}

	}

	void HandleHits ()
	{
		timesHit++;
		if (timesHit >= maxHits) {
			brickCount--;
			levelmanager.BrickDestoryed();
			Destroy (this.gameObject);
		} else {
			LoadSprites (timesHit - 1);
		}
	}



}
