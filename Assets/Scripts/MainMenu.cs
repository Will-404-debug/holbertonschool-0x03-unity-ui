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

    // Method called when the Quit button is pressed
    public void QuitMaze()
    {
        #if UNITY_EDITOR
        Debug.Log("Quit Game");  // Log message in the Unity editor
        #else
        Application.Quit(); // Close the game in a build
        #endif
    }
}