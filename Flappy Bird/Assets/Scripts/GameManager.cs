using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform playerPos;
	[SerializeField] private Sprite[] backgroundImage;
	[SerializeField] private SpriteRenderer background;
	[SerializeField] private Animator getReadyAnim, flappyAnim;

	private GameObject flappy;

	void Start () {
		flappy = Instantiate(playerPrefabs[Random.Range(0,3)], playerPos.position, transform.rotation);
		flappyAnim = flappy.GetComponent<Animator>();
		background.sprite = backgroundImage[Random.Range(0,2)];
	}
	
	void Update () {
		
	}

	public void GetReady(){
		getReadyAnim.SetTrigger("Start");
		flappy.GetComponentInChildren<Rigidbody2D>().gravityScale = 0.5f;
		// flappyAnim.SetLayerWeight(1, 0);
		flappyAnim.SetTrigger("Start");

	}

}
