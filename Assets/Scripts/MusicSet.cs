using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicSet : MonoBehaviour {
    public List<AudioClip> tracks;
    public static AudioClip currentTrack;
    private AudioClip trackToPlay;
    public static AudioSource _music;

	// Use this for initialization
	void Start ()
    {
        _music = GetComponent<AudioSource>();

        currentTrack = tracks[0];
        trackToPlay = currentTrack;

        _music.clip = trackToPlay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trackToPlay != currentTrack)
        {
            trackToPlay = currentTrack;
            _music.clip = trackToPlay;
            _music.Play();
        }

	    if (Journal.inJournal || Journal.paused)
        {
            currentTrack = tracks[1];
        }
        else
        {
            currentTrack = tracks[0];
        }
	}
}
