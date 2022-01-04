using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}