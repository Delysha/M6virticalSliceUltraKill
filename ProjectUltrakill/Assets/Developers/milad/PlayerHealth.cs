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
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject gun;
    [SerializeField] private MouseLook mouseLook;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        healthValueDisplay.text = health.ToString();

        if (health <= 0 || health == 0)
        {
            deathScreen.SetActive(true);
            ui.SetActive(false);
            gun.SetActive(false);
            mouseLook.enabled = false;
        }
    }
}
