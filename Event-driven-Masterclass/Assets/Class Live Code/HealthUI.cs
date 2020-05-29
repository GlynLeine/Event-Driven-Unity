using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        FindObjectOfType<Player>().onHealthChanged += OnHealthChanged;
    }

    public void OnHealthChanged(float health)
    {
        text.text = "HP " + health;
    }
}
