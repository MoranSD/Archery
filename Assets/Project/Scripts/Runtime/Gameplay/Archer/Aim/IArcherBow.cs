using UnityEngine;

namespace Gameplay.Archer.Aim
{
    public interface IArcherBow
    {
        public Vector3 ShootPosition { get; }
        public void Shoot(Vector3[] flyPath, float intensity);
        public bool CheckWall(Vector3 position);
    }
}