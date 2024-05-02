using Spine.Unity;
using UnityEngine;

public class ArcherTest : MonoBehaviour
{
    public Animator animator;
    public SkeletonMecanim skeletonMecanim;
    public float bodyUp;
    private void LateUpdate()
    {
        var bodyBone = skeletonMecanim.skeleton.FindBone("body");
        bodyBone.Rotation = bodyUp;
    }
}
