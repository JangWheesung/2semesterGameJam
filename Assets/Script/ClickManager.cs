using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    public void Stage(int stageNumber)
    {
        Json.Instance.Read();
        Json.Instance.data.nowGameStage = stageNumber;
        Json.Instance.Save();

        SceneManager.LoadScene("EscapeRoom");
    }
}
