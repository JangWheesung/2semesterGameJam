using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject keyPos;
    [SerializeField] private GameObject objects;
    [SerializeField] private GameObject key;

    void Start()
    {
        Json.Instance.Read();

        grid.transform.GetChild(Json.Instance.data.nowGameStage - 1).gameObject.SetActive(true);
        objects.transform.GetChild(Json.Instance.data.nowGameStage - 1).gameObject.SetActive(true);

        key.transform.position = keyPos.transform.GetChild(Json.Instance.data.nowGameStage - 1).transform.position;

        Json.Instance.Save();
    }
}
