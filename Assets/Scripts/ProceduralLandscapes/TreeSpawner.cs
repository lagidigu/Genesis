using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    [SerializeField] GameObject Tree;
    [SerializeField] int amount;
    [SerializeField] Vector2 spawnBounds;
    [SerializeField] float minDistanceBetweenTrees;

    List<Transform> spawnedTrees;

    private void Start()
    {
        InitVars();
        SpawnTrees();
    }

    void InitVars()
    {
        spawnedTrees = new List<Transform>();
    }

    void SpawnTrees()
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnTree();
        }
    }

    void SpawnTree()
    {
        GameObject g = Instantiate(Tree, GenerateSpawnPoint(), Quaternion.identity, transform) as GameObject;
        spawnedTrees.Add(g.transform);
    }

    Vector3 GenerateSpawnPoint()
    {
        Vector3 spawnPoint;
        float x, y, z;
        do
        {
            x = Random.Range(spawnBounds.x, spawnBounds.y);
            y = 0;
            z = Random.Range(spawnBounds.x, spawnBounds.y);

            spawnPoint = new Vector3(x, y, z);
        } while (IsTooCloseToTree(spawnPoint));
        return spawnPoint;
    }

    bool IsTooCloseToTree(Vector3 pos)
    {
        for (int i = 0; i < spawnedTrees.Count; i++)
        {
            if ((spawnedTrees[i].position - pos).magnitude < minDistanceBetweenTrees)
            {
                return true;
            }
        }
        return false;
    }
}
