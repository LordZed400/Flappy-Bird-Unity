using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField] private Animator fadeAnim;

	public void ChangeScene(){
		fadeAnim.SetTrigger("Start");
		StartCoroutine("StartGame");
		SoundManager.Instance.PlayTheAudio("Swoosh");
	}

	IEnumerator StartGame(){
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene("Game");
	}

	public void RateGame(){

	}

	public void Leaderboard(){

	}

}
