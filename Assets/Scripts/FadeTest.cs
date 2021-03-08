using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour
{

    [SerializeField] private Light DirectionalLight;
    [SerializeField] Material skyboxMat;
    [SerializeField] Gradient topGradient;
    [SerializeField] Gradient horizonGradient;
    [SerializeField] Gradient bottomGradient;
    [SerializeField] float duration;
    float t = 0f;
    void Update()
    {
        float value = Mathf.Lerp(0f, 1f, t);
        t += Time.deltaTime / duration;
        DirectionalLight.intensity = Mathf.Lerp(1f, 0f, t);
        Color topColor = topGradient.Evaluate(value);
        Color horizonColor = horizonGradient.Evaluate(value);
        Color botColor = bottomGradient.Evaluate(value);
        skyboxMat.SetColor("Color_4CD6C77D", topColor);
        skyboxMat.SetColor("Color_22E0C94", horizonColor);
        skyboxMat.SetColor("Color_FA3767F3", botColor);

        if (DirectionalLight != null)
        {
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((value * 360f) - 90f, 170f, 0));
        }
    }
}
