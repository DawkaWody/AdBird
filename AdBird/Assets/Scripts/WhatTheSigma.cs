using UnityEngine;
using System.Collections;

public class WhatTheSigma : MonoBehaviour
{
    public AudioClip whatTheSigma;
    private AudioSource audioSource;

    public float minTime;
    public float maxTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSound());
    }

    IEnumerator PlayRandomSound()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            audioSource.PlayOneShot(whatTheSigma);
        }
    }
}
