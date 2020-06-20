using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    [Header("Assignables")]
    public Rigidbody rigidbody;

    [Space()]

    public AudioSource[] JumpSFX;

    [Space()]

    [Header("Attributes")]
    [Range(0f, 5f)]  public float moveSpeed    = 6f;
    [Range(0f, 10f)] public float jumpForce    = 1f;

    // Private Variables
    private int rand;

    private bool isGrounded;

    void FixedUpdate()
    {
        // ---References--- \\

        for (int i = 0; i < JumpSFX.Length; i++)
        {
            rand = Random.Range(0, 3);
        }

        // ---Inputs--- \\

        // If we are not on the ground, DONT process inputs
        if (isGrounded != true)
            return;

        if (Input.GetButton("Move Left"))
        {
            // If we press the button to move left, move left
            rigidbody.AddForce(-moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetButton("Move Right"))
        {
            // If we press the button to move right, move right
            rigidbody.AddForce(moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Jump2"))
        {
            // We are not on the ground anymore
            isGrounded = false;

            // Play one of our three Jump SFX
            JumpSFX[rand].Play();

            // Do the Jump
            rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If we touch an object that is tagged with "Environment"or "Platform", then we ARE grounded
        if (collision.gameObject.tag == "Environment" || collision.gameObject.tag == "Platform")
            isGrounded = true;

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
            isGrounded = true;
        }
    }
}
