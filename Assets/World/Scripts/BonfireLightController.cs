using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BonfireLightController : MonoBehaviour
{
    private Light2D bonfire_light;

    private float speed = 2.0f;
    private float noise = 0.0f;
    private float seed  = 0.0f;

    private float min_falloff = 0.5f;
    private float max_falloff = 0.8f;

    private float min_intensity = 3.0f;
    private float max_intensity = 5.0f;

    // TODO: Add random in range ^
    void Start()
    {
        bonfire_light = GetComponent<Light2D>();
        seed = Random.Range(0f, 100f);
    }

    void Update()
    {
        noise = Mathf.PerlinNoise((Time.time + seed) * speed, 0.0f);
        bonfire_light.falloffIntensity = Mathf.Lerp(min_falloff, max_falloff, noise);
        bonfire_light.intensity = Mathf.Lerp(min_intensity, max_intensity, noise);
    }
}
