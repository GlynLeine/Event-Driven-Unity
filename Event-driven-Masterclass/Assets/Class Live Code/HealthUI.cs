using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        player.onHealthChanged += OnHealthChanged;
        text.text = "HP " + player.Health;
    }

    public void OnHealthChanged(float health)
    {
        text.text = "HP " + health;
    }
}
