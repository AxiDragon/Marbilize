using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateZone : MonoBehaviour
{
    UnityEvent spawnNewZone = new UnityEvent();
    public GameObject[] camps;
    public GameObject[] zones;
    GameObject pivot;
    public Vector3 offset;
    Respawn playerRespawn;
    ScoreManager scoreManager;
    BulletInventory bulletInventory;
    Timer timer;
    bool portalTriggered = false;

    private void Start()
    {
        playerRespawn = FindObjectOfType<Respawn>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timer = FindObjectOfType<Timer>();
        bulletInventory = FindObjectOfType<BulletInventory>();
        pivot = GameObject.Find("Pivot");

        spawnNewZone.AddListener(scoreManager.UpdateScore);
        spawnNewZone.AddListener(timer.GetClearZoneTime);
        spawnNewZone.AddListener(bulletInventory.NewRound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !portalTriggered)
        {
            portalTriggered = true;
            SpawnZone();
            spawnNewZone.Invoke();
        }
    }

    public void SpawnZone()
    {
        LevelStats.ZonesCompleted++;

        GameObject instance = LevelStats.ZonesCompleted % LevelStats.nextZone == 0 ? 
            camps[Random.Range(0, camps.Length)] : zones[Random.Range(0, zones.Length)];

        LevelStats.nextZone += 3 + LevelStats.AreasCompleted;

        Vector3 location = LevelStats.ZonesCompleted * offset;
        GameObject newGameObject = Instantiate(instance, location, Quaternion.Euler(Vector3.up * -180f));
        playerRespawn.UpdateIncrement(offset.y);
        playerRespawn.UpdateRespawnPoint(newGameObject.transform.Find("StartPosition").transform);
        playerRespawn.RespawnPlayer();
    }
}
