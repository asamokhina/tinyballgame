using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    private Vector3 movingDirection;
    public float totalDistance = 0;
    private Vector3 previousLoc;
    public ParticleSystem explosionParticle;
    public LevelLoader loader;
    private bool hitTheGround = false;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sphere")
        {
            hitTheGround = true;
        }

        if (collision.collider.gameObject.tag == "fireball")

        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            int startScene = 0;
            StartCoroutine(loader.LoadLevel(startScene));
        }
    }

    void RecordDistance()
    {
        totalDistance += Vector3.Distance(transform.position, previousLoc);
        previousLoc = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = 1;

        movingDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (hitTheGround == true)
        {
            rb.MovePosition(
                rb.position + transform.TransformDirection(movingDirection) * speed * Time.deltaTime
            );
            RecordDistance();
        }

    }
}
