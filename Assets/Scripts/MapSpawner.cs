using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawner : MonoBehaviour
{
    public float offset = 1.3f;
    public GameObject player;
    public bool moveMap = false;
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

    void Update()
    {
        if (moveMap) {
            map = transform.parent.gameObject;
            map.transform.localPosition = new Vector3(transform.position.x, transform.position.x, transform.position.z + 272 - offset);
            
            Component[] transforms;

            transforms = GetComponentsInChildren(typeof(Transform));

            if (transforms != null)
            {
                foreach (Transform t in transforms)
                    t.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
            moveMap = false;
        }
    }
}
