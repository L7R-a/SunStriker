using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("MergeDaDi");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
}
