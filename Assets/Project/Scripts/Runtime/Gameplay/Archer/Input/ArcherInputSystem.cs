using Gameplay.Archer.Data;
using Spine;
using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer.AimInput
{
    public class ArcherInputSystem : ITickable, IArcherInput
    {
        public float Angle { get; private set; }
        public Vector3 Direction { get; private set; }
        public float Intensity { get; private set; }

        public event Action OnBeginAim;
        public event Action OnShoot;

        private Vector2 aimDeltaStart;
        private ArcherInputConfig config;

        public ArcherInputSystem(ArcherInputConfig config)
        {
            this.config = config;
        }

        public void Tick()
        {
            if(Input.GetMouseButtonDown(0))
            {
                aimDeltaStart = Input.mousePosition;
                CalculateAim();

                OnBeginAim?.Invoke();
            }
            if (Input.GetMouseButton(0)) CalculateAim();
            if (Input.GetMouseButtonUp(0)) OnShoot?.Invoke();
        }
        private void CalculateAim()
        {
            Vector2 aimDeltaEnd = Input.mousePosition;

            if (aimDeltaEnd.x > aimDeltaStart.x)
            {
                float margin = aimDeltaEnd.x - aimDeltaStart.x;
                aimDeltaEnd.x = aimDeltaStart.x - margin;
            }

            var aimDelta = aimDeltaEnd - aimDeltaStart;

            Direction = -aimDelta.normalized;
            Angle = Vector2.Angle(Vector2.right, Direction);
            Intensity = Mathf.Clamp(aimDelta.magnitude, 0, config.MaxRadius) / config.MaxRadius;
        }
    }
}