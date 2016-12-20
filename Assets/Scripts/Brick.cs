using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public int timesHit;
	SpriteRenderer currentSprite;
	public Sprite [] allSprites;
	private LevelManager levelManager;
	public static int brickCount;
	public AudioClip crack;
	public GameObject smoke;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		currentSprite = GetComponent<SpriteRenderer>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		brickCount =  GameObject.FindObjectsOfType<Brick>().Length;
		print(brickCount);
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (brickCount <= 0) {
			levelManager.LoadNextLevel();
		}
	}
	void OnCollisionEnter2D (Collision2D other)
	{

		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (other.gameObject.tag == "Ball") {
			timesHit++;

			if (timesHit >= maxHits) {
				GameObject smokePuff = (GameObject)Instantiate(smoke, transform.position, Quaternion.identity);
				smokePuff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
				brickCount --;
				print(brickCount);
				Destroy (gameObject, .1f);
			} else {
				currentSprite.sprite = allSprites[timesHit];
			}

		}
	}
}
