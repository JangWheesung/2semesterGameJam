using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingButton()
    {
        SceneManager.LoadScene(5);
    }
}
