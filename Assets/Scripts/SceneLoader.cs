using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Содержит методы для загрузки различных сцен игры.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Метод загрузки сцены новой игры.
    /// </summary>
    public void loadNewGame() {
        SceneManager.LoadScene("Level");
        Debug.Log("Scene - Level - load.");
    }

    /// <summary>
    /// Метод загрузки меню.
    /// </summary>
    public void loadMenu() {
        SceneManager.LoadScene("Menu");
        Debug.Log("Scene - Menu - load.");
    }

    /// <summary>
    /// Метод загрузки Game Over.
    /// </summary>
    public static void loadGameOver() {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Scene - Game Over - load.");
    }


    /// <summary>
    /// Метод выхода из игры.
    /// </summary>
    public void Exit() {
        Application.Quit();
    }
}
