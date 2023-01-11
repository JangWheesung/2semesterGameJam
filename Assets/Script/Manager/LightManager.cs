using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D globalLight;
    public GameObject[] touch;
    public UnityEngine.Experimental.Rendering.Universal.Light2D[] touchLight;

    private void Awake()
    {
        touch = GameObject.FindGameObjectsWithTag("Touch");

        touchLight = new UnityEngine.Experimental.Rendering.Universal.Light2D[touch.Length];

        for (int i = 0; i <= touch.Length - 1; i++)
        {
            Debug.Log(1);
            touchLight[i] = touch[i].GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        }
    }

    void Start()
    {
        Json.Instance.Read();

        globalLight.intensity = 0.2f + (Json.Instance.data.globalLight / 5);

        for (int i = 1; i <= touchLight.Length - 1; i++)
        {
            touchLight[i].pointLightOuterRadius = 1.5f + (Json.Instance.data.touchLight / 2);
        }

        Json.Instance.Save();
    }
}
