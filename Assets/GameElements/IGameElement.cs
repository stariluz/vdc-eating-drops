
namespace Stariluz.GameLoop
{
    public interface IGameElement
    {
        public void StartGamePlay();
        public void StopGamePlay();
        public void Pause();
        public void Resume();
        // void RestartGamePlay();
    }

}