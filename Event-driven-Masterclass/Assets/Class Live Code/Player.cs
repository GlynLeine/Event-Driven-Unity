using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<AudioSource> footsteps;

    private Vector3 _movementDirectionVector;

    public float health = 100;


    public static System.Action<float> onHealthChanged;

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
    }

    private void sound()
    {
        if (_movementDirectionVector.magnitude > 0)
        {
            int randomFootstepCount = Random.Range(0, footsteps.Count);
            //AudioSource


        }

        if (Input.GetKeyDown(KeyCode.Space))
            SetHealth(health - 1f);
    }
}
