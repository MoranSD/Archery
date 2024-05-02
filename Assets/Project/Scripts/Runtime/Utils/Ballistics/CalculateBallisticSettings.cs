using UnityEngine;

namespace Utils.Ballistics
{
    [System.Serializable]
    public class CalculateBallisticSettings
    {
        [HideInInspector] public Vector3 startPosition;
        [HideInInspector] public Vector3 throwDirection;
        [HideInInspector] public float strenght;
        [Range(10, 100)] public int pointsCount;
        [Range(0.01f, 0.25f)] public float timeBetweenPoints;
        public float objectMass;
    }
}
