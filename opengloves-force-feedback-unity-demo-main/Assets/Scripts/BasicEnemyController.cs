using System.Collections;
using UnityEngine;


public class BasicEnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float detectionRange = 30f;
    public float firingRange = 10.0f;
    public float wanderDistance = 10.0f;
    public float turnSpeed = 3.0f;

    private Transform player;
    private bool playerDetected = false;
    private bool IdleRunning = false;

    Animator animator;


    private IEnumerator Idle()
    {
        IdleRunning = true;
        // Loop forever 
        while (!playerDetected)
        {
            
            // Choose a random wander direction
            Vector3 wanderDirection = Random.insideUnitSphere * wanderDistance;
            wanderDirection.y = 0; // Set y to 0 to prevent vertical movement

            // Rotate towards the wander direction
            Debug.Log("Turning");
            Quaternion targetRotation = Quaternion.LookRotation(wanderDirection);
            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));

            // Move forward in the current direction
            float elapsedTime = 0.0f;
            float moveDuration = 2;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = transform.position + transform.forward * 4.0f;
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Wait for a random amount of time before choosing a new direction
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
            yield return new WaitForSeconds(1.0f);
        }
    }




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Idle());
        IdleRunning = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
    }

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log("Distance to player: " + distanceToPlayer);
        if (distanceToPlayer < detectionRange)
        {
            playerDetected = true;
            StopCoroutine(Idle());
            IdleRunning = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
            
        }
        else
        {
            animator.SetBool("isAttacking", false);
            playerDetected = false;
            if (!IdleRunning)
            {
                StartCoroutine(Idle());
                animator.SetBool("isIdle", true);
            }
        }

        // Move towards the player if they're not visible

        if (distanceToPlayer > firingRange && playerDetected)
        {
            animator.SetBool("isAttacking", false);
            moveSpeed = 3.0f;
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            Debug.Log("Not in attack range");
            Debug.Log(distanceToPlayer);
        }
        else if (playerDetected && distanceToPlayer <= firingRange)
        {
            Debug.Log("In attack range");

            // Add shooting logic for shooting enemies
            animator.SetBool("isAttacking", true);
            //

            // Stop moving and turning when in contact with the player
            moveSpeed = 0.0f;
           
        }
    }
}
