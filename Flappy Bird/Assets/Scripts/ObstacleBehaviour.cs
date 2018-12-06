using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {
	
	[SerializeField] private float moveSpeed;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x - Time.deltaTime * moveSpeed, transform.position.y);
	}
}
