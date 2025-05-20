using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject enemyPrefab;

    public Transform player;
    public float tileLength = 10f;
    public int tilesOnScreen = 5;

    private float spawnZ = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z - 20 > spawnZ - tilesOnScreen * tileLength)
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
{
    Vector3 spawnPos = new Vector3(0, 0, spawnZ);
    GameObject tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
    activeTiles.Add(tile);

    int randomLane = Random.Range(0, 3);
    float laneX = (randomLane - 1) * 3f;

    Vector3 enemyPos = new Vector3(laneX, 0.5f, spawnZ + tileLength / 2);
    Instantiate(enemyPrefab, enemyPos, Quaternion.identity);

    spawnZ += tileLength;
}


    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

