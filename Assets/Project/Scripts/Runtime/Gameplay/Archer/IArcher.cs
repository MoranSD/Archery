using Gameplay.Archer.Aim;
using Gameplay.Archer.View;

namespace Gameplay.Archer
{
    public interface IArcher
    {
        IArcherView View { get; }
        IArcherBow Bow { get; }
    }
}