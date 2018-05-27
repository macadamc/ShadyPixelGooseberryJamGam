using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Camera cam;

    float currentIntensity;
    float currentTime;
    float endTime;

    Vector3 targetPos;

    private void Start()
    {
        cam = Camera.main;
        targetPos = transform.position;
    }

    public void Shake(float intensity, float length)
    {
        currentTime = 0.0f;
        currentIntensity = intensity;
        endTime = length;
    }

    public void Shake_Short(float intensity)
    {
        currentTime = 0.0f;
        currentIntensity = intensity;
        endTime = 0.01f;
    }

    public void Shake_Medium(float intensity)
    {
        currentTime = 0.0f;
        currentIntensity = intensity;
        endTime = 0.5f;
    }

    private void Update()
    {
        currentIntensity = Mathf.Lerp(currentIntensity, 0.0f, currentTime / endTime);
        Vector2 randomPos = Random.insideUnitCircle;

        currentTime += Time.deltaTime * endTime;

        if(currentIntensity > 0)
            transform.position = targetPos + (Vector3)(randomPos * currentIntensity);
    }


}
