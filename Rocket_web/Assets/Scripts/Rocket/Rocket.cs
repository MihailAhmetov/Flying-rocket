using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(RocketMover))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private AudioClip _successAudio;
    [SerializeField] private AudioClip _deathAudio;

    [SerializeField] private ParticleSystem _successVFX;
    [SerializeField] private ParticleSystem _deathVFX;
    [SerializeField] private ParticleSystem _engineVFX;

    [SerializeField] private LevelSwitcher _levelSwitcher;

    private AudioSource _audioSource;
    private RocketMover _mover;

    public ParticleSystem EngineVFX => _engineVFX;

    public bool InTransition { get; private set; }

    private void Start()
    {
        _mover = GetComponent<RocketMover>();

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
        
        _mover.Stop();
        _deathVFX.Play();
        
        AudioSource.PlayClipAtPoint(_deathAudio, Camera.main.transform.position, 0.3f);

        StartCoroutine(_levelSwitcher.ReloadLevel());
    }
}
