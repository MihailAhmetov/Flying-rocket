using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RocketMover))]
[RequireComponent(typeof(Rocket))]
public class RocketInput : MonoBehaviour
{
    private RocketMover _mover;
    private Rocket _rocket;

    private void Start()
    {
        _mover = GetComponent<RocketMover>();
        _rocket = GetComponent<Rocket>();
    }

    private void Update()
    {
        if (!_rocket.InTransition)
        {
            if (Input.GetKey(KeyCode.Space))
                _mover.Boost();
            else
                _mover.Stop();

            _mover.Rotate();
        }
    }
}
