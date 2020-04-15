/// <summary>
/// Наименования событий для оповещения объектов об их запуске.
/// </summary>
public class GameEvent
{
    public const string HEALTH_UPDATED = "HEALTH_UPDATED";
    public const string SCORE_UPDATED = "SCORE_UPDATED";

    public const string RETURN_TO_CHECKPOINT = "RETURN_TO_CHECKPOINT";

    public const string LEVEL_FAILED = "LEVEL_FAILED";
    public const string LEVEL_COMPLETE = "LEVEL_COMPLETE";
    public const string GAME_COMPLETE = "GAME_COMPLETE";
}
