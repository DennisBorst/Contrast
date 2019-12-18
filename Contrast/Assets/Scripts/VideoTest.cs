using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTest : MonoBehaviour
{
    [SerializeField] private VideoClip videoClip;
    [SerializeField] private Animator anim;

    [SerializeField] private int menuScene;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(WaitForEndOfClip());
        anim.enabled = false;
    }

    IEnumerator WaitForEndOfClip()
    {
        yield return new WaitForSeconds((float)videoClip.length);

        gameObject.SetActive(false);
        anim.enabled = true;

        yield return null;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
