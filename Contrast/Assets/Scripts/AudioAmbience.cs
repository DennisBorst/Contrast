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
    [SerializeField] private int endScene;

    private bool reachedLevelTwo = false;
    private bool reachedLevelThree = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        soundTrack.Play();

        ambience.clip = ambienceOne;
        ambience.Play();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == ambienceTwoScene && !reachedLevelTwo)
        {
            reachedLevelTwo = true;
            ambience.clip = ambienceTwo;
            ambience.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == ambienceThreeScene && !reachedLevelThree)
        {
            reachedLevelThree = true;
            ambience.clip = ambienceThree;
            ambience.Play();
        }

        if(SceneManager.GetActiveScene().buildIndex == endScene)
        {
            Destroy(this.gameObject);
        }
    }
}