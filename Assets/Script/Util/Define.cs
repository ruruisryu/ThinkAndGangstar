public class Define
{
    public enum GameState
    {
        Playing,
        GameOver,
        None
    }

    public enum StoreItem
    {
        
    }
        
    public enum TileCylcle
    {
        AnswerFixed = 0,
        SymbolFixed = 1,
        None
    }

    public enum UIEvent
    {
        Click,
        Swipe
    }

    public enum Scene
    {
        Unknown,
        Intro,
        Main,
        Game,
        Shop,
        Achivement
    }
}