using Gameplay.Archer;
using Meta.Ballistics.View;
using Zenject;

namespace Meta.Ballistics
{
    public class BallisticsDrawer : IInitializable, ILateDisposable, ITickable
    {
        private IBallisticView ballisticView;
        private ArcherController archerController;

        public BallisticsDrawer(ArcherController archerController, IBallisticView ballisticView)
        {
            this.ballisticView = ballisticView;
            this.archerController = archerController;
        }

        public void Initialize()
        {
            archerController.Input.OnShoot += ballisticView.Hide;
        }

        public void LateDispose()
        {
            archerController.Input.OnShoot -= ballisticView.Hide;
        }

        public void Tick()
        {
            if (archerController.IsAiming == false) return;

            var flyPath = archerController.AimPath;

            if(flyPath == null) return;

            ballisticView.SetPointsCount(flyPath.Length);

            for (int i = 0; i < flyPath.Length; i++)
            {
                ballisticView.SetPosition(i, flyPath[i]);
                ballisticView.SetSize(i, (float)i / flyPath.Length);
            }
        }
    }
}