using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	[SerializeField] private AudioSource point, swoosh, flap, hit;
	private AudioSource playAudio;
	
	void Awake(){
		Instance = this;
	}

	void Start () {
		playAudio = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () 
	{
		
	}

	public void PlayTheAudio(string tempName){
		switch(tempName){
			case "Point": point.Play(); break;
			case "Swoosh": swoosh.Play(); break;
			case "Flap": flap.Play(); break;
			case "Hit": hit.Play(); break;	
		}
	}

}
