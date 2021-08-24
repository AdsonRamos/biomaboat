using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectSpawner : MonoBehaviour
{
    public bool randomizePositions = false;
    public GameObject obstacles;
    public GameObject items;
    private List<float> xPositions = new List<float>(3);

    void Start()
    {   
        xPositions.Add(-7f);
        xPositions.Add(-3.5f);
        xPositions.Add(-0.5f);
        SpawnObjects();
    }
    
    private void OnTriggerEnter(Collider collider)
    {   
        if (collider.gameObject.tag == "Player") {
            SpawnObjects();
        }
    }

    public void SpawnObjects()
    {
        foreach (Transform obstacle in Helper.FindComponentsInChildrenWithTag<Transform>(obstacles, "Obstacles")) { 
            if (obstacle.name != "Tree") {
                int index = Mathf.CeilToInt(Random.Range(0, 3));
                obstacle.gameObject.GetComponent<MeshRenderer>().enabled = true;
                obstacle.position = new Vector3(xPositions[index], obstacle.transform.position.y, obstacle.transform.position.z);
            }
        }
        foreach (Transform item in Helper.FindComponentsInChildrenWithTag<Transform>(items, "Item")) { 
            int index = Mathf.CeilToInt(Random.Range(0, 3));
            item.gameObject.GetComponent<MeshRenderer>().enabled = true;
            // obstacle.position = new Vector3(xPositions[index], obstacle.transform.position.y, obstacle.transform.position.z);
        }
    }

    void Update() {
        if (randomizePositions) {
            SpawnObjects();
            randomizePositions = false;
        }
    }
}
