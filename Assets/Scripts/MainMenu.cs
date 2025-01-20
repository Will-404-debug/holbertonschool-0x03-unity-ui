using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MainMenu : MonoBehaviour
{
    // Method called when the Play button is pressed
    public void PlayMaze()
    {
        // Load the maze scene (you should have the maze scene added to Build Settings)
        SceneManager.LoadScene("maze"); // Ensure that "maze" is the name of your maze scene
    }
}
