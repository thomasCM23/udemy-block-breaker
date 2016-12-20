using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			Auto_Play();
		}
	
	}
	void MoveWithMouse()
	{
		Vector2 vecPos = new Vector2(.5f, transform.position.y);
		float mousePos = (Input.mousePosition.x/ Screen.width) * 16;
		vecPos.x = Mathf.Clamp(mousePos, .5f, 15.5f);
		this.transform.position = vecPos;
	}
	void Auto_Play()
	{
		Vector2 vecPos = new Vector2(.5f, transform.position.y);
		Vector3 ballPos =  ball.transform.position;
		vecPos.x = Mathf.Clamp(ballPos.x, .5f, 15.5f);
		this.transform.position = vecPos;
	}
}
