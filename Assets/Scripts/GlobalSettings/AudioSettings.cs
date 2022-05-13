using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{

    #region Singleton
    public static AudioSettings instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;

            foreach (Sound s in sounds) {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.music ? musicVolume * 0.1f : soundVolume * 0.1f;
                s.source.loop = s.loop;
                s.source.pitch = s.pitch;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    [Range(0, 100)]
    public int soundVolume = 50;
    [Range(0, 100)]
    public int musicVolume = 50;
    public Sound[] sounds;

    public void UpdateSoundVolume(int volume) {
        if (volume >= 0 && volume <= 100) {
            this.soundVolume = volume;
            UpdateSoundsVolumes();
        }
    }

    public void UpdateMusicVolume(int volume) {
        if (volume >= 0 && volume <= 100) {
            this.musicVolume = volume;
            UpdateSoundsVolumes();
        }
    }

    private void UpdateSoundsVolumes() {
        foreach (Sound s in sounds) {
            float newVolume = s.music ? musicVolume : soundVolume;
            s.source.volume = newVolume * 0.01f;
        }
    }

    public void PlaySound (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null) {
            if (s.music) {

                if (s.source.isPlaying) {
                    return;
                }

                StopAllMusics();
            }
            s.source.Play();
        }
    }

    public void StopAllMusics() {
        foreach (Sound sound in sounds) {
            if (sound.music) {
                sound.source.Stop();
            }
        }
    }


}
