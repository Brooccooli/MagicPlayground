using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    [SerializeField] private bool _lifeTimeOrDuration = true;
    private ParticleSystem _system;
    private float _lifeTime;

    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        if (_lifeTimeOrDuration)
        {
            _lifeTime = _system.main.startLifetime.constantMax;
        }
        else
        {
            _lifeTime = _system.main.duration;
        }
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
