using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float timer = 1.5f;
    private HeartSystem playerHearts;
    private GameObject explosion;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", timer);
    }

    void Explode()
    {
        // Debug.Log(gameObject.transform.position);
        explosion = Instantiate(explosionPrefab, transform.position + Vector3.down, Quaternion.identity);
        explosion.SetActive(true);
        // Debug.Log(explosion.transform.position);
        // audio
        SoundManager.PlayBombClip();

        // Destroy the bomb and the explosion effect
        Destroy(gameObject, .3f);
        Destroy(explosion, .5f);
    }

}
