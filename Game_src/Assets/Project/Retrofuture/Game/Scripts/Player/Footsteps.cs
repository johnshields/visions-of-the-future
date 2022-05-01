using UnityEngine;
using Random = UnityEngine.Random;

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

    private void Step()
    {
        var clip = RandoClip();
        _audioSource.PlayOneShot(clip);
    }

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