using Gameplay.Archer.Aim;
using Gameplay.Archer.AimInput;
using Gameplay.Archer.Data;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer.Root
{
    public class ArcherInstaller : MonoInstaller
    {
        [SerializeField] private ArcherConfigSO configSO;
        [SerializeField] private GameObject archerGO;
        [SerializeField] private Transform arrowsParent;
        [SerializeField] private Arrow arrowPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ArcherInputSystem>().AsSingle().WithArguments(configSO.InputConfig);
            Container.BindInterfacesAndSelfTo<ArrowPool>().AsSingle().WithArguments(arrowsParent, arrowPrefab, 10);

            var archer = archerGO.GetComponent<IArcher>();
            Container.BindInterfacesAndSelfTo<ArcherController>().AsSingle().WithArguments(archer, configSO.ArcherConfig);
        }
    }
}
