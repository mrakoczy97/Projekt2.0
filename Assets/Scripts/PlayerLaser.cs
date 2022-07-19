using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    public Camera cam;
    public LineRenderer LineRenderer;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {

        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    private void DisableLaser()
    {
        LineRenderer.enabled = false;
    }

    private void EnableLaser()
    {
        LineRenderer.enabled = true;
    }

    private void UpdateLaser()
    {
        //var mousePosition = (Vector2)cam.ScreenToWorldPoint(firePoint.transform.position);

        var mousePos = (Vector2)Input.mousePosition;
        LineRenderer.SetPosition(0, firePoint.position);
        LineRenderer.SetPosition(1, mousePos);
    }
}
