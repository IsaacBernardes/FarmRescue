using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    private EnergySource energySource;
    
    private void Awake() {
        m_transform = GetComponent<Transform>();
        energySource = GetComponent<EnergySource>();
    }

    private void Update() {
        Shoot();
    }

    void Shoot() {
        if (Physics2D.Raycast(m_transform.position, transform.right)) {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            DrawLaser(laserFirePoint.position, _hit.point);

            if (_hit.rigidbody == null) {
                energySource.state = true;
            } else {
                energySource.state = false;
            }
        } else {
            DrawLaser(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
            energySource.state = false;
        }
    }

    void DrawLaser(Vector2 startPosition, Vector2 endPosition) {
        m_lineRenderer.SetPosition(0, startPosition);
        m_lineRenderer.SetPosition(1, endPosition);
    }
}
