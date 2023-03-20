
using UnityEngine;

public class BooController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float detectionRange = 10.0f;

    private Transform player;
    private bool playerIsVisible = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distanceToPlayer);
        if (distanceToPlayer <= detectionRange)
        {
            playerIsVisible = true;
        }
        else
        {
            playerIsVisible = false;
        }

        // Move towards the player if they're not visible
        if (!playerIsVisible)
        {
            moveSpeed = 2.0f;
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Stop moving and turning when in contact with the player
            moveSpeed = 0.0f;
            transform.LookAt(transform.position);
        }
    }

}
