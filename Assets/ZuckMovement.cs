using System;
using UnityEngine;

public class ZuckMovement : MonoBehaviour
{
    public AudioSource talk;
    public Rigidbody rb;
    public float movementSpeedX;
    public float movementSpeedZ;

    private bool finishedMoving;
    private bool talkStarted;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(movementSpeedX * rb.mass * Time.deltaTime, 0, -movementSpeedZ * rb.mass * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.z <= -7)
        {
            finishedMoving = true;
            if (!talkStarted)
            {
                talkStarted = true;
                talk.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        if (finishedMoving)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
