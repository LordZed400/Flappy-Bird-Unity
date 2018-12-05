using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float thrust;
	private bool start;
	private Rigidbody2D playerRigid;

	// Use this for initialization
	void Start () {
		thrust = 80f;
		playerRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		if(Input.GetMouseButtonDown(0)) {
			if(start){
				Debug.Log("Hello");
				playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0);
				playerRigid.AddForce(transform.up * thrust);
			}
			start = true;
		}
	}
}
