using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float MinSpeed = 12;
    private const float MaxSpeed = 16;
    private const float MaxTorque = 10;
    private const float XRange = 4;
    private const float YSpawnPos = -3;
    private Rigidbody targetRb;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem particleExplosion;
    // Start is called before the first frame update
    void Start()
        {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        }

    private void OnMouseDown()
        {
        if (gameManager.isGameActive)
            {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(particleExplosion, transform.position, particleExplosion.transform.rotation);
            }
        }

    private void OnTriggerEnter(Collider other)
        {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
            {
            gameManager.GameOver();
            }
        }

    private static Vector3 RandomSpawnPos()
        {
        return new Vector3(Random.Range(-XRange, XRange), YSpawnPos);
        }

    private static float RandomTorque()
        {
        return Random.Range(-MaxTorque, MaxTorque);
        }

    private static Vector3 RandomForce()
        {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
