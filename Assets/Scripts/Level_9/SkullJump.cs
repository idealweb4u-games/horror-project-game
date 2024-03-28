using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullJump : MonoBehaviour
{
    public Transform Player;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 8f;

    private Rigidbody rb;
    private Vector3 jumpForce;
    private Vector3 PlayersLastLocation;
    private Vector3 SkullsLastLocation;

    private bool onCooldown = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0f, 1.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !onCooldown)
        {
            PlayersLastLocation = Player.transform.position;
            SkullsLastLocation = transform.position;
            StartCoroutine(JumpAttack());
        }
    }

    private IEnumerator JumpAttack()
    {
        onCooldown = true;
        rb.AddForce(jumpForce * jumpHeight, ForceMode.Impulse);
        yield return new WaitForSeconds(.25f);
        Vector3 direction = (PlayersLastLocation - transform.position).normalized;
        rb.velocity = direction * speed;

        yield return new WaitForSeconds(3.5f);
        transform.position = SkullsLastLocation;
        rb.velocity = Vector3.zero;
        onCooldown = false;
    }
}
