using Spectre.Console;

namespace FitnessPresentationApp;

/// <summary>
/// Hanterar visningen av individuella slides.
/// Varje slide har sin egen metod för tydlighet.
/// </summary>
public class SlideManager
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly SlideRenderer _renderer;

    public SlideManager(ConsoleHelper consoleHelper, SlideRenderer renderer)
    {
        _consoleHelper = consoleHelper;
        _renderer = renderer;
    }

    /// <summary>
    /// Visar landing page med kod-meme och logo.
    /// </summary>
    public void ShowLandingPage()
    {
        try
        {
            ShowCodeMeme();
            ShowMainLogo();
            ShowTeamIntroduction();
            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av landing page: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar kod-meme panel.
    /// </summary>
    private void ShowCodeMeme()
    {
        AnsiConsole.Clear();
        _renderer.RenderCodePanel(SlideData.CodeMeme, "GymLogic.cs");

        AnsiConsole.Write(new Align(
            new Markup("[grey]Tryck på valfri tangent för att fortsätta...[/]"),
            HorizontalAlignment.Center));

        Console.ReadKey(true);
        AnsiConsole.MarkupLine("\n[green]Programmet fortsätter![/]");
    }

    /// <summary>
    /// Visar huvudlogo med animationer.
    /// </summary>
    private void ShowMainLogo()
    {
        AnsiConsole.Clear();
        Thread.Sleep(Constants.Timing.PauseBetweenSlides);

        Color[] gradientColors = { Color.Red, Color.Orange1, Color.Yellow, Color.Green, Color.Blue, Color.Purple };
        _renderer.RenderAsciiArtWithGradient(SlideData.Logo, gradientColors, Constants.Timing.SlowAnimation);

        Thread.Sleep(Constants.Timing.PauseBetweenSlides);

        _renderer.RenderAsciiArt(SlideData.Dumbbell, Color.Cyan1, Constants.Timing.MediumAnimation);
    }

    /// <summary>
    /// Visar team-introduktion.
    /// </summary>
    private void ShowTeamIntroduction()
    {
        Thread.Sleep(400);

        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.AnimateTextCentered("🕶️  TEAM 7 — THE DEBUGGERS  🕶️", Color.Yellow, 35);
        _consoleHelper.PrintCentered("", Color.White);
        _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);

        Thread.Sleep(400);

        string teamLine = string.Join("  •  ", SlideData.TeamMembers);
        _consoleHelper.AnimateTextCentered(teamLine, Color.Cyan1, Constants.Timing.FastAnimation);

        _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);

        Thread.Sleep(Constants.Timing.PauseBetweenSlides);

        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.PrintCentered("OOP Grund — .NET Systemutveckling", Color.Grey);
        _consoleHelper.PrintCentered("November 2025", Color.Grey);
    }

    /// <summary>
    /// Visar slide 1 om kodstruktur.
    /// </summary>
    public void ShowSlide1_CodeStructure()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("1", "KODSTRUKTUR", Color.Blue);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            RenderFileTree();
            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av kodstruktur: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Renderar fil-trädet för kodstrukturen.
    /// </summary>
    private void RenderFileTree()
    {
        int leftPadding = _consoleHelper.CalculateHorizontalPadding(Constants.Layout.FileTreeBoxWidth);
        string padding = new string(' ', leftPadding);

        foreach (var (text, colorMarkup) in SlideData.FileTreeStructure)
        {
            Console.Write(padding);
            AnsiConsole.MarkupLine($"[{colorMarkup}]{text}[/]");
            Thread.Sleep(Constants.Timing.MediumAnimation);
        }
    }

    /// <summary>
    /// Visar slide 8 om vad teamet har lärt sig.
    /// </summary>
    public void ShowSlide8_WhatWeLearned()
    {
        try
        {
            ShowBombAnimation();
            ShowExplosion();
            ShowLearnings();
            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av lärdommar: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar bomb-animationen.
    /// </summary>
    private void ShowBombAnimation()
    {
        AnsiConsole.Clear();
        _renderer.DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);
        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.AnimateTextCentered("⏳ Laddar kunskaper...", Color.Yellow, 0);
        _consoleHelper.PrintCentered("", Color.White);

        _renderer.RenderFrameAnimation(SlideData.BombFrames, Color.Orange1, Constants.Timing.BombAnimationDelay);
    }

    /// <summary>
    /// Visar explosions-animationen som växer från liten till stor.
    /// </summary>
    private void ShowExplosion()
    {
        try
        {
            Thread.Sleep(100);

            Color[] explosionColors = { Color.Yellow, Color.Orange1, Color.Red };

            foreach (var frame in SlideData.ExplosionFrames)
            {
                AnsiConsole.Clear();
                _renderer.DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);
                _consoleHelper.PrintCentered("", Color.White);
                _consoleHelper.PrintCentered("", Color.White);

                // Växla färg för varje frame
                Color frameColor = explosionColors[Array.IndexOf(SlideData.ExplosionFrames, frame) % explosionColors.Length];

                foreach (var line in frame)
                {
                    _consoleHelper.PrintCentered(line, frameColor);
                }

                // Kortare delay för första frames, längre för senare = dramatisk effekt
                int delay = Array.IndexOf(SlideData.ExplosionFrames, frame) < 3 ? 150 : 250;
                Thread.Sleep(delay);
            }

            // Håll sista framen en stund
            Thread.Sleep(600);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid explosion: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Visar lärdommar från projektet.
    /// </summary>
    private void ShowLearnings()
    {
        AnsiConsole.Clear();
        _renderer.DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);

        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.AnimateTextCentered("🧠 KUNSKAPSEXPLOSION! 🧠", Color.Yellow, 0);
        _consoleHelper.PrintCentered("", Color.White);

        _renderer.RenderLearningsTable(SlideData.Learnings);

        _consoleHelper.PrintCentered("", Color.White);
        _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.AnimateTextCentered("\"No pain, no gain!\" 💪", Color.Yellow, Constants.Timing.FastAnimation);
    }

    /// <summary>
    /// Visar slide 9 - Demo Time!
    /// </summary>
    public void ShowSlide9_DemoTime()
    {
        try
        {
            ShowDemoCountdown();
            ShowDemoAnimation();
            ShowFinalMessage();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av demo: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar nedräkning innan demon.
    /// </summary>
    private void ShowDemoCountdown()
    {
        string[] countdown = { "3", "2", "1" };
        _renderer.RenderCountdown(countdown, Constants.Timing.CountdownDelay);
    }

    /// <summary>
    /// Visar demo-animationen.
    /// </summary>
    private void ShowDemoAnimation()
    {
        AnsiConsole.Clear();

        Color[] rainbow = { Color.Red, Color.Orange1, Color.Yellow, Color.Green, Color.Cyan1, Color.Blue, Color.Purple };
        int colorIndex = 0;

        foreach (var line in SlideData.DemoArt)
        {
            _consoleHelper.PrintCentered(line, rainbow[colorIndex % rainbow.Length]);
            if (!string.IsNullOrWhiteSpace(line)) colorIndex++;
            Thread.Sleep(30);
        }

        Thread.Sleep(300);

        _consoleHelper.PrintCentered("", Color.White);
        _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        _consoleHelper.PrintCentered("", Color.White);

        RenderMuscleFlexAnimation();
    }

    /// <summary>
    /// Renderar muscle flex-animationen.
    /// </summary>
    private void RenderMuscleFlexAnimation()
    {
        try
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var frame in SlideData.MuscleFrames)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    _consoleHelper.PrintCentered(frame, Color.Yellow);
                    Thread.Sleep(Constants.Timing.MuscleFlexDelay);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
            }
            _consoleHelper.PrintCentered("💪💪💪💪💪", Color.Yellow);
        }
        catch (Exception)
        {
            // Om cursor-positionering misslyckas, hoppa över animationen
            _consoleHelper.PrintCentered("💪💪💪💪💪", Color.Yellow);
        }
    }

    /// <summary>
    /// Visar slutmeddelandet.
    /// </summary>
    private void ShowFinalMessage()
    {
        _consoleHelper.PrintCentered("", Color.White);
        Thread.Sleep(Constants.Timing.PauseBetweenElements);

        _consoleHelper.AnimateTextCentered("🎬 ÄR NI REDO FÖR DEMON? 🎬", Color.Cyan1, 30);
        _consoleHelper.PrintCentered("", Color.White);

        string finalContent = "[bold yellow]Team 7 — The Debuggers[/]\n[grey]Tack för att ni lyssnade![/]";
        _renderer.RenderFinalPanel(finalContent, Constants.Layout.FinalPanelWidth);

        _consoleHelper.PrintCentered("", Color.White);
        _consoleHelper.PrintCentered("[[Tryck ENTER för att avsluta presentationen]]", Color.Grey);
        Console.ReadLine();
    }

    /// <summary>
    /// Visar slide 2 om planeringsfasen.
    /// </summary>
    public void ShowSlide2_Planning()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("2", "PLANERINGSFASEN", Color.Green);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.AnimateTextCentered("🤔  VAD SKA VI BYGGA?", Color.Yellow, 30);
            _consoleHelper.PrintCentered("", Color.White);
            Thread.Sleep(400);

            ShowVisionPanel();
            ShowCRUDFeatures();

            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av planering: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar vision-panelen för projektet.
    /// </summary>
    private void ShowVisionPanel()
    {
        try
        {
            int visionWidth = 44;
            int visionPad = _consoleHelper.CalculateHorizontalPadding(visionWidth);

            var visionPanel = new Panel(
                new Markup("[bold cyan]En rollbaserad konsollapplikation\ndär PT:s och Klienter kan logga in[/]"))
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Cyan1),
                Header = new PanelHeader("[bold yellow] 🎯 VISION [/]"),
                Padding = new Padding(2, 1),
                Width = visionWidth
            };

            AnsiConsole.Write(new Padder(visionPanel, new Padding(visionPad, 0, 0, 0)));
            Thread.Sleep(600);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av vision: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Visar CRUD-funktioner med ASCII-art.
    /// </summary>
    private void ShowCRUDFeatures()
    {
        try
        {
            _consoleHelper.PrintCentered("", Color.White);
            _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
            _consoleHelper.PrintCentered("", Color.White);

            foreach (var line in SlideData.CrudArt)
            {
                int width = Console.WindowWidth;
                int visibleLength = 65;
                int pad = Math.Max(0, (width - visibleLength) / 2);
                Console.Write(new string(' ', pad));
                AnsiConsole.MarkupLine(line);
                Thread.Sleep(100);
            }

            Thread.Sleep(400);
            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.AnimateTextCentered("Träningsscheman • Kostscheman • Framstegsloggar", Color.Grey, 20);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av CRUD: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Visar slide 3 om PT use cases.
    /// </summary>
    public void ShowSlide3_PTUseCases()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("3", "PT — USE CASES", Color.Blue);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            _consoleHelper.PrintCentered("", Color.White);

            // Visa PT-logotyp
            _renderer.RenderAsciiArt(SlideData.PTIcon, Color.Blue, 0);

            _consoleHelper.PrintCentered("", Color.White);
            _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
            _consoleHelper.PrintCentered("", Color.White);

            // Visa use cases med olika färger
            Color[] colors = { Color.Cyan1, Color.Red, Color.Yellow, Color.Green, Color.Orange1, Color.Purple };
            for (int i = 0; i < SlideData.PTUseCases.Length; i++)
            {
                Thread.Sleep(300);
                _consoleHelper.AnimateTextCentered(SlideData.PTUseCases[i], colors[i], 15);
            }

            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av PT use cases: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar slide 4 om klient use cases.
    /// </summary>
    public void ShowSlide4_ClientUseCases()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("4", "KLIENT — USE CASES", Color.Green);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            _consoleHelper.PrintCentered("", Color.White);

            // Visa Klient-logotyp
            _renderer.RenderAsciiArt(SlideData.ClientIcon, Color.Green, 0);

            _consoleHelper.PrintCentered("", Color.White);
            _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
            _consoleHelper.PrintCentered("", Color.White);

            // Visa use cases med olika färger
            Color[] colors = { Color.Cyan1, Color.Yellow, Color.Green, Color.Purple, Color.Orange1 };
            for (int i = 0; i < SlideData.ClientUseCases.Length; i++)
            {
                Thread.Sleep(300);
                _consoleHelper.AnimateTextCentered(SlideData.ClientUseCases[i], colors[i], 15);
            }

            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av klient use cases: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar slide 5 om datahantering och repository pattern.
    /// </summary>
    public void ShowSlide5_LogSystem()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("5", "DATAHANTERING", Color.Purple);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.AnimateTextCentered("🔧 GENERISK REPOSITORY PATTERN", Color.Yellow, 25);
            _consoleHelper.PrintCentered("", Color.White);
            Thread.Sleep(400);

            ShowRepositoryPattern();
            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av datahantering: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar repository pattern med kod-exempel.
    /// </summary>
    private void ShowRepositoryPattern()
    {
        try
        {
            // IDataStore interface
            var codePanel = new Panel(
                new Markup(@"[cyan]public interface[/] [yellow]IDataStore[/][grey]<[/][green]T[/][grey]>[/]
[grey]{[/]
    [cyan]List[/][grey]<[/][green]T[/][grey]>[/] [white]Load[/][grey]();[/]
    [cyan]void[/] [white]Save[/][grey]([/][cyan]List[/][grey]<[/][green]T[/][grey]>[/] [white]data[/][grey]);[/]
[grey]}[/]"))
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Cyan1),
                Header = new PanelHeader("[bold yellow] IDataStore<T> [/]"),
                Padding = new Padding(2, 1),
                Width = 50
            };
            AnsiConsole.Write(Align.Center(codePanel));
            Thread.Sleep(600);

            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.PrintCentered("⬇️", Color.Grey);
            _consoleHelper.PrintCentered("", Color.White);

            // JsonDataStore implementation
            var jsonPanel = new Panel(
                new Markup(@"[cyan]public class[/] [yellow]JsonDataStore[/][grey]<[/][green]T[/][grey]>[/] : [yellow]IDataStore[/][grey]<[/][green]T[/][grey]>[/]
[grey]{[/]
    [grey]// Läser/Skriver till JSON-filer[/]
    [grey]// En instans per datatyp[/]
[grey]}[/]"))
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Green),
                Header = new PanelHeader("[bold green] JsonDataStore<T> [/]"),
                Padding = new Padding(2, 1),
                Width = 55
            };
            AnsiConsole.Write(Align.Center(jsonPanel));
            Thread.Sleep(500);

            _consoleHelper.PrintCentered("", Color.White);

            // Visa JSON-filer grid
            var storeGrid = new Grid();
            storeGrid.AddColumn();
            storeGrid.AddColumn();
            storeGrid.AddColumn();

            storeGrid.AddRow(
                new Panel("[grey]→ clients.json[/]")
                {
                    Border = BoxBorder.Rounded,
                    Header = new PanelHeader("[cyan] Client [/]"),
                    Width = 20
                },
                new Panel("[grey]→ workouts.json[/]")
                {
                    Border = BoxBorder.Rounded,
                    Header = new PanelHeader("[blue] WorkoutPlan [/]"),
                    Width = 20
                },
                new Panel("[grey]→ diets.json[/]")
                {
                    Border = BoxBorder.Rounded,
                    Header = new PanelHeader("[green] DietPlan [/]"),
                    Width = 20
                }
            );

            AnsiConsole.Write(Align.Center(storeGrid));
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av repository pattern: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Visar slide 6 om kommunikation och samarbete.
    /// </summary>
    public void ShowSlide6_Communication()
    {
        try
        {
            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("6", "KOMMUNIKATION & SAMARBETE", Color.Cyan1);
            Thread.Sleep(Constants.Timing.PauseBetweenElements);

            _consoleHelper.PrintCentered("", Color.White);

            int panelWidth = 45;
            int panelPad = _consoleHelper.CalculateHorizontalPadding(panelWidth);

            foreach (var (icon, name, desc, color) in SlideData.CommunicationTools)
            {
                Thread.Sleep(300);

                var panel = new Panel(new Markup($"[grey]{desc}[/]"))
                {
                    Border = BoxBorder.Rounded,
                    BorderStyle = new Style(color),
                    Header = new PanelHeader($"[bold {color.ToMarkup()}] {icon} {name} [/]"),
                    Padding = new Padding(2, 0),
                    Width = panelWidth
                };

                AnsiConsole.Write(new Padder(panel, new Padding(panelPad, 0, 0, 0)));
            }

            Thread.Sleep(300);
            _renderer.RenderSeparator("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.AnimateTextCentered("🔄 Agilt arbetssätt med feature branches", Color.Green, 20);

            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av kommunikation: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar slide 7 om kaos och problem under projektet.
    /// </summary>
    public void ShowSlide7_Chaos()
    {
        try
        {
            ShowChaosAnimation();
            ShowProblemsEncountered();
            _consoleHelper.WaitForNext();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av kaos: {ex.Message}[/]");
            Thread.Sleep(2000);
        }
    }

    /// <summary>
    /// Visar kaos-animationen med blinkande text.
    /// </summary>
    private void ShowChaosAnimation()
    {
        try
        {
            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                AnsiConsole.Clear();
                _renderer.DrawSlideHeader("7", "KAOS & PROBLEM", Color.Red);
                _consoleHelper.PrintCentered(SlideData.ChaosText[rand.Next(SlideData.ChaosText.Length)], Color.Red);
                Thread.Sleep(250);
            }

            AnsiConsole.Clear();
            _renderer.DrawSlideHeader("7", "KAOS & PROBLEM", Color.Red);

            _consoleHelper.PrintCentered("", Color.White);
            _consoleHelper.AnimateTextCentered("🔥 !#¤%&/()=?!\"#¤%&/()=? 🔥", Color.Red, 20);
            _consoleHelper.PrintCentered("", Color.White);
            Thread.Sleep(400);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid kaos-animation: {ex.Message}[/]");
        }
    }

    /// <summary>
    /// Visar alla problem som uppstod under projektet.
    /// </summary>
    private void ShowProblemsEncountered()
    {
        try
        {
            int panelWidth = 75;
            int panelPad = _consoleHelper.CalculateHorizontalPadding(panelWidth);

            foreach (var (icon, title, desc, color) in SlideData.Problems)
            {
                Thread.Sleep(350);

                var panel = new Panel(new Markup($"[grey]{desc}[/]"))
                {
                    Border = BoxBorder.Heavy,
                    BorderStyle = new Style(color),
                    Header = new PanelHeader($"[bold {color.ToMarkup()}] {icon} {title} [/]"),
                    Padding = new Padding(2, 0),
                    Width = panelWidth
                };

                AnsiConsole.Write(new Padder(panel, new Padding(panelPad, 0, 0, 0)));
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Fel vid visning av problem: {ex.Message}[/]");
        }
    }
}