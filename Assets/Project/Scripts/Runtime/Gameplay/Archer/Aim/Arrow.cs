using Spine.Unity;
using UnityEngine;

namespace Gameplay.Archer.Aim
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private SkeletonMecanim skeletonMecanim;
        [SerializeField] private Rigidbody2D rigidBody;
        public void Push(Vector3 direction, float force)
        {
            rigidBody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        }
    }
}