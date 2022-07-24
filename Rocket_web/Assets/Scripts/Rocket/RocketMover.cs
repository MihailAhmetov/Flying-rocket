using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Rocket))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _boostPower = 1000f;
    [SerializeField] private float _rotationSpeed = 300f;
    //[SerializeField] private ParticleSystem _engineVFX;

    private Rocket _rocket;

    private Rigidbody _rigidBody;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();
        _rocket = GetComponent<Rocket>();
    }

    public void Boost()
    {
        _rigidBody.AddRelativeForce(Vector3.up * _boostPower * Time.deltaTime);

        _audioSource.volume = 1;

        if (!_rocket.EngineVFX.isPlaying)
            //_engineVFX.Play();
            _rocket.EngineVFX.Play();
    }

    public void Stop()
    {
        _audioSource.volume = 0;
        _rocket.EngineVFX.Stop();
    }

    public void Rotate()
    {
        float deltaZ = -Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        if (deltaZ != 0)
        {
            _rigidBody.freezeRotation = true;
            transform.Rotate(new Vector3(0, 0, deltaZ));
            _rigidBody.freezeRotation = false;
        }
    }
}
