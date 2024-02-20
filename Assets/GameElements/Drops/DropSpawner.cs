using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public float spawnSpeed = 4f;
    public float screenLimits = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            // Calculate a random X position within the defined limits
            float randomX = Random.Range(-screenLimits, screenLimits);

            // Instantiate the prefab at the calculated position
            Instantiate(prefabToSpawn, new Vector3(randomX, spawnY, 0), Quaternion.identity);

            // Wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
