using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float zoom_speed = 1f;
    public float zoom_min = 2f;
    public float zoom_max = 4f;

    public float smooth_speed = 10f;
    public Vector3 offset;

    private Camera cam;
    private float target_zoom;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        target_zoom = cam.orthographicSize;
    }

    void Update()
    {
        if (target == null) return;

        // Smoothed target following
        Vector3 desired_position = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            -10
        );
        Vector3 smoothed_position = Vector3.Lerp(
            transform.position, desired_position, smooth_speed * Time.deltaTime
        );
        cam.transform.position = smoothed_position;
    }

    void LateUpdate()
    {
        // Camera zoom on scroll
        float scroll_delta = Mouse.current.scroll.ReadValue().y / 2;
        target_zoom += scroll_delta * -1;
        target_zoom = Mathf.Clamp(target_zoom, zoom_min, zoom_max);
        
        if (target_zoom != cam.orthographicSize)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, target_zoom, zoom_speed * Time.deltaTime);
    }
}
