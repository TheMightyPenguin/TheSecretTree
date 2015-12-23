using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip song;
	AudioSource music;
	
	void Start(){
		music = GetComponent<AudioSource>();
		music.clip = song;
		music.loop = true;
		music.Play();
	}

}
