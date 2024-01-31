using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGun : MonoBehaviour
{
    public GameObject pedestal;
    public GameObject spotlight;
    public GameObject gunModelInScene;
    public BoxCollider boxCollider;
    public GameObject lights;
    public GameObject lightBalls;
    public GameObject titleMusic;
    public AudioSource titleAudioSource;
    public GameObject titleCard;
    public GameObject mainMusic;
    public GameObject enemySpawner;
    public GameObject gun;

    public ShootScript shootScript;

    private void Start()
    {
        shootScript.enabled = false;
        pedestal.SetActive(true);
        lights.SetActive(false);
        lightBalls.SetActive(false);
        titleMusic.SetActive(false);
        titleCard.SetActive(false);
        mainMusic.SetActive(false);
        enemySpawner.SetActive(false);
        gun.SetActive(false);
    }

    private void Update()
    {
        if (!titleAudioSource.isPlaying && titleCard.activeSelf)
        {
            mainMusic.SetActive(true);
            pedestal.SetActive(false);
            titleCard.SetActive(false);
            enemySpawner.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player grabbed the gun, enable lights and delete pedestal
            lights.SetActive(true);
            lightBalls.SetActive(true);
            titleMusic.SetActive(true);
            titleCard.SetActive(true);
            gun.SetActive(true);
            spotlight.SetActive(false);
            gunModelInScene.SetActive(false);
            boxCollider.enabled = false;
            shootScript.enabled = true;
        }
    }
}
