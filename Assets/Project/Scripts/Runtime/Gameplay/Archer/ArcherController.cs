using Gameplay.Archer.Data;
using Gameplay.Archer.AimInput;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer
{
    public class ArcherController : IInitializable, ITickable, ILateDisposable
    {
        public bool IsAiming { get; private set; }
        public Vector3[] AimPath { get; private set; }
        public IArcherInput Input { get; private set; }

        private IArcher archer;
        private ArcherConfig config;

        private float shootDelayTime;
        private float reloadDelayTime;

        private float currentAimAngle;
        private bool isReloading;
        private bool isPreparingForShoot;

        public ArcherController(IArcher archer, ArcherConfig archerConfig, IArcherInput archerInput)
        {
            this.archer = archer;
            this.Input = archerInput;
            this.config = archerConfig;
        }

        public void Initialize()
        {
            Input.OnBeginAim += OnBeginAim;
            Input.OnShoot += OnShoot;
        }

        public void LateDispose()
        {
            Input.OnBeginAim -= OnBeginAim;
            Input.OnShoot -= OnShoot;
        }

        public void Tick()
        {
            if (isReloading)
            {
                reloadDelayTime += Time.deltaTime;
                if (reloadDelayTime < config.ReloadDelay) return;

                isReloading = false;
            }


            if (isPreparingForShoot)
            {
                shootDelayTime += Time.deltaTime;
                if (shootDelayTime < config.ShootDelay) return;
                else
                {
                    isPreparingForShoot = false;
                    IsAiming = true;
                }
            }

            if (IsAiming == false) return;

            config.BallisticsConfig.startPosition = archer.Bow.ShootPosition;//tupo no ladno
            config.BallisticsConfig.throwDirection = Input.Direction;
            config.BallisticsConfig.strenght = config.ArrowForce * Input.Intensity;

            AimPath = Utils.Ballistics.Ballistics.CalculatePath(config.BallisticsConfig, archer.Bow.CheckWall);//ya bi mog ispolzovat' Jobs, no mne len'

            currentAimAngle = Mathf.MoveTowards(currentAimAngle, Input.Angle, config.AimAngleSmooth);

            archer.View.SetAim(currentAimAngle);
        }

        private void OnBeginAim()
        {
            if (isReloading) return;

            archer.View.BeginTargeting();

            isPreparingForShoot = true;
            currentAimAngle = config.StartAimAngle;
            shootDelayTime = 0;
        }

        private void OnShoot()
        {
            isPreparingForShoot = false;

            if (IsAiming == false) return;

            IsAiming = false;
            isReloading = true;
            reloadDelayTime = 0;

            archer.View.OnShoot();

            var flyPath = Utils.Ballistics.Ballistics.CalculatePath(config.BallisticsConfig, archer.Bow.CheckWall);//hren' nu i ladno archer.Bow.CheckWall
            archer.Bow.Shoot(flyPath, Input.Intensity);
        }
    }
}