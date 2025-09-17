using System;
using UnityEngine;

public class LOOK_AT_THE_DAMN_MOUSE : MonoBehaviour
{
    Camera cam;
    Transform my;
    private Rigidbody2D body;
    public Transform offset;
    public float set = 34f;
    public GameObject BULLET;   // prefab
    public float spawnDistance = 0.03f; // ~3 pixels (depends on your units)

    private void Awake()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float camDis = cam.transform.position.y - my.position.y;
        Vector3 mouse = cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis)
        );

        // relative position from object to mouse
        Vector3 relativePos = mouse - my.position;

        // angle in degrees
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

        // rotate object (optional)
        body.rotation = angle + set;

        // when left mouse is clicked, spawn bullet
        if (Input.GetMouseButtonDown(0))
        {
            // get normalized direction
            Vector3 dir = relativePos.normalized;

            // spawn position = object position + offset
            Vector3 spawnPos = my.position + dir * spawnDistance;

            // spawn bullet with correct rotation
            Instantiate(BULLET, spawnPos, Quaternion.Euler(0, 0, angle));
        }
    }
}