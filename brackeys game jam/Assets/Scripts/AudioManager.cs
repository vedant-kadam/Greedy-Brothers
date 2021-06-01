using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] audios;

    private void Awake()
    {
        foreach(Sound s in  audios)
        {
           s.soucre = gameObject.AddComponent<AudioSource>();
            s.soucre.clip = s.clip;
            s.soucre.volume = s.volume;
            s.soucre.pitch = s.pitch;

            s.soucre.loop = s.loop;
        }
    }
    private void Start()
    {
       // DontDestroyOnLoad(gameObject);
    }
    public void PlayMe(string soundName)
    {
        foreach  (Sound s in audios)
        {
            if(s.name == soundName)
            {
                s.soucre.Play();
                break;
            }
        }
    }

    public void StopPlaying()
    {
        foreach(Sound si  in audios)
        {
            si.soucre.Stop();
        }
    }
   



}
