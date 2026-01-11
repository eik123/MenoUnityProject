using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip song1;
    private ArrayList songs = new ArrayList();
    private string currentSong;
    //private string previousSong;

    void Start()
    {
        songs.Add(song1);
        NewMusic();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        if (audioSource.time == 0)
        {
            NewMusic();
        }
    }

    void NewMusic()
    {

        AudioClip newSong = (AudioClip)songs[Random.Range(0, songs.Count)];
        audioSource.clip = newSong;
        audioSource.Play();
        currentSong = newSong.name;
    }
}
