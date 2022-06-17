using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public Obstacle[] obstacleArray;
    public Obstacle tokenBox;
    public Obstacle hans;
    public float startingWidth = 10f;
    int obstaclePoints;
    public int amount;
    Vector3 dev;
    BoxCollider coll;
    LayerMask ignoreLayer;

    void Start()
    {
        LevelStats.CurrentZone = transform.root.gameObject;
        obstaclePoints = LevelStats.Difficulty / amount;
        coll = GetComponent<BoxCollider>();
        coll.size = new Vector3(coll.size.x, coll.size.y, startingWidth + Mathf.Sqrt(obstaclePoints));
        dev = coll.bounds.extents;
        ignoreLayer = LayerMask.GetMask("Ignore Raycast");
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        List<Obstacle> obstacles = obstacleArray.ToList();
        int tokensSpawned = 0;

        while (obstacles.Count > 0 && obstaclePoints != 0)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].cost > obstaclePoints)
                    obstacles.RemoveAt(i);
            }

            if (obstacles.Count > 0)
            {
                if (Random.value < ItemStats.tokenBoxChance && tokensSpawned < ItemStats.tokenBoxLimit)
                {
                    tokensSpawned++;
                    SpawnObstacle(tokenBox);
                }
                else
                {
                    int randomObstacle = Random.Range(0, obstacles.Count);
                    SpawnObstacle(obstacles[randomObstacle]);
                }

            }
        }
    }

    private void SpawnObstacle(Obstacle obs)
    {
        Vector3 randomPosition = GetRandomPosition();
        Vector3 finalPosition;

        RaycastHit hit;
        Ray ray = new Ray(randomPosition + Vector3.up * 100f, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayer))
        {
            obstaclePoints -= obs.cost;

            finalPosition = hit.point + Vector3.up * obs.size.y;
            Debug.DrawLine(transform.position, hit.point, Color.red, 15f);

            GameObject obstacleInstance = Instantiate(obstacle, finalPosition, Quaternion.identity);

            float intensityValue = 600f / Mathf.Sqrt(obs.mass);

            obstacleInstance.transform.localScale = obs.size;
            obstacleInstance.GetComponent<ObstacleInstance>().AssignObstacleStats(obs);
            obstacleInstance.GetComponent<Rigidbody>().mass = obs.mass;
            obstacleInstance.GetComponent<MeshRenderer>().material.SetTexture("_BaseTexture", obs.texture);
            obstacleInstance.GetComponent<MeshRenderer>().material.SetFloat("_Intensity", intensityValue);
            obstacle.name = obs.name;
        }
    }

    bool IsInside(Vector3 point)
    {
        Vector3 closest = coll.ClosestPoint(point);
        return closest == point;
    }

    Vector3 GetRandomPosition()
    {
        bool isInside = false;
        Vector3 randomPos = Vector3.zero;

        while (!isInside)
        {
            randomPos = transform.position +
                new Vector3(Random.Range(-dev.x, dev.x), 0f, Random.Range(-dev.z, dev.z));

            isInside = IsInside(randomPos);
        }

        return randomPos;
    }
}
