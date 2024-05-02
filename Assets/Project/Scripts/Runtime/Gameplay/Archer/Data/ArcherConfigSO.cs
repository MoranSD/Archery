using UnityEngine;

namespace Gameplay.Archer.Data
{
    [CreateAssetMenu(menuName = "Gameplay/Archer/Config")]
    public class ArcherConfigSO : ScriptableObject
    {
        [field: SerializeField] public ArcherConfig ArcherConfig { get; private set; }
        [field: SerializeField] public ArcherInputConfig InputConfig { get; private set; }
    }
}