using Gameplay.Archer.Root;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer.Aim
{
    public class ArcherBow : MonoBehaviour, IArcherBow
    {
        [SerializeField] private Transform arrowPoint;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private float checkWallRadius;

        [Inject] private ArrowPool arrowPool;

        public Vector3 ShootPosition => arrowPoint.position;

        public void Shoot(Vector3[] flyPath, float intensity)
        {
            var arrow = arrowPool.Create();
            arrow.transform.position = arrowPoint.position;
            arrow.transform.forward = flyPath[1] - flyPath[0];

            arrow.Fly(flyPath, intensity);
        }
        public bool CheckWall(Vector3 position)
        {
            return Physics2D.OverlapCircle(position, checkWallRadius, wallLayer);
        }
    }
}