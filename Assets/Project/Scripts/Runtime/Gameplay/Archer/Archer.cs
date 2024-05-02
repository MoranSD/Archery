using Gameplay.Archer.Aim;
using Gameplay.Archer.View;
using UnityEngine;

namespace Gameplay.Archer
{
    public class Archer : MonoBehaviour, IArcher
    {
        [SerializeField] private ArcherView archerView;
        [SerializeField] private ArcherBow archerBow;

        public IArcherView View => archerView;
        public IArcherBow Bow => archerBow;
    }
}