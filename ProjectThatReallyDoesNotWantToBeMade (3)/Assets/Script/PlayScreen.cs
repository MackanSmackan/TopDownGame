using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScreen : MonoBehaviour
{
    [SerializeField] string StartScene;
    public void StartGame()
    {
            SceneManager.LoadScene(StartScene);
    }
}
