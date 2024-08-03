using System.Linq;
using UnityEngine;

public static class Utilitity
{
    public static Transform ClosestToPoint(Vector3 point, Transform[] transforms)
    {
        return transforms[ClosestsIndexToPoint(point, transforms)];
    }

    public static GameObject ClosestToPoint(Vector3 point, GameObject[] objects)
    {
        return objects[ClosestsIndexToPoint(point, objects.Select(x => x.transform).ToArray())];
    }

    public static Collider2D ClosestToPoint(Vector3 point, Collider2D[] objects)
    {
        return objects[ClosestsIndexToPoint(point, objects.Select(x => x.transform).ToArray())];
    }
    public static Collider ClosestToPoint(Vector3 point, Collider[] objects)
    {
        return objects[ClosestsIndexToPoint(point, objects.Select(x => x.transform).ToArray())];
    }
    private static int ClosestsIndexToPoint(Vector3 point, Transform[] points)
    {
        float minDist = float.PositiveInfinity;
        int index = 0;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] == null)
            {
                continue;
            }
            float dist = Vector3.Distance(points[i].position, point);
            if (dist < minDist)
            {
                minDist = dist;
                index = i;
            }
        }
        return index;
    }
}
