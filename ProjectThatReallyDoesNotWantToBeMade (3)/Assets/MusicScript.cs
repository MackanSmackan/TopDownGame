using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource[] Tracks;
    [SerializeField] float[] voloumes;
    public int Enemies;
    int currentTrack;

    public void AddEnemy()
    {
        currentTrack = 0;
        Enemies += 1;
        foreach(AudioSource TrackValue in Tracks)
        {
            currentTrack += 1;
            if (currentTrack <= Enemies + 1)
            {
                TrackValue.volume = 0.2f;
            }
            else
            {
                TrackValue.volume = 0;
            }
        }
    }

    public void RemoveEnemy()
    {
        if (Enemies >= 1) 
        {
            Enemies -= 1;
        }
        foreach (AudioSource TrackValue in Tracks)
        {
            currentTrack -= 1;
            if (currentTrack <= Enemies + 1)
            {
                TrackValue.volume = 0;
            }
        }
    }
}
