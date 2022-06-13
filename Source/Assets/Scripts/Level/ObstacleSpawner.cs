using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    int obstaclePoints;
    Vector3 dev;
    Collider coll;

    void Start()
    {
        obstaclePoints = LevelStats.Difficulty;
        coll = GetComponent<Collider>();
        dev = coll.bounds.extents;
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        List<Obstacle> obstacles = Resources.LoadAll<Obstacle>("").ToList();
        print(obstacles.Count);

        for (int i = 0; i < obstacles.Count; i++)
        {
            print(obstacles[i]);
        }

        while (obstacles.Count > 0 || obstaclePoints != 0)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].cost > obstaclePoints)
                    obstacles.RemoveAt(i);   
            }

            int randomObstacle = Random.Range(0, obstacles.Count - 1);
            SpawnObstacle(obstacles[randomObstacle]);
        }
    }

    private void SpawnObstacle(Obstacle obs)
    {
        obstaclePoints -= obs.cost;
        Vector3 randomPosition;

        while (true)
        {
            randomPosition = transform.position + 
                new Vector3(Random.Range(-dev.x, dev.x), 100f, Random.Range(-dev.z, dev.z));

            if (IsInside(randomPosition))
                break;
        }



        GameObject obstacleInstance = Instantiate(obstacle, randomPosition, Quaternion.identity);

        obstacleInstance.transform.localScale = obs.size;
        obstacleInstance.GetComponent<ObstacleInstance>().AssignObstacleStats(obs);
        obstacleInstance.GetComponent<Rigidbody>().mass = obs.mass;
        obstacleInstance.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", obs.texture);
    }

    bool IsInside(Vector3 point)
    {
        Vector3 closest = coll.ClosestPoint(point);
        return closest == point;
    }
}
