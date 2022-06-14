using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateZone : MonoBehaviour
{
    public UnityEvent SpawnNewZone;
    public GameObject zone, camp;
    GameObject pivot;
    public Vector3 offset;
    Respawn playerRespawn;
    bool portalTriggered = false;

    private void Start()
    {
        playerRespawn = FindObjectOfType<Respawn>();
        pivot = GameObject.Find("Pivot");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !portalTriggered)
        {
            portalTriggered = true;
            SpawnZone();
            SpawnNewZone.Invoke();
        }
    }

    public void SpawnZone()
    {
        LevelStats.ZonesCompleted++;
        //GameObject instance = LevelStats.ZonesCompleted % 9 == 0 ? camp : zone;
        GameObject instance = zone;
            
        Vector3 location = LevelStats.ZonesCompleted * offset;
        GameObject newGameObject = Instantiate(instance, location, Quaternion.Euler(Vector3.up * -180f));
        playerRespawn.UpdateIncrement(offset.y);
        playerRespawn.UpdateRespawnPoint(newGameObject.transform.Find("StartPosition").transform);
        playerRespawn.RespawnPlayer();
    }
}
