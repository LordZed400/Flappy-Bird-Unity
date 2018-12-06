using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform playerPos;
	[SerializeField] private Sprite[] backgroundImage;
	[SerializeField] private SpriteRenderer background;
	[SerializeField] private Animator getReadyAnim;
	[SerializeField] private Text gameScoreText;

	private GameObject flappy;
	private bool start;
	private int gameScore;

	void Awake(){
		Instance = this;
	}

	void Start () {
		flappy = Instantiate(playerPrefabs[Random.Range(0,3)], playerPos.position, transform.rotation);
		flappy.transform.parent = playerPos;
		background.sprite = backgroundImage[Random.Range(0,2)];
	}
	
	void Update () {
		if(!start){
			if(Input.GetMouseButtonDown(0)){
				start = true;
				GetReady();
			}
		}
	}

	public void GetReady(){
		getReadyAnim.SetTrigger("Start");
		flappy.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
		flappy.GetComponentInChildren<Rigidbody2D>().gravityScale = 1f;
	}

	public void UpdateScore(){
		gameScore++;
		gameScoreText.text = gameScore + "";
	}

	public bool GameState(){
		return start;
	}


}
