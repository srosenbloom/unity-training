using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSauce : MonoBehaviour
{
    public GameObject sauce;
    public AudioSource talk;

    private bool hasTalkPlayed;
    private bool hasStarted;

    GameObject SpawnRandom(float mass, float size)
    {
        var newX = (float)Math.Floor(Random.value * 20) - 10;
        var newY = (float)Math.Floor(Random.value * 10) + 3;
        var newZ = (float)Math.Floor(Random.value * 30) - 20;
        var rotX = (float)Math.Floor(Random.value * 180) - 90;
        var rotY = (float)Math.Floor(Random.value * 180) - 90;
        var rotZ = (float)Math.Floor(Random.value * 180) - 90;
        var newSauce = Instantiate(sauce, new Vector3(newX, newY, newZ), Quaternion.Euler(rotX, rotY, rotZ));
        var newRb = newSauce.GetComponent<Rigidbody>();
        newRb.mass = mass * (float)Math.Floor(Random.value * 200);
        newRb.useGravity = true;
        newSauce.transform.localScale += new Vector3(size - 1, size - 1, size - 1);
        return newSauce;
    }

    // Update is called once per frame
    void Update()
    {
        if (talk.isPlaying)
        {
            hasTalkPlayed = true;
        }

        if (hasTalkPlayed && !talk.isPlaying && !hasStarted)
        {
            hasStarted = true;
        }

        if (hasStarted)
        {
            SpawnRandom(1, 1);
        }
    }
}
