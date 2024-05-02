using Spine.Unity;
using UnityEngine;

namespace Gameplay.Archer.View
{
    public class ArcherView : MonoBehaviour, IArcherView
    {

        [SerializeField] private Animator animator;
        [SerializeField] private SkeletonMecanim skeletonMecanim;

        private readonly int beginAimTriggerId = Animator.StringToHash("BeginAttack");
        private readonly int shootTriggerId = Animator.StringToHash("Attack");
        private const string aimBoneName = "gun";

        public void BeginTargeting() => animator.SetTrigger(beginAimTriggerId);

        public void OnShoot() => animator.SetTrigger(shootTriggerId);

        public void SetAim(float angle)
        {
            var gunIK = skeletonMecanim.skeleton.FindBone(aimBoneName);

            gunIK.Rotation = angle;
        }
    }
}