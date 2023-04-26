namespace GameSystem
{
    public interface IGameUpdateElement : IGameElement
    {
        void OnUpdate(float deltaTime);
    }

    public interface IGameFixedUpdateElement : IGameElement
    {
        void OnFixedUpdate(float deltaTime);
    }

    public interface IGameLateUpdateElement : IGameElement
    {
        void OnLateUpdate(float deltaTime);
    }
}