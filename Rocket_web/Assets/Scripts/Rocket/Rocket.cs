using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelSwitcher))]
[RequireComponent(typeof(AudioSource))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float _boostPower = 1000f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private AudioClip _successAudio;
    [SerializeField] private AudioClip _deathAudio;

    [SerializeField] private ParticleSystem _successVFX;
    [SerializeField] private ParticleSystem _deathVFX;

    private AudioSource _audioSource;
    private LevelSwitcher _levelSwitcher;

    public bool InTransition { get; private set; }

    private void Start()
    {
      
        _levelSwitcher = FindObjectOfType<LevelSwitcher>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (InTransition) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                Transition();
                break;
            default:
                Die();
                break;
        }
    }

    private void Transition()
    {
        InTransition = true;
        _audioSource.volume = 0;
        AudioSource.PlayClipAtPoint(_successAudio, Camera.main.transform.position, 0.3f);
        _successVFX.Play();
        StartCoroutine(_levelSwitcher.LoadNextLevel());
    }

    private void Die()
    {
        InTransition = true;
        _audioSource.volume = 0f;
        AudioSource.PlayClipAtPoint(_deathAudio, Camera.main.transform.position, 0.3f);
        _deathVFX.Play();
        StartCoroutine(_levelSwitcher.ReloadLevel());
    }
}