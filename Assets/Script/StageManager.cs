using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject keyPos;
    [SerializeField] private GameObject key;

    void Awake()
    {
        Json.Instance.Read();

        for (int i = 0; i >= grid.transform.GetChildCount(); i++)
        {
            grid.transform.GetChild(i).gameObject.SetActive(false);
        }

        grid.transform.GetChild(Json.Instance.data.nowGameStage).gameObject.SetActive(true);
        key.transform.position = keyPos.transform.GetChild(Json.Instance.data.nowGameStage).transform.position;

        Json.Instance.Save();
    }
}
