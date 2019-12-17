using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Object.DontDestroyOnLoad

public class AudioAmbience : MonoBehaviour
{
    [SerializeField] private AudioSource soundTrack;
    [SerializeField] private AudioSource ambience;
    [Space]
    [SerializeField] private AudioClip ambienceOne;
    [SerializeField] private AudioClip ambienceTwo;
    [SerializeField] private AudioClip ambienceThree;
    [Space]
    [SerializeField] private int ambienceTwoScene;
    [SerializeField] private int ambienceThreeScene;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        soundTrack.Play();

        ambience.clip = ambienceOne;
        ambience.Play();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == ambienceTwoScene)
        {
            ambience.clip = ambienceTwo;
            ambience.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == ambienceThreeScene)
        {
            ambience.clip = ambienceThree;
            ambience.Play();
        }
    }
}