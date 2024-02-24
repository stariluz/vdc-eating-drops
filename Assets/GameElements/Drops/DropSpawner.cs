using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropSpawner : MonoBehaviour
{
    public DropLogic[] ediblesPrefabs;
    public DropLogic[] nastysPrefabs;
    public float spawnInterval = 2f;
    public float screenLimits = 1f;
    private Coroutine currentCoroutine;
    private float totalEdiblesProbability = 1f;
    private float totalNastysProbability = 1f;
    // Start is called before the first frame update
    void Start()
    {
        currentCoroutine = StartCoroutine(SpawnObject());
        totalEdiblesProbability = CalcTotalDropsProbability(ediblesPrefabs);
        totalNastysProbability = CalcTotalDropsProbability(nastysPrefabs);
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
            DropLogic dropToSpawn = ChooseRandomDrop();

            // Instantiate the prefab at the calculated position
            Instantiate(dropToSpawn, new Vector3(randomX, gameObject.transform.position.y, 0), Quaternion.identity);


            // Wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval -= 0.1f;
            spawnInterval = Math.Max(1f, spawnInterval);
        }
    }

    DropLogic ChooseRandomDrop()
    {
        DropLogic chosenPrefab = null;
        string randomDropType = Random.Range(0f, 1f) > 0.6 ? "edible" : "nasty";
        switch (randomDropType)
        {
            case "edible":
                chosenPrefab = GetRandomDrop(ediblesPrefabs, totalEdiblesProbability);
                break;
            case "nasty":
                chosenPrefab = GetRandomDrop(nastysPrefabs, totalNastysProbability);
                break;
        }
        return chosenPrefab;
    }

    DropLogic GetRandomDrop(DropLogic[] drops, float totalProbability)
    {
        float currentRange = 0f;
        DropLogic randomDrop = drops[^1];
        float randomProbability = Random.Range(0f, totalProbability);
        for(int i=1; i<drops.Length; i++)
        {
            if (randomProbability < currentRange)
            {
                randomDrop=drops[i];
                break;
            }
            else
            {
                currentRange += drops[i].probability;
            }
        }
        return randomDrop;
    }

    float CalcTotalDropsProbability(DropLogic[] drops)
    {
        float probability = 0f;
        foreach (var drop in drops)
        {
            probability += drop.probability;
        }
        return probability;
    }
}
