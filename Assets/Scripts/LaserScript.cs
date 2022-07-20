using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;
    
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    // Start is called before the first frame update
    void Start()
    {
        FillLists();
        DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           // Debug.Log("strzelam!");
            EnableLaser();
        }
        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }
        if (Input.GetButtonUp("Fire1"))
        {
           // Debug.Log("Nie strzelam!");
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
        for (int i = 0; i < particles.Count; i++)
            particles[i].Play();
    }
    void DisableLaser()
    {
        lineRenderer.enabled = false;
        for (int i = 0; i < particles.Count; i++)
            particles[i].Stop();
    }
    void UpdateLaser()
    {

        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, mousePos);
        Debug.Log(mousePos);
        startVFX.transform.position = (Vector2)firePoint.position;

        //colider
        int layer_mask = LayerMask.GetMask("Default", "Enemy");
        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position,direction.normalized,direction.magnitude,layer_mask);
        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    }
    void FillLists()
    {
        for(int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }

}
