using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int points;
    public static GameManager S;
    void Awake()
    {
        S = this;
    }
    void Start() {
        points = 0;
        lives = 4;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
