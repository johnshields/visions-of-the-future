using UnityEngine;
using Random = UnityEngine.Random;

/*
 * Footsteps
 * Script ot play sound for player's footsteps.
 * Adapted from; https://youtu.be/Bnm8mzxnwP8
 */
public class Footsteps : MonoBehaviour
{
    public AudioClip[] woodSteps;
    public AudioClip[] concreteSteps;
    public AudioClip[] metalSteps;
    public int mat;
    private string _matName;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        WhatMat();
    }

    // Switch material player is walking on.
    private void WhatMat()
    {
        _matName = mat switch
        {
            0 => "wood",
            1 => "concrete",
            2 => "metal",
            _ => _matName
        };
    }

    // Accessed in Animation Events.
    private void FootSteps()
    {
        var clip = RandoClip();
        _audioSource.PlayOneShot(clip);
    }

    // Play random click according to the right material.
    private AudioClip RandoClip()
    {
        return _matName switch
        {
            "wood" => woodSteps[Random.Range(0, woodSteps.Length)],
            "concrete" => concreteSteps[Random.Range(0, concreteSteps.Length)],
            "metal" => metalSteps[Random.Range(0, metalSteps.Length)],
            _ => null
        };
    }
}