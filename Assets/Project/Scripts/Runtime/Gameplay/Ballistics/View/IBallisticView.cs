namespace Gameplay.Ballistics.View
{
    public interface IBallisticView
    {
        public void Show();
        public void Hide();
        public void SetAim(float angle, float intensity);
    }
}
