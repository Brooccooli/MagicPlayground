using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnParticleHit : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _knockbackMultiplier = 2;
    private ParticleSystem _system;
    private List<ParticleCollisionEvent> _collisionEvents;
    
    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        _collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = _system.GetCollisionEvents(other, _collisionEvents);
        
        Instantiate(_objectToSpawn, _collisionEvents[0].intersection, transform.rotation);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = _collisionEvents[i].intersection;
                Vector3 force = _collisionEvents[i].velocity;
                rb.AddForce(force * _knockbackMultiplier, ForceMode.Impulse);
            }
            i++;
        }
    }
}
