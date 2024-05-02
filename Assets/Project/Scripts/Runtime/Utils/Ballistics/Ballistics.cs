using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Ballistics
{
    public static class Ballistics
    {
        public static Vector3[] CalculatePath(CalculateBallisticSettings settings, Func<Vector3, bool> checkEnd)
        {
            int pointsCount = Mathf.CeilToInt(settings.pointsCount / settings.timeBetweenPoints) + 1;
            var startVelocity = settings.strenght * settings.throwDirection.normalized / settings.objectMass;

            var path = new List<Vector3>(pointsCount);
            path.Add(settings.startPosition);

            int i = 0;
            for (float time = 0; time < settings.pointsCount; time += settings.timeBetweenPoints)
            {
                i++;

                Vector3 point = settings.startPosition + time * startVelocity;
                point.y = settings.startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

                if(checkEnd(point)) return path.ToArray();

                path.Add(point);
            }

            return path.ToArray();
        }
    }
}
