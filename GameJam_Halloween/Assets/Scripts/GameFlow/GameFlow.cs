using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
