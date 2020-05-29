using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    private float previousHealth;
    [SerializeField] private Text text;
    public Player player;

    void OnEnable()
    {
        if (player != null)
        {
            previousHealth = player.Health;
            player.OnHealthChanged += OnHealthChanged;
        }
    }

    private void OnDisable()
    {
        if (player != null)
            player.OnHealthChanged -= OnHealthChanged;
    }

    void OnHealthChanged(float health)
    {
        text.enabled = true;
        text.text = (previousHealth - health).ToString();
        previousHealth = health;
        StartCoroutine(DisplayCoroutine());
    }

    IEnumerator DisplayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        text.enabled = false;
    }
}
