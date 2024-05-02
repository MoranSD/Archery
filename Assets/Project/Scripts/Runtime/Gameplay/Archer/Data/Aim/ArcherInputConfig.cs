using UnityEngine;

namespace Gameplay.Archer.Data
{
    [System.Serializable]
    public class ArcherInputConfig
    {
        [field: SerializeField] public float MaxRadius { get; private set; }
    }
}