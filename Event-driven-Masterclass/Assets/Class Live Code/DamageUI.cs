using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    private float previousHealth;
    public Text text;

    void Start()
    {
        Player player = FindObjectOfType<Player>();
        previousHealth = player.Health;
        player.onHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(float health)
    {
        text.gameObject.SetActive(true);
        text.text = (previousHealth - health).ToString();
        previousHealth = health;
        StartCoroutine(DisplayCoroutine());
    }

    IEnumerator DisplayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        text.gameObject.SetActive(false);
    }
}
