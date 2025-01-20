using UnityEngine;
using UnityEngine.SceneManagement; // Required to reload the scene
using UnityEngine.UI; // Required to manipulate UI Text

public class PlayerController : MonoBehaviour 
{
    public float speed = 5.0f; // Speed variable, can be modified in the Inspector

    private Rigidbody rb;

    private int score = 0; // Private score variable initialized to 0

    public int health = 5; // Public health variable initialized to 5

    public Text scoreText; // Public Text variable to link with the ScoreText GameObject in the Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the Player
        score = 0; // Reset score to 0
        health = 5; // Reset health to 5
        SetScoreText(); // Call SetScoreText to initialize the score display
    }

    void FixedUpdate()
    {
        // Get input from WASD or Arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        // Move the Player
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        // Check if health is 0
        if (health == 0)
        {
            Debug.Log("Game Over!"); // Log "Game Over!" to the console
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        }
    }

    // This function is called when another collider enters the trigger collider attached to this object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) // Check if the other object has the tag "Pickup"
        {
            score++; // Increment the score
            SetScoreText(); // Update the score display
            other.gameObject.SetActive(false); // Disable the Coin GameObject
            // Alternatively, you could destroy the Coin: Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap")) // Check if the other object has the tag "Trap"
        {
            health--; // Decrement the health
            Debug.Log("Health: " + health); // Log the health to the console

            // Optionally, you can add logic to handle what happens when health reaches zero
            if (health <= 0)
            {
                Debug.Log("Game Over"); // Example of game over condition
                // Here, you can add further logic for game over, respawning, etc.
            }
        }
        else if (other.CompareTag("Goal")) // Check if the other object has the tag "Goal"
        {
            Debug.Log("You win!"); // Log the victory message to the console
        }
    }

    // Method to update the score text in the UI
    void SetScoreText()
    {
        scoreText.text = "Score: " + score; // Update the ScoreText UI element with the current score
    }
}
