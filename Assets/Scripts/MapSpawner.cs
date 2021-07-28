using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawner : MonoBehaviour
{
    public float offset = 1.3f;
    public GameObject player;
    private GameObject map;
    // private MeshCollider mapCollider;
    // private BoxCollider playerCollider;
    void Start()
    {   
        // mapCollider = GameObject.FindGameObjectWithTag("MapCollider").GetComponent<MeshCollider>();
        // playerCollider = player.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter()
    {   
        map = transform.parent.gameObject;
        map.transform.position = new Vector3(transform.position.x, transform.position.x, transform.position.z + 272 - offset);
    }

    // void Update()
    // {
    //     if (mapCollider.bounds.Contains(playerCollider.bounds.center)) {
    //         transform.position = new Vector3(transform.position.x, transform.position.x, transform.position.z + 272 + offset);
    //     }
    // }
}
