using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    //public GameObject player;
    public bool pickedUp = false;
    //particle effect
    [Header("Particles")]
    public ParticleSystem onHit;
    public AudioSource ding;
    //light flicker
    [Header("Lights")]
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    float random;
    //floating
    [Header("Floating")]
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    void Start()
    {
        //Light
        random = Random.Range(0.0f, 65535.0f);

        //Audio
        ding = GetComponent<AudioSource>();

        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    void Update()
    {
        //Light
        float noise = Mathf.PerlinNoise(random, Time.time);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        /*
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            pickedUp = true;
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        if (gameObject.GetComponent<AudioSource>() != null)
            ding.Play();

        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(onHit)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it
        explosionEffect.loop = false;
        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.duration);

        //destroy our game object
        /*
        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        Destroy(gameObject, ding.clip.length);
        */

        Debug.Log("Picked Up " + gameObject.name);


    }
}
