using UnityEngine;
using Utils.Ballistics;

namespace Gameplay.Archer.Data
{
    [System.Serializable]
    public class ArcherConfig
    {
        [field: SerializeField] public float ShootDelay { get; private set; }
        [field: SerializeField] public float ReloadDelay { get; private set; }
        [field: SerializeField] public float StartAimAngle { get; private set; }
        [field: SerializeField] public float AimAngleSmooth { get; private set; }
        [field: SerializeField] public float ArrowForce { get; private set; }

        [field: SerializeField] public CalculateBallisticSettings BallisticsConfig { get; private set; }
    }
}