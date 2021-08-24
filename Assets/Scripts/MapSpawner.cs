using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawner : MonoBehaviour
{
    public float offset = 270.5f;
    public bool moveMap = false;
    public GameObject map;

    private void OnTriggerEnter(Collider collider)
    {   
        if (collider.gameObject.tag == "Player") {
            map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, map.transform.position.z + offset);
        }
    }

    void Update()
    {
        if (moveMap) {
            map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, map.transform.position.z + offset);
            moveMap = false;
        }
    }
}
