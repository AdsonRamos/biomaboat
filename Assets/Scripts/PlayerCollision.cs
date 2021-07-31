using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text score;
    public int scoreValue = 0;

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Debug.Log (collisionInfo.collider);

        if (collisionInfo.collider.tag == "Obstacles")
        {
            collisionInfo.collider.enabled = false;
            Health.currentHealth -= 5;
        }

        if (collisionInfo.collider.tag == "Item")
        {
            collisionInfo.collider.enabled = false;
            collisionInfo.gameObject.GetComponent<MeshRenderer>().enabled = false;
            scoreValue += 5;
            score.text = scoreValue + "";
        }
    }
}
