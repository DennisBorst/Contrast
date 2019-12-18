using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    [SerializeField] private VideoClip videoClip;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject levelAudio;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(WaitForEndOfClip());
        anim.enabled = false;
    }

    IEnumerator WaitForEndOfClip()
    {
        yield return new WaitForSeconds((float)videoClip.length);
        Debug.Log("End of clip");
        for(int i = 0; i<96; i++)
        {
            GetComponent<VideoPlayer>().targetCameraAlpha -= 0.01f;
            Debug.Log("Alpha" + i);
            yield return new WaitForSeconds(.01f);
        }
        Debug.Log("Test");
        gameObject.SetActive(false);
        levelAudio.SetActive(true);
        anim.enabled = true;

        yield return null;
    }
}
