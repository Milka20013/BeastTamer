using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        StartCoroutine(DoUpdateCollider());
    }

    IEnumerator DoUpdateCollider()
    {
        for (; ; )
        {
            UpdateCollider();
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void Update()
    {
        UpdateOffset();
    }



    public void UpdateCollider()
    {
        List<Vector2> edges = new();
        for (int i = 0; i < trailRenderer.positionCount; i++)
        {
            Vector3 point = trailRenderer.GetPosition(i);
            edges.Add(new(point.x, point.y));
        }
        edgeCollider.SetPoints(edges);
    }

    public void UpdateOffset()
    {
        edgeCollider.offset = new(-transform.position.x, -transform.position.y);
    }
}
