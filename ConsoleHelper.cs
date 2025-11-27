using Spectre.Console;

namespace FitnessPresentationApp;

/// <summary>
/// Hanterar all console-relaterad funktionalitet som centering, animation och input.
/// Följer Single Responsibility Principle - ansvarar endast för console-interaktion.
/// </summary>
public class ConsoleHelper
{
    /// <summary>
    /// Skriver ut text centrerad horisontellt i konsolen.
    /// </summary>
    public void PrintCentered(string text, Color color)
    {
        try
        {
            int width = Console.WindowWidth;
            int padding = Math.Max(0, (width - text.Length) / 2);

            Console.Write(new string(' ', padding));
            AnsiConsole.MarkupLine($"[{color.ToMarkup()}]{EscapeMarkup(text)}[/]");
        }
        catch (Exception ex)
        {
            // Om något går fel med konsolen, fortsätt ändå
            AnsiConsole.MarkupLine($"[red]Kunde inte skriva text: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Animerar text tecken för tecken, centrerad i konsolen.
    /// </summary>
    public void AnimateTextCentered(string text, Color color, int delayPerChar)
    {
        try
        {
            int width = Console.WindowWidth;
            int padding = Math.Max(0, (width - text.Length) / 2);

            Console.Write(new string(' ', padding));

            foreach (char c in text)
            {
                AnsiConsole.Markup($"[{color.ToMarkup()}]{EscapeMarkupChar(c)}[/]");
                if (delayPerChar > 0)
                {
                    Thread.Sleep(delayPerChar);
                }
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            // Fallback om animationen misslyckas
            PrintCentered(text, color);
        }
    }

    /// <summary>
    /// Väntar på att användaren trycker ENTER.
    /// </summary>
    public void WaitForNext()
    {
        try
        {
            AnsiConsole.WriteLine();
            int width = Console.WindowWidth;
            string text = "Tryck ENTER för nästa slide →";
            int padding = Math.Max(0, (width - text.Length) / 2);

            Console.Write(new string(' ', padding));
            AnsiConsole.MarkupLine("[grey]Tryck [yellow]ENTER[/] för nästa slide →[/]");
            Console.ReadLine();
        }
        catch (Exception)
        {
            // Om ReadLine misslyckas, vänta kort tid istället
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    /// Beräknar vertikal padding för att centrera innehåll.
    /// </summary>
    public int CalculateVerticalPadding(int contentHeight)
    {
        try
        {
            int windowHeight = Console.WindowHeight;
            int padding = (windowHeight / 2) - contentHeight;
            return Math.Max(0, padding);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// Skriver ut tomma rader för vertikal padding.
    /// </summary>
    public void WriteVerticalPadding(int lines)
    {
        for (int i = 0; i < lines; i++)
        {
            AnsiConsole.WriteLine();
        }
    }

    /// <summary>
    /// Escaper specialtecken för Spectre.Console markup.
    /// </summary>
    private string EscapeMarkup(string text)
    {
        return text.Replace("[", "[[").Replace("]", "]]");
    }

    /// <summary>
    /// Escaper ett enskilt tecken för Spectre.Console markup.
    /// </summary>
    private string EscapeMarkupChar(char c)
    {
        return c switch
        {
            '[' => "[[",
            ']' => "]]",
            _ => c.ToString()
        };
    }

    /// <summary>
    /// Beräknar horisontell padding för given bredd.
    /// </summary>
    public int CalculateHorizontalPadding(int contentWidth)
    {
        try
        {
            int windowWidth = Console.WindowWidth;
            return Math.Max(0, (windowWidth - contentWidth - 2) / 2);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// Döljer eller visar console cursor.
    /// </summary>
    public void SetCursorVisibility(bool visible)
    {
        try
        {
            Console.CursorVisible = visible;
        }
        catch (Exception)
        {
            // Vissa konsol-miljöer stödjer inte detta
        }
    }
}