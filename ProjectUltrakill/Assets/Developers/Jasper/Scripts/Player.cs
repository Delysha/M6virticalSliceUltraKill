using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0 || health == 0)
        {
            deathScreen.SetActive(true);
        }
    }
}
