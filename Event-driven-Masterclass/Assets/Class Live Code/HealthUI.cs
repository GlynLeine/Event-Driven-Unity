using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Text text;

    public void OnHealthChanged(float health)
    {
        text.text = "HP " + health;
    }
}
