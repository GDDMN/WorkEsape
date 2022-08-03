namespace PurpleDrank
{
    public interface IGameState
    {
        void Entry();
        void OnUpdate();
        void Exit();
    }
}

