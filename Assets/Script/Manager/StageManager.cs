using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject keyPos;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject playerPos;
    [SerializeField] private GameObject player;

    void Start()
    {
        SoundManager.Instance.StopGameBgm();

        Json.Instance.Read();

        grid.transform.GetChild(Json.Instance.data.nowGameStage - 1).gameObject.SetActive(true);

        key.transform.position = keyPos.transform.GetChild(Json.Instance.data.nowGameStage - 1).transform.position;
        player.transform.position = playerPos.transform.GetChild(Json.Instance.data.nowGameStage - 1).transform.position;

        Json.Instance.Save();
    }
}
