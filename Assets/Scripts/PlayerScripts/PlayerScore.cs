using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;
	
	private camerBe cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int lifeCount;
	public static int coinCount;
	public static int scoreCount;

	void Awake() {
		cameraScript = Camera.main.GetComponent<camerBe> ();
	}

	void Start() {
		previousPosition = transform.position;
		countScore = true;
	}

	void Update() {
		CountScore ();
	}

	void CountScore() {
		if (countScore) {
			if(transform.position.y < previousPosition.y) {
				//scoreCount++; 
				Gamaplaycontroller.instance.SetScore(scoreCount);
			}
			
			previousPosition = transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Coin") {
			coinCount++;
			scoreCount += 20;

			Gamaplaycontroller.instance.SetScore(scoreCount);
			Gamaplaycontroller.instance.SetCoinScore(coinCount);

			AudioSource.PlayClipAtPoint(coinClip, target.transform.position);
			target.gameObject.SetActive (false);
		}
		
		if (target.tag == "Life") {
			lifeCount++;
			scoreCount += 30;

			Gamaplaycontroller.instance.SetLifeScore(lifeCount);
			Gamaplaycontroller.instance.SetScore(scoreCount);

			AudioSource.PlayClipAtPoint(lifeClip, target.transform.position);
			target.gameObject.SetActive (false);
		}
		
		if (target.tag == "Bounds" || target.tag == "Deadly") {
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3(500, 500, 0);
			lifeCount--;
			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
			Gamaplaycontroller.instance.GameOverShowPanel(scoreCount, coinCount);
			
			
			
		}
		
		// if (target.tag == "Deadly") {
		// 	cameraScript.moveCamera = false;
		// 	countScore = false;
		// 	transform.position = new Vector3(500, 500, 0);
		// 	lifeCount--;
		// 	//Gamaplaycontroller.instance.GameOverShowPanel(scoreCount, coinCount);
		// 	GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
		// }
	}


} // PlayerScore
















































































