using UnityEngine;

namespace Gameplay.Archer.Aim
{
    public interface IArcherBow
    {
        public void Shoot(Vector3 direction, float pushForce);
    }
}