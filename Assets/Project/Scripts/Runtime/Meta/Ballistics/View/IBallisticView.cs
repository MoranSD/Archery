using UnityEngine;

namespace Meta.Ballistics.View
{
    public interface IBallisticView
    {
        public void Hide();
        public void SetPointsCount(int count);
        public void SetPosition(int pointIndex, Vector3 position);
        public void SetSize(int pointIndex, float size);
    }
}
