using Meta.Ballistics.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Ballistics.View
{
    public class BallisticView : MonoBehaviour, IBallisticView
    {
        [SerializeField] private BallisticsDrawerConfig config;
        [SerializeField] private GameObject pointPrefab;
        [SerializeField] private int startPointsCount;
        [SerializeField] private int hideFirst;

        private List<GameObject> points = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < startPointsCount; i++)
                CreatePoint(false);
        }

        public void Hide()
        {
            foreach (var point in points)
                point.gameObject.SetActive(false);
        }

        public void SetPosition(int pointIndex, Vector3 position)
        {
            while(points.Count < pointIndex)
                CreatePoint(true);

            points[pointIndex].transform.position = position;
        }

        public void SetSize(int pointIndex, float size)
        {
            while (points.Count < pointIndex)
                CreatePoint(true);

            points[pointIndex].transform.localScale = Vector3.Lerp(config.startPointSize, config.finishPointSize, size);
        }

        private void CreatePoint(bool active)
        {
            var point = Instantiate(pointPrefab, transform);
            point.SetActive(active && points.Count > hideFirst);
            points.Add(point);
        }

        public void SetPointsCount(int count)
        {
            while (points.Count < count)
                CreatePoint(true);

            for (int i = 0; i < points.Count; i++)
            {
                points[i].SetActive(i < count && i > hideFirst);
            }
        }
    }
}