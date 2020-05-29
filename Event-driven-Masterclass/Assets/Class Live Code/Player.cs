﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<AudioClip> footsteps;
    [SerializeField] private ParticleSystem footstepParticles;

    private AudioSource source;
    private Vector3 _movementDirectionVector;

    public float health = 100;


    public System.Action<float> onHealthChanged;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void SetHealth(float newHealth)
    {
        health = newHealth;
        onHealthChanged?.Invoke(newHealth);
    }

    void Update()
    {
        _movementDirectionVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        sound();

        transform.position += _movementDirectionVector.normalized * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
            SetHealth(health - 1f);
    }

    private void sound()
    {
        if (_movementDirectionVector.magnitude > 0)
        {
            int randomFootstepCount = Random.Range(0, footsteps.Count);
            if(!source.isPlaying)
            {
                source.clip = footsteps[randomFootstepCount];
                source.Play();
            }
            Instantiate(footstepParticles, transform.position,Quaternion.identity);

        }
    }
}
