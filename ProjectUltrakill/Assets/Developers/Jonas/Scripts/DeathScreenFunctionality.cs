using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenFunctionality : MonoBehaviour
{
    public GameObject deathScreen;

    private void Update()
    {
        if(deathScreen.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}
