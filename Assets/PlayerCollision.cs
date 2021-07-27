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
        if (collisionInfo.collider.name == "Obstacle")
        {
            Destroy(collisionInfo.collider);
            Health.currentHealth -= 5;
        }

        if (collisionInfo.collider.name == "Item")
        {
            Debug.Log(score);
            Destroy(collisionInfo.collider);
            scoreValue += 5;
            score.text = scoreValue + "";
        }
    }
}
