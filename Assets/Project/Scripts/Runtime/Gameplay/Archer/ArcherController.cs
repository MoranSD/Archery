using Gameplay.Archer.Data;
using Gameplay.Archer.AimInput;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer
{
    public class ArcherController : IInitializable, ITickable, ILateDisposable
    {
        private IArcher archer;
        private ArcherConfig config;
        private IArcherInput input;

        private float shootDelayTime;
        private float reloadDelayTime;

        private float currentAimAngle;
        private bool isAiming;
        private bool isReloading;

        public ArcherController(IArcher archer, ArcherConfig archerConfig, IArcherInput archerInput)
        {
            this.archer = archer;
            this.input = archerInput;
            this.config = archerConfig;
        }

        public void Initialize()
        {
            input.OnBeginAim += OnBeginAim;
            input.OnShoot += OnShoot;
        }

        public void LateDispose()
        {
            input.OnBeginAim -= OnBeginAim;
            input.OnShoot -= OnShoot;
        }

        public void Tick()
        {
            if (isReloading)
            {
                reloadDelayTime += Time.deltaTime;
                if (reloadDelayTime < config.ReloadDelay) return;

                isReloading = false;
            }

            if (isAiming == false) return;

            shootDelayTime += Time.deltaTime;
            if (shootDelayTime < config.ShootDelay) return;

            currentAimAngle = Mathf.MoveTowards(currentAimAngle, input.Angle, config.AimAngleSmooth);

            archer.View.SetAim(currentAimAngle);
        }

        private void OnBeginAim()
        {
            if (isReloading) return;

            archer.View.BeginTargeting();

            isAiming = true;
            currentAimAngle = config.StartAimAngle;
            shootDelayTime = 0;
        }

        private void OnShoot()
        {
            if (isAiming == false) return;

            isAiming = false;
            isReloading = true;
            reloadDelayTime = 0;

            archer.View.OnShoot();

            archer.Bow.Shoot(input.Direction, input.Intensity * config.ArrowForce);
        }
    }
}