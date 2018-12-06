using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float thrust, tiltSmooth, hoverDistance, hoverSpeed;
	private bool start;
	private float timer, y;
	private Rigidbody2D playerRigid;
	private Quaternion downRotation, upRotation;
		

	// Use this for initialization
	void Start () {
		playerRigid = GetComponent<Rigidbody2D>();
		downRotation = Quaternion.Euler(0, 0, -90);
		upRotation = Quaternion.Euler(0, 0, 35);

	}
	
	// Update is called once per frame
	void Update () {
		if(!start){
			timer += Time.deltaTime;
			y = hoverDistance * Mathf.Sin(hoverSpeed * timer);
			transform.localPosition = new Vector3 (0, y, 0);
		}else{
			transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
		}		
	}

	void LateUpdate(){
		if(Input.GetMouseButtonDown(0)) {
			if(start){
				// Debug.Log("Hello");
				transform.rotation = upRotation;
				playerRigid.velocity = Vector2.zero;
				playerRigid.AddForce(Vector2.up * thrust);
			}else{
				start = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		// Update Sore
		Destroy(col.gameObject);
		GameManager.Instance.UpdateScore();
	}

	void OnCollision2D(Collision2D col){
		// Kill Flappy
		playerRigid.simulated = false;
		
	}
}
