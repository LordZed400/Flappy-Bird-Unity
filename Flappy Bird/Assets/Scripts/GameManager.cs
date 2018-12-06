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
	private bool start;

	void Start () {
		flappy = Instantiate(playerPrefabs[Random.Range(0,3)], playerPos.position, transform.rotation);
		flappy.transform.parent = playerPos;
		flappyAnim = flappy.GetComponent<Animator>();
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
		// flappyAnim.SetLayerWeight(1, 0);
		// flappyAnim.SetTrigger("Start");
	}

}
