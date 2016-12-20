using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	Rigidbody2D rb2;
	public bool gameStarted = false;
	AudioSource audio;
	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		rb2 = GetComponent<Rigidbody2D>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		if (Input.GetMouseButtonDown (0)) {
			rb2.velocity =  new Vector2(Random.Range(-2f,2f) , 10.0f);
			gameStarted = true;
		}
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		Vector2 tweak = new Vector2 (Random.Range (-.2f, .2f), Random.Range (0f, .2f));

		
		if (gameStarted) {
			audio.Play ();
		}
		rb2.velocity += tweak;
	}
}
