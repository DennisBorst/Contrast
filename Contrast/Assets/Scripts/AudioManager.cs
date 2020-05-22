using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sources;
    public AudioFile[] audioClips;
    
    public void PlaySound(AudioFragments clip,AudioPlayers audioPlayers)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            if((int)audioClips[i].fragment == (int)clip)
            {
                //AudioSource aSource = audioClips[i].source;
                if(audioClips[i].clip != null)
                {
                    sources[(int)audioPlayers].clip = audioClips[i].clip;
                    sources[(int)audioPlayers].Play();
                }
                break;
            }
        }
    }

    #region Singleton
    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AudioManager(); 
            }

            return instance;
        }
    }
    #endregion
}

public enum AudioFragments
{
    WalkPlayer,
    DeathPlayer,
    Jump,
    TouchDown,
    Respawn,
    WalkEnemy,
    DeathEnemy,
    Hit,
    Alert,
    TreeFalling,
    ElevatorPush,
    ElevatorStop,
    Light,
    CutRope,
    BoulderCrashing,
    MoveBoulder
}

public enum AudioPlayers
{
    Player,
    Enemy,
    Interactable
}

[System.Serializable]
public struct AudioFile
{
    public AudioClip clip;
    public AudioFragments fragment;
}
