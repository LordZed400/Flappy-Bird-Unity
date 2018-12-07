using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform playerPos;
	[SerializeField] private Sprite[] backgroundImage;
	[SerializeField] private SpriteRenderer background;
	[SerializeField] private Animator getReadyAnim, cameraAnim;
	[SerializeField] private Text gameScoreText;
	[SerializeField] private GameObject[] endButtons;
	[SerializeField] private Animator endAnimations, fadeAnim;

	private GameObject flappy;
	private bool ready, start, end;
	private int gameScore;

	void Awake () {
		Instance = this;
	}

	void Start () {
		ready = true;
		flappy = Instantiate (playerPrefabs[Random.Range (0, 3)], playerPos.position, transform.rotation);
		flappy.transform.parent = playerPos;
		background.sprite = backgroundImage[Random.Range (0, 2)];
	}

	void Update () {
		if (ready && !start) {
			if (Input.GetMouseButtonDown (0)) {
				ready = false;
				start = true;
			}
		}
	}

	public void GetReady () {
		getReadyAnim.SetTrigger ("Start");
		flappy.GetComponentInChildren<Rigidbody2D> ().velocity = Vector2.zero;
		flappy.GetComponentInChildren<Rigidbody2D> ().gravityScale = 1f;
	}

	public void UpdateScore () {
		gameScore++;
		gameScoreText.text = gameScore + "";
		SoundManager.Instance.PlayTheAudio("Point");
	}

	public bool GameState () {

		return start;
	}

	public void EndGame () {
		start = false;
		if(!end){
			if(gameScore > PlayerPrefs.GetInt("Score")){
				PlayerPrefs.SetInt("Score", gameScore); 
			}
			end = true;
			GameManager.Instance.StartCoroutine("GameOver");
			SoundManager.Instance.PlayTheAudio("Hit");
		}
	}

	IEnumerator GameOver () {
		endAnimations.SetTrigger("End");
		yield return new WaitForSeconds (0.5f);
		SoundManager.Instance.PlayTheAudio("Swoosh");
		gameScoreText.enabled = false;
		yield return new WaitForSeconds (1f);
		SoundManager.Instance.PlayTheAudio("Swoosh");
		yield return new WaitForSeconds (0.5f);
		foreach(GameObject endButton in endButtons){
			endButton.SetActive(true);
		}
	
	}

	public void Replay(){
		fadeAnim.SetTrigger("Start");
		StartCoroutine("StartGame");
		SoundManager.Instance.PlayTheAudio("Swoosh");
	}

	IEnumerator StartGame(){
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Leaderboard(){

	}

}