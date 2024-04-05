using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicController : MonoBehaviour
    {
        AudioSource audio;
        AudioClip music;
        string songName;
        bool played;
        void Start()
        {
            songName = "y2mate.com-For-a-Few-Dollars-More—[—z‚ÌƒKƒ“ƒ}ƒ“Ennio-Morricone_320kbps";
            audio = GetComponent<AudioSource>();
            music = (AudioClip)Resources.Load(songName);
            played = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !played)
            {
                TimeManager.instance.Start = true;
                TimeManager.instance.StartTime = Time.time;
                played = true;
                audio.Play();
            }
        }

    }
}
