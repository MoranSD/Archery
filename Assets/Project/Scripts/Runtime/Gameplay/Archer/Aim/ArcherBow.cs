using Gameplay.Archer.Root;
using Spine.Unity;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer.Aim
{
    public class ArcherBow : MonoBehaviour, IArcherBow  
    {
        [SerializeField] private Transform arrowPoint;
        [Inject] private ArrowPool arrowPool;

        public void Shoot(Vector3 direction, float pushForce)
        {
            var arrow = arrowPool.Create();
            arrow.transform.position = arrowPoint.position;
            arrow.transform.forward = direction;

            arrow.Push(direction, pushForce);
        }
    }
}