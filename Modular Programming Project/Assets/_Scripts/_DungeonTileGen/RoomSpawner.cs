using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // - 0 --> spawnLocation
    // - 1 --> has forward door
    // - 2 --> has backward door
    // - 3 --> has left door
    // - 4 --> has right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private float waitTime;
    private float invokeTime;

    void Start() {
        invokeTime = 0.1f;
        waitTime = invokeTime * 5 * 10;
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", invokeTime);
    }

    void Spawn() {
        if (spawned == false) {
            switch (openingDirection) {
                case 1:
                    rand = Random.Range(0, templates.backwardRooms.Length);
                    Instantiate(templates.backwardRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    rand = Random.Range(0, templates.forwardRooms.Length);
                    Instantiate(templates.forwardRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity); break;
                default:
                    // no assigned value.
                    break;
            }
            spawned = true;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SpawnPoint") && openingDirection != 0) {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
