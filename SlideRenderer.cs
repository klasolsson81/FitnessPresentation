using Microsoft.VisualBasic;
using Spectre.Console;

namespace FitnessPresentationApp;

/// <summary>
/// Ansvarar för att rendera olika typer av slide-element och animationer.
/// Centraliserar renderingslogik för att undvika duplicering.
/// </summary>
public class SlideRenderer
{
    private readonly ConsoleHelper _consoleHelper;

    public SlideRenderer(ConsoleHelper consoleHelper)
    {
        _consoleHelper = consoleHelper;
    }

    /// <summary>
    /// Ritar en slide-header med nummer och titel.
    /// </summary>
    public void DrawSlideHeader(string number, string title, Color color)
    {
        try
        {
            var rule = new Rule($"[bold {color.ToMarkup()}]SLIDE {number} — {title}[/]")
            {
                Style = new Style(color),
                Justification = Justify.Center
            };
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte rita header: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar ASCII-art med gradient-färger.
    /// </summary>
    public void RenderAsciiArtWithGradient(string[] artLines, Color[] gradientColors, int delayMs)
    {
        try
        {
            foreach (var line in artLines)
            {
                var colorIndex = Array.IndexOf(artLines, line) % gradientColors.Length;
                _consoleHelper.PrintCentered(line, gradientColors[colorIndex]);
                Thread.Sleep(delayMs);
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte rendera ASCII-art: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar ASCII-art med en enda färg.
    /// </summary>
    public void RenderAsciiArt(string[] artLines, Color color, int delayMs)
    {
        try
        {
            foreach (var line in artLines)
            {
                _consoleHelper.PrintCentered(line, color);
                Thread.Sleep(delayMs);
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte rendera ASCII-art: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar animerade frames (t.ex. bomb eller muscles).
    /// </summary>
    public void RenderFrameAnimation(string[] frames, Color color, int delayMs)
    {
        try
        {
            int cursorTop = Console.CursorTop;
            foreach (var frame in frames)
            {
                Console.SetCursorPosition(0, cursorTop);
                foreach (var line in frame.Split('\n'))
                {
                    _consoleHelper.PrintCentered(line, color);
                }
                Thread.Sleep(delayMs);
            }
        }
        catch (Exception ex)
        {
            // Om positionering misslyckas, visa sista frame
            AnsiConsole.MarkupLine($"[{color.ToMarkup()}]{frames[^1]}[/]");
        }
    }

    /// <summary>
    /// Renderar en tabell med lärdommar.
    /// </summary>
    public void RenderLearningsTable((string icon, string title, string desc)[] learnings)
    {
        try
        {
            var learnTable = new Table().Border(TableBorder.None).Centered();
            learnTable.AddColumn(new TableColumn("").Width(5).Centered());
            learnTable.AddColumn(new TableColumn("").Width(18));
            learnTable.AddColumn(new TableColumn(""));

            foreach (var (icon, title, desc) in learnings)
            {
                learnTable.AddRow($"[yellow]{icon}[/]", $"[bold cyan]{title}[/]", $"[grey]{desc}[/]");
            }

            AnsiConsole.Write(learnTable);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte visa tabell: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar en panel med kod-exempel.
    /// </summary>
    public void RenderCodePanel(string codeContent, string headerText)
    {
        try
        {
            var panel = new Panel(new Markup(codeContent))
                .Header($" {headerText} ", Justify.Left)
                .Border(BoxBorder.Rounded)
                .BorderStyle(new Style(Color.Grey))
                .Padding(2, 1, 2, 1);

            int verticalPadding = _consoleHelper.CalculateVerticalPadding(Constants.Layout.DefaultVerticalPadding);
            _consoleHelper.WriteVerticalPadding(verticalPadding);

            AnsiConsole.Write(new Align(panel, HorizontalAlignment.Center));
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte visa kod-panel: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar en nedräkning.
    /// </summary>
    public void RenderCountdown(string[] countdownNumbers, int delayMs)
    {
        try
        {
            foreach (var num in countdownNumbers)
            {
                AnsiConsole.Clear();
                var bigNum = new FigletText(num)
                    .Centered()
                    .Color(Color.Yellow);
                AnsiConsole.Write(bigNum);
                Thread.Sleep(delayMs);
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte visa nedräkning: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar en avslutande panel.
    /// </summary>
    public void RenderFinalPanel(string content, int width)
    {
        try
        {
            int padding = _consoleHelper.CalculateHorizontalPadding(width);

            var finalPanel = new Panel(new Markup(content))
            {
                Border = BoxBorder.Double,
                BorderStyle = new Style(Color.Yellow),
                Padding = new Padding(3, 1),
                Width = width
            };

            AnsiConsole.Write(new Padder(finalPanel, new Padding(padding, 0, 0, 0)));
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Kunde inte visa slutpanel: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Renderar en horisontell linje (separator).
    /// </summary>
    public void RenderSeparator(string separator, Color color)
    {
        _consoleHelper.PrintCentered(separator, color);
    }
}