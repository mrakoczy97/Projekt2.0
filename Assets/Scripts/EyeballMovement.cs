using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private GameObject playerGo;
    private CircleCollider2D eyeballCircleCollider;
    private CircleCollider2D playerCollider;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        playerGo = this.transform.parent.gameObject;
        eyeballCircleCollider = GetComponent<CircleCollider2D>();
        playerCollider = playerGo.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        mousePosition = camera.WorldToScreenPoint(playerGo.transform.position);
        

        transform.position = Vector2.Lerp(
            transform.position, playerGo.transform.position + (Input.mousePosition - mousePosition).normalized *playerCollider.transform.localScale.x
            * (playerCollider.radius - eyeballCircleCollider.radius), moveSpeed);
    }
}
