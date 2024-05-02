using Gameplay.Archer.Root;
using Spine.Unity;
using UnityEngine;

namespace Gameplay.Archer.Aim
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float delayBeforeDissapear;
        [SerializeField] private float flySpeed;

        private readonly int idleTriggedId = Animator.StringToHash("Idle");
        private readonly int arrowReachedTriggedId = Animator.StringToHash("Attack");

        private Vector3[] flyPath;
        private bool hasFlyPath;
        private float dissapearTime;
        private int pathIndex;

        private float currentFlySpeed;

        private void Update()
        {
            if (hasFlyPath)
            {
                transform.LookAt(flyPath[pathIndex]);
                transform.position = Vector3.MoveTowards(transform.position, flyPath[pathIndex], currentFlySpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, flyPath[pathIndex]) <= 0.1f)
                {
                    pathIndex++;

                    if (pathIndex >= flyPath.Length)
                    {
                        hasFlyPath = false;
                        animator.SetTrigger(arrowReachedTriggedId);
                    }
                }
            }
            else
            {
                dissapearTime += Time.deltaTime;
                if (dissapearTime < delayBeforeDissapear) return;

                ArrowPool.Instance.ReturnToPool(this);
            }
        }

        public void Fly(Vector3[] flyPath, float intensity)
        {
            animator.SetTrigger(idleTriggedId);

            this.flyPath = flyPath;
            hasFlyPath = true;
            pathIndex = 0;
            dissapearTime = 0;
            currentFlySpeed = flySpeed * intensity;
        }
    }
}