namespace Gameplay.Archer.View
{
    public interface IArcherView
    {
        public void BeginTargeting();
        public void SetAim(float angle);
        public void OnShoot();
    }
}