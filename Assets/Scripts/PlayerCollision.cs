using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PlayerCollision : MonoBehaviour
{
    public Text score;
    public int scoreValue = 0;
    public GameObject explosionPrefab;
    public AudioClip collectMusic;
    public AudioClip explosionMusic;

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log (collisionInfo.collider);

        if (collider.tag == "Obstacles")
        {   
            collider.GetComponent<MeshRenderer>().enabled = false;
            Health.currentHealth -= 10;
            StartCoroutine(PlayExplosion());
        }

        if (collider.tag == "Item")
        {
            collider.GetComponent<MeshRenderer>().enabled = false;
            PlayCollectMusic();
            scoreValue += 5;
            score.text = scoreValue + "";
        }
    }

    IEnumerator PlayExplosion() 
    {
        GameObject explosionGameObj = Instantiate (explosionPrefab) as GameObject;
        explosionGameObj.transform.parent = transform;
        explosionGameObj.transform.localPosition = new Vector3(0,0,0);
        explosionGameObj.transform.localScale = new Vector3(10,10,10);
        explosionGameObj.transform.localRotation = new Quaternion(-0.26f,0,0,0.96f);
        explosionGameObj.GetComponent<ParticleSystem>().Play();
        ShakeCamera();
        PlayExplosionMusic();
        yield return new WaitForSeconds(3);
        explosionGameObj.transform.parent = null;
        Destroy(explosionGameObj);
    }

    void ShakeCamera() 
    {
        CameraShake shaker = gameObject.GetComponent<CameraShake>();
        shaker.Shake();
    }

    private void PlayExplosionMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = explosionMusic;
        audio.Play();
    }

    private void PlayCollectMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = collectMusic;
        audio.Play();
    }
}
