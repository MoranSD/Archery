using UnityEngine;

namespace Meta.Ballistics.Data
{
    [CreateAssetMenu(menuName = "Meta/Ballistics/Config")]
    public class BallisticsDrawerConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 startPointSize { get; private set; }
        [field: SerializeField] public Vector3 finishPointSize { get; private set; }
    }
}
