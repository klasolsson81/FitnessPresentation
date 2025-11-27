using System.Text;

namespace FitnessPresentationApp;

/// <summary>
/// Orkestrerare för hela presentationen.
/// Delegerar ansvaret till specialiserade klasser enligt Single Responsibility Principle.
/// </summary>
public class Presentation
{
    private readonly SlideManager _slideManager;
    private readonly ConsoleHelper _consoleHelper;

    public Presentation()
    {
        // Skapa dependencies (i en större app skulle detta vara Dependency Injection)
        _consoleHelper = new ConsoleHelper();
        var renderer = new SlideRenderer(_consoleHelper);
        _slideManager = new SlideManager(_consoleHelper, renderer);
    }

    /// <summary>
    /// Kör hela presentationen från start till slut.
    /// </summary>
    public void Run()
    {
        try
        {
            InitializeConsole();
            RunAllSlides();
        }
        catch (Exception ex)
        {
            HandleFatalError(ex);
        }
        finally
        {
            CleanupConsole();
        }
    }

    /// <summary>
    /// Initialiserar console-inställningar.
    /// </summary>
    private void InitializeConsole()
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            _consoleHelper.SetCursorVisibility(false);
        }
        catch (Exception ex)
        {
            // Om encoding eller cursor misslyckas, fortsätt ändå
            Console.WriteLine($"Varning: Kunde inte initialisera console helt: {ex.Message}");
        }
    }

    /// <summary>
    /// Kör alla slides i ordning.
    /// </summary>
    private void RunAllSlides()
    {
        _slideManager.ShowLandingPage();
        _slideManager.ShowSlide1_CodeStructure();
        _slideManager.ShowSlide2_Planning();
        _slideManager.ShowSlide3_PTUseCases();
        _slideManager.ShowSlide4_ClientUseCases();
        _slideManager.ShowSlide5_LogSystem();
        _slideManager.ShowSlide6_Communication();
        _slideManager.ShowSlide7_Chaos();
        _slideManager.ShowSlide8_WhatWeLearned();
        _slideManager.ShowSlide9_DemoTime();
    }

    /// <summary>
    /// Återställer console-inställningar.
    /// </summary>
    private void CleanupConsole()
    {
        _consoleHelper.SetCursorVisibility(true);
    }

    /// <summary>
    /// Hanterar kritiska fel som stoppar presentationen.
    /// </summary>
    private void HandleFatalError(Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine("   FEL: Presentationen avbröts");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine($"\nFelmeddelande: {ex.Message}");
        Console.WriteLine("\nTryck ENTER för att avsluta...");
        Console.ReadLine();
    }
}