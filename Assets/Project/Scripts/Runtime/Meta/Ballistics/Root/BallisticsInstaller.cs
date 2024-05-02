using Meta.Ballistics.View;
using UnityEngine;
using Zenject;

namespace Meta.Ballistics.Root
{
    public class BallisticsInstaller : MonoInstaller
    {
        [SerializeField] private BallisticView ballisticView;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BallisticsDrawer>().AsSingle().WithArguments(ballisticView as IBallisticView);
        }
    }
}
