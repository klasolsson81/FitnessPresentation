namespace FitnessPresentationApp;

/// <summary>
/// Innehåller alla konstanter och konfigurationsvärden för presentationen.
/// Gör det enkelt att ändra timing och beteenden på ett ställe.
/// </summary>
public static class Constants
{
    // Animation timings (i millisekunder)
    public static class Timing
    {
        public const int FastAnimation = 25;
        public const int MediumAnimation = 50;
        public const int SlowAnimation = 60;
        public const int PauseBetweenElements = 200;
        public const int PauseBetweenSlides = 500;
        public const int BombAnimationDelay = 350;
        public const int CountdownDelay = 500;
        public const int MuscleFlexDelay = 60;
    }

    // Layout constants
    public static class Layout
    {
        public const int FileTreeBoxWidth = 47;
        public const int FinalPanelWidth = 36;
        public const int DefaultVerticalPadding = 6;
    }
}