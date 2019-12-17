using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Aparte audioSources
    [SerializeField] private AudioSource footSteps;
    [SerializeField] private AudioSource elevatorMoving;

    //Samen 1 audioSource
    [SerializeField] private AudioSource bridgeFalling;
    [SerializeField] private AudioSource cutRope;
    [SerializeField] private AudioSource enemyKill;

    public void FootSteps()
    {

    }

    public void ElevatorMoving()
    {

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
