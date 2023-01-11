using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    [SerializeField] private GameObject[] icons;
    [SerializeField] private Sprite redButton;
    [SerializeField] private Sprite blueButton;

    void Start()
    {
        foreach (GameObject item in icons) { item.GetComponent<Image>().sprite = redButton; }

        for (int i = 0; i < Json.Instance.data.maxGameStage; i++) { icons[i].GetComponent<Image>().sprite = blueButton; }
    }
}
