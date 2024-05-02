using Gameplay.Archer.AimInput;
using Gameplay.Ballistics.View;
using System;
using Zenject;

namespace Gameplay.Ballistics
{
    public class BallisticsDrawer : IInitializable, ITickable, ILateDisposable
    {
        private IBallisticView ballisticView;
        private IArcherInput archerInput;

        private bool isAiming;

        public BallisticsDrawer(IBallisticView ballisticView, IArcherInput archerInput)
        {
            this.ballisticView = ballisticView;
            this.archerInput = archerInput;
        }

        public void Initialize()
        {
            archerInput.OnBeginAim += OnBeginAim;
            archerInput.OnShoot += OnShoot;
        }

        public void LateDispose()
        {
            archerInput.OnBeginAim -= OnBeginAim;
            archerInput.OnShoot -= OnShoot;
        }

        public void Tick()
        {
            if (isAiming == false) return;

            ballisticView.SetAim(archerInput.Angle, archerInput.Intensity);
        }

        private void OnBeginAim()
        {
            isAiming = true;
            ballisticView.Show();
        }
        private void OnShoot()
        {
            isAiming = false;
            ballisticView.Hide();
        }
    }
}