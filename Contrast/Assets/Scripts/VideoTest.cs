using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    [SerializeField] private VideoClip videoClip;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(WaitForEndOfClip());
        anim.enabled = false;
    }

    IEnumerator WaitForEndOfClip()
    {
        yield return new WaitForSeconds((float)videoClip.length);

        Debug.Log("Test");
        gameObject.SetActive(false);
        anim.enabled = true;

        yield return null;
    }
}
