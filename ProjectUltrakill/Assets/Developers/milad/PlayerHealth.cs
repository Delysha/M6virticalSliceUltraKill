using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public Slider healthBar;
    [SerializeField] public TextMeshProUGUI healthValueDisplay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        healthValueDisplay.text = health.ToString();
    }
}
