using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FinderObjects
{

    public static IInteractable FindInteractableObjectByCircle(float radius, Vector2 circlePosition)
    {
        var result = FindByCircle<IInteractable>(radius, circlePosition, 0);
        if (result != null) return result[0];
        return null;
    }

    public static IItem FindItemByCircle(float radius, Vector2 circlePosition)
    {
        var result = FindByCircle<IItem>(radius, circlePosition, 0);
        if (result != null) return result[0];
        return null;
    }

    private static List<T> FindByCircle<T>(float radius, Vector2 circlePosition, int layer)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circlePosition, radius, 1 << layer);
        List<T> result = new List<T>();
        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<T>(out var neededObj)) result.Add(neededObj);
            }
            if (result.Count > 0) return result;
        }
        return null;
    }
}