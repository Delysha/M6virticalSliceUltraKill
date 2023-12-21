using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject elevatorPrefab;
    public Transform spawnPoint;
    public float moveSpeed = 5f;
    public float spawnPointY = 10f; // Distance between tube spawns
    public float destroyY = -6f; // Y-coordinate at which the tube is destroyed

    public GameObject currentTube;
    private float tubeLength;

    private void Start()
    {
        tubeLength = GetTubeLength();
 
    }

    private void Update()
    {
        // Check if the tube is below the destroyY, then destroy it
        if (currentTube.transform.position.y <= destroyY)
        {
            Destroy(currentTube);
            SpawnTube(); // Spawn a new tube after destroying the previous one
        }

        MoveTube();
    }

    private void MoveTube()
    {
        // Check if the tube exists before moving it
        if (currentTube != null)
        {
            currentTube.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); // Move down along the Y-axis

            // Check if the tube has moved a distance equal to its length
            if (currentTube.transform.position.y - spawnPoint.position.y >= tubeLength)
            {
                // Adjust the spawn point for a seamless transition
                // spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y - tubeLength, spawnPoint.position.z);
            }
        }
    }

    private void SpawnTube()
    {
        // Instantiate a new tube at the spawn point
        currentTube = Instantiate(elevatorPrefab, spawnPoint.position, Quaternion.identity);

        // Move the spawn point down for the next instantiation
        spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPointY, spawnPoint.position.z);
    }

    // Helper method to get the length of the tube along the Y-axis
    private float GetTubeLength()
    {
        return 25f; // Set the tube length
    }
}
