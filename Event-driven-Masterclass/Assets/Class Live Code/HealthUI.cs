using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text text;
    public Player player;

    private void OnEnable()
    {
        if (player != null)
        {
            player.OnHealthChanged += OnHealthChanged;
            text.text = "HP " + player.Health;
        }
    }

    private void OnDisable()
    {
        if (player != null)
            player.OnHealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float health)
    {
        text.text = "HP " + health;
    }
}
