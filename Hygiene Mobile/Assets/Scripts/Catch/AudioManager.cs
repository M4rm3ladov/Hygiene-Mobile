using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    private void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    private void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Catch"){
            Debug.Log("triggered sound");
            Play("Catch_Theme");
        }
            
    }
    public void Play(string name){
        Debug.Log("played");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.source.Play();
    }
    public void ButtonSoundFx(){
        Play("Click");
    }
}
