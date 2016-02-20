using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour {

    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public int efxAudioIndex;

    public AudioSource efxSource1;                   //Drag a reference to the audio source which will play the sound effects.
    public int efxAudioIndex1;

    public AudioSource efxSource2;                   //Drag a reference to the audio source which will play the sound effects.
    public int efxAudioIndex2;

    public Slider s_efxVolume;
    //public float f_efxVolume;
    public int buttonDownIndex = 0;


    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public Slider s_musicVolume;
    public float f_musicVolume;

    public List<AudioClip> audioClipList;


    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        //set the bar to the volume
        if(s_efxVolume != null)
            s_efxVolume.value = efxSource.volume;

        if (s_musicVolume != null)
            s_musicVolume.value = musicSource.volume;

        f_musicVolume = musicSource.volume;
    }

    public void _adjustEfxVolume(float value)
    {
        efxSource.volume = value;
        efxSource1.volume = value;
        efxSource2.volume = value;
    }

    public void _adjustEfxVolume()
    {
        efxSource.volume = s_efxVolume.value;
        efxSource1.volume = s_efxVolume.value;
        efxSource2.volume = s_efxVolume.value;
    }

    public void _adjustMusicVolume(float value)
    {
        musicSource.volume = value;
        f_musicVolume = value;
    }

    public void _adjustMusicVolume()
    {
        musicSource.volume = s_musicVolume.value;
    }

    public void _adjustMusicVolume(float multiplyAmount , bool increase )
    {
        if (increase)
        {
            musicSource.volume *= multiplyAmount;
        }
        else
        {
            musicSource.volume *= (1/multiplyAmount);
        }
    }

    //Used to play single sound clips.
    public void _playSingle(int musicIndex)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        if (!efxSource.isPlaying)
        {
            efxSource.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex = musicIndex;
            //Play the clip.
            efxSource.Play();
        }
        else if (!efxSource1.isPlaying)
        {
            efxSource1.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex1 = musicIndex;
            //Play the clip.
            efxSource1.Play();
        }
        else if (!efxSource2.isPlaying)
        {
            efxSource2.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex2 = musicIndex;
            //Play the clip.
            efxSource2.Play();
        }
        else
        {
            Debug.Log("No more music playing slot");
        }
    }

    //Used to play single sound clips without interuption.
    public void _playSingleWithoutInteruption(int musicIndex)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        if (!efxSource.isPlaying || efxAudioIndex == musicIndex)
        {
            efxSource.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex = musicIndex;
            //Play the clip.
            efxSource.Play();
        }
        else if (!efxSource1.isPlaying || efxAudioIndex1 == musicIndex)
        {
            efxSource1.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex1 = musicIndex;
            //Play the clip.
            efxSource1.Play();
        }
        else if (!efxSource2.isPlaying || efxAudioIndex2 == musicIndex)
        {
            efxSource2.clip = audioClipList[musicIndex];
            //store music index
            efxAudioIndex2 = musicIndex;
            //Play the clip.
            efxSource2.Play();
        }
        else
        {
            Debug.Log("No more music playing slot");
        }
    }


    //Used to play single sound clips.
    public void _playSingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

	public void _stopSingle (int musicIndex)
	{
		efxSource1.clip = audioClipList[musicIndex];
		efxSource1.Stop();
	}


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void _RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
}
