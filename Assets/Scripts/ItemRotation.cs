using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    void Update()
    {   
        transform.eulerAngles += new Vector3(0f, 100, 0f) * Time.deltaTime;    
    }
}
