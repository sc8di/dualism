/// <summary>
/// Интерфейс для инициализации менеджеров.
/// </summary>
public interface IGameManager
{
    ManagerStatus Status { get; }
    void Startup();
}
