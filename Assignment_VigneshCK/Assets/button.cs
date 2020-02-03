using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("Game");
    }
    public void HighS()
    {
        SceneManager.LoadScene("score");
    }
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
