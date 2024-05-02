using System;
using UnityEngine;

namespace Gameplay.Archer.AimInput
{
    public interface IArcherInput
    {
        public float Angle { get; }
        public Vector3 Direction { get; }
        public float Intensity { get; }

        public event Action OnBeginAim;
        public event Action OnShoot;
    }
}