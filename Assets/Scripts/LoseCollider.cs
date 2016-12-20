using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManeger;
	void Start()
	{
		levelManeger =  GameObject.FindObjectOfType<LevelManager>();
	}
	void Update ()
	{
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Ball") {
			levelManeger.LoadLevel("Lose");
		}
	}
}
