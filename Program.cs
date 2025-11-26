using Spectre.Console;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var presentation = new Presentation();
presentation.Run();

public class Presentation
{
    private readonly string[] _teamMembers = { "Klas Olsson", "Mohammed Yusur", "Sacad Elmi", "Sajad Azizi", "Yonis Bashir" };

    public void Run()
    {
        Console.CursorVisible = false;

        ShowLandingPage();
        ShowSlide1_CodeStructure();
        ShowSlide2_Planning();
        ShowSlide3_PTUseCases();
        ShowSlide4_ClientUseCases();
        ShowSlide5_LogSystem();
        ShowSlide6_Communication();
        ShowSlide7_Chaos();
        ShowSlide8_WhatWeLearned();
        ShowSlide9_DemoTime();

        Console.CursorVisible = true;
    }

    private void ShowLandingPage()
    {
        AnsiConsole.Clear();

        var panel = new Panel(
            Align.Center(
                new Markup("[grey]Tryck [yellow]ENTER[/] för att starta presentationen...\n[dim](Maximera terminalen först för bästa upplevelse!)[/][/]")
            ))
        {
            Border = BoxBorder.None
        };

        AnsiConsole.Write(Align.Center(panel));
        Console.ReadLine();

        AnsiConsole.Clear();
        Thread.Sleep(500);  // Longer pause

        string[] logo = {
            @"",
            @"███████╗██╗████████╗███╗   ██╗███████╗███████╗███████╗",
            @"██╔════╝██║╚══██╔══╝████╗  ██║██╔════╝██╔════╝██╔════╝",
            @"█████╗  ██║   ██║   ██╔██╗ ██║█████╗  ███████╗███████╗",
            @"██╔══╝  ██║   ██║   ██║╚██╗██║██╔══╝  ╚════██║╚════██║",
            @"██║     ██║   ██║   ██║ ╚████║███████╗███████║███████║",
            @"╚═╝     ╚═╝   ╚═╝   ╚═╝  ╚═══╝╚══════╝╚══════╝╚══════╝",
            @"",
            @"██████╗ ██████╗  ██████╗  ██████╗ ██████╗ ███████╗███████╗███████╗",
            @"██╔══██╗██╔══██╗██╔═══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝██╔════╝",
            @"██████╔╝██████╔╝██║   ██║██║  ███╗██████╔╝█████╗  ███████╗███████╗",
            @"██╔═══╝ ██╔══██╗██║   ██║██║   ██║██╔══██╗██╔══╝  ╚════██║╚════██║",
            @"██║     ██║  ██║╚██████╔╝╚██████╔╝██║  ██║███████╗███████║███████║",
            @"╚═╝     ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝",
            @"",
            @"████████╗██████╗  █████╗  ██████╗██╗  ██╗███████╗██████╗ ",
            @"╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██║ ██╔╝██╔════╝██╔══██╗",
            @"   ██║   ██████╔╝███████║██║     █████╔╝ █████╗  ██████╔╝",
            @"   ██║   ██╔══██╗██╔══██║██║     ██╔═██╗ ██╔══╝  ██╔══██╗",
            @"   ██║   ██║  ██║██║  ██║╚██████╗██║  ██╗███████╗██║  ██║",
            @"   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝"
        };

        Color[] gradientColors = { Color.Red, Color.Orange1, Color.Yellow, Color.Green, Color.Blue, Color.Purple };

        // SLOWER - 60ms per line
        foreach (var line in logo)
        {
            var colorIndex = Array.IndexOf(logo, line) % gradientColors.Length;
            PrintCentered(line, gradientColors[colorIndex]);
            Thread.Sleep(60);
        }

        Thread.Sleep(500);  // Longer pause

        string[] dumbbell = {
            @"",
            @"    ╔═══╗                           ╔═══╗",
            @"    ║   ║ ═══════════════════════ ║   ║",
            @"    ║   ║ ═══════════════════════ ║   ║",
            @"    ╚═══╝                           ╚═══╝",
            @""
        };

        foreach (var line in dumbbell)
        {
            PrintCentered(line, Color.Cyan1);
            Thread.Sleep(50);  // Slower
        }

        Thread.Sleep(400);

        PrintCentered("", Color.White);
        AnimateTextCentered("🕶️  TEAM 7 — THE DEBUGGERS  🕶️", Color.Yellow, 35);  // Slower
        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);

        Thread.Sleep(400);

        string teamLine = string.Join("  •  ", _teamMembers);
        AnimateTextCentered(teamLine, Color.Cyan1, 25);  // Slower

        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);

        Thread.Sleep(500);

        PrintCentered("", Color.White);
        PrintCentered("OOP Grund — .NET Systemutveckling", Color.Grey);
        PrintCentered("November 2025", Color.Grey);

        WaitForNext();
    }

    private void ShowSlide1_CodeStructure()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("1", "KODSTRUKTUR", Color.Blue);

        Thread.Sleep(200);

        var treeContent = @"[yellow]📁 FitnessProgressTracker[/]
│
├─[green]📁 Models[/]
│  ├─ User.cs [dim](abstrakt basklass)[/]
│  ├─ Client.cs
│  ├─ PT.cs
│  ├─ WorkoutPlan.cs
│  ├─ DietPlan.cs
│  ├─ DailyWorkout.cs
│  ├─ DailyMealPlan.cs
│  ├─ Exercise.cs
│  ├─ ProgressLog.cs
│  └─ Appointment.cs
│
├─[blue]📁 Services[/]
│  ├─ LoginService.cs
│  ├─ ClientService.cs
│  ├─ ScheduleService.cs
│  ├─ ProgressService.cs
│  ├─ AiService.cs
│  └─[magenta]📁 Interfaces[/]
│     └─ IDataStore.cs
│
├─[yellow]📁 UI[/]
│  ├─ Menu.cs
│  ├─ ClientMenu.cs
│  ├─ PtMenu.cs
│  └─ SpectreUIHelper.cs
│
├─[red]📁 Data (JSON)[/]
│  ├─ clients.json
│  ├─ pts.json
│  ├─ workouts.json
│  ├─ diets.json
│  └─ logs.json
│
├─ Program.cs
└─ FitnessProgressTracker.csproj";

        var treePanel = new Panel(new Markup(treeContent))
        {
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.Cyan1),
            Padding = new Padding(2, 1),
            Width = 50
        };

        AnsiConsole.Write(Align.Center(treePanel));

        Thread.Sleep(500);

        AnsiConsole.WriteLine();

        var statsTable = new Table().Border(TableBorder.Rounded).BorderColor(Color.Cyan1);
        statsTable.AddColumn(new TableColumn("[bold]Kategori[/]").Centered());
        statsTable.AddColumn(new TableColumn("[bold]Antal[/]").Centered());
        statsTable.AddRow("[green]Models[/]", "10 klasser");
        statsTable.AddRow("[blue]Services[/]", "5 klasser");
        statsTable.AddRow("[yellow]UI[/]", "4 klasser");
        statsTable.AddRow("[red]Data[/]", "5 JSON-filer");

        AnsiConsole.Write(Align.Center(statsTable));

        WaitForNext();
    }

    private void ShowSlide2_Planning()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("2", "PLANERINGSFASEN", Color.Green);

        Thread.Sleep(200);

        PrintCentered("", Color.White);
        AnimateTextCentered("🤔  VAD SKA VI BYGGA?", Color.Yellow, 30);
        PrintCentered("", Color.White);

        Thread.Sleep(400);

        // Vision panel - using Align.Center directly
        var visionPanel = new Panel(
            Align.Center(new Markup("[bold cyan]En rollbaserad konsollapplikation\ndär PT:s och Klienter kan logga in[/]")))
        {
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.Cyan1),
            Header = new PanelHeader("[bold yellow] 🎯 VISION [/]"),
            Padding = new Padding(2, 1),
            Width = 50
        };

        AnsiConsole.Write(Align.Center(visionPanel));

        Thread.Sleep(600);

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);

        // CRUD - Simple centered text boxes
        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        grid.AddRow(
            new Panel("[bold green]📝 CREATE[/]") { Border = BoxBorder.Double, BorderStyle = new Style(Color.Green) },
            new Panel("[bold blue]👁️ READ[/]") { Border = BoxBorder.Double, BorderStyle = new Style(Color.Blue) },
            new Panel("[bold yellow]✏️ UPDATE[/]") { Border = BoxBorder.Double, BorderStyle = new Style(Color.Yellow) },
            new Panel("[bold red]🗑️ DELETE[/]") { Border = BoxBorder.Double, BorderStyle = new Style(Color.Red) },
            new Panel("[bold purple]🤖 AI[/]") { Border = BoxBorder.Double, BorderStyle = new Style(Color.Purple) }
        );

        AnsiConsole.Write(Align.Center(grid));

        Thread.Sleep(400);

        PrintCentered("", Color.White);
        AnimateTextCentered("Träningsscheman • Kostscheman • Framstegsloggar", Color.Grey, 20);

        WaitForNext();
    }

    private void ShowSlide3_PTUseCases()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("3", "PT — USE CASES", Color.Blue);

        Thread.Sleep(200);

        string[] useCases = {
            "👥 En PT ska kunna hantera sina klienter",
            "🗑️ En PT ska kunna ta bort klienter",
            "🎯 En PT ska kunna sätta mål för klienter",
            "🏋️ En PT ska kunna skapa träningsschema för klienter",
            "🥗 En PT ska kunna skapa kostschema för klienter",
            "📊 En PT ska kunna se loggar och framsteg för klienter"
        };

        Color[] colors = { Color.Cyan1, Color.Red, Color.Yellow, Color.Green, Color.Orange1, Color.Purple };

        PrintCentered("", Color.White);

        string[] ptIcon = {
            @"██████╗ ████████╗",
            @"██╔══██╗╚══██╔══╝",
            @"██████╔╝   ██║   ",
            @"██╔═══╝    ██║   ",
            @"██║        ██║   ",
            @"╚═╝        ╚═╝   "
        };

        foreach (var line in ptIcon)
        {
            PrintCentered(line, Color.Blue);
        }

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);

        for (int i = 0; i < useCases.Length; i++)
        {
            Thread.Sleep(300);
            AnimateTextCentered(useCases[i], colors[i], 15);
        }

        WaitForNext();
    }

    private void ShowSlide4_ClientUseCases()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("4", "KLIENT — USE CASES", Color.Green);

        Thread.Sleep(200);

        string[] useCases = {
            "📋 En klient ska kunna se sina scheman",
            "⚖️ En klient ska kunna uppdatera sin vikt",
            "✅ En klient ska kunna markera pass som genomförda",
            "📈 En klient ska kunna se statistik och framgång",
            "🎯 En klient ska kunna se sina mål"
        };

        Color[] colors = { Color.Cyan1, Color.Yellow, Color.Green, Color.Purple, Color.Orange1 };

        PrintCentered("", Color.White);

        string[] clientIcon = {
            @"██╗  ██╗██╗     ██╗███████╗███╗   ██╗████████╗",
            @"██║ ██╔╝██║     ██║██╔════╝████╗  ██║╚══██╔══╝",
            @"█████╔╝ ██║     ██║█████╗  ██╔██╗ ██║   ██║   ",
            @"██╔═██╗ ██║     ██║██╔══╝  ██║╚██╗██║   ██║   ",
            @"██║  ██╗███████╗██║███████╗██║ ╚████║   ██║   ",
            @"╚═╝  ╚═╝╚══════╝╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   "
        };

        foreach (var line in clientIcon)
        {
            PrintCentered(line, Color.Green);
        }

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);

        for (int i = 0; i < useCases.Length; i++)
        {
            Thread.Sleep(300);
            AnimateTextCentered(useCases[i], colors[i], 15);
        }

        WaitForNext();
    }

    private void ShowSlide5_LogSystem()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("5", "DATAHANTERING", Color.Purple);

        Thread.Sleep(200);

        PrintCentered("", Color.White);
        AnimateTextCentered("🔧 GENERISK REPOSITORY PATTERN", Color.Yellow, 25);
        PrintCentered("", Color.White);

        Thread.Sleep(400);

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

        PrintCentered("", Color.White);
        PrintCentered("⬇️", Color.Grey);
        PrintCentered("", Color.White);

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

        PrintCentered("", Color.White);

        var storeGrid = new Grid();
        storeGrid.AddColumn();
        storeGrid.AddColumn();
        storeGrid.AddColumn();

        storeGrid.AddRow(
            new Panel("[grey]→ clients.json[/]") { Border = BoxBorder.Rounded, Header = new PanelHeader("[cyan] Client [/]"), Width = 20 },
            new Panel("[grey]→ workouts.json[/]") { Border = BoxBorder.Rounded, Header = new PanelHeader("[blue] WorkoutPlan [/]"), Width = 20 },
            new Panel("[grey]→ diets.json[/]") { Border = BoxBorder.Rounded, Header = new PanelHeader("[green] DietPlan [/]"), Width = 20 }
        );

        AnsiConsole.Write(Align.Center(storeGrid));

        WaitForNext();
    }

    private void ShowSlide6_Communication()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("6", "KOMMUNIKATION & SAMARBETE", Color.Cyan1);

        Thread.Sleep(200);

        PrintCentered("", Color.White);

        var tools = new (string icon, string name, string desc, Color color)[] {
            ("💬", "DISCORD", "Egen kanal för snabb kommunikation", Color.Purple),
            ("📹", "TEAMS", "Daily check-ins och stand-ups", Color.Blue),
            ("🐙", "GITHUB", "Pull Requests & Code Reviews", Color.Green)
        };

        foreach (var (icon, name, desc, color) in tools)
        {
            Thread.Sleep(300);

            var panel = new Panel(Align.Center(new Markup($"[grey]{desc}[/]")))
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(color),
                Header = new PanelHeader($"[bold {color.ToMarkup()}] {icon} {name} [/]"),
                Padding = new Padding(2, 0),
                Width = 48
            };

            AnsiConsole.Write(Align.Center(panel));
            AnsiConsole.WriteLine();
        }

        Thread.Sleep(300);

        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);
        AnimateTextCentered("🔄 Agilt arbetssätt med feature branches", Color.Green, 20);

        WaitForNext();
    }

    private void ShowSlide7_Chaos()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("7", "KAOS & PROBLEM", Color.Red);

        Thread.Sleep(200);

        string[] chaosText = { "!@#$%", "ERROR", "PANIC", "HELP!", "???!!" };
        Random rand = new Random();

        for (int i = 0; i < 4; i++)
        {
            AnsiConsole.Clear();
            DrawSlideHeader("7", "KAOS & PROBLEM", Color.Red);
            PrintCentered(chaosText[rand.Next(chaosText.Length)], Color.Red);
            Thread.Sleep(80);
        }

        AnsiConsole.Clear();
        DrawSlideHeader("7", "KAOS & PROBLEM", Color.Red);

        PrintCentered("", Color.White);
        AnimateTextCentered("🔥 !#¤%&/()=?!\"#¤%&/()=? 🔥", Color.Red, 20);
        PrintCentered("", Color.White);

        Thread.Sleep(400);

        var problems = new (string icon, string title, string desc, Color color)[] {
            ("🔑", "API-NYCKEL LÄCKA", "Råkade pusha .env till GitHub — Nyckeln stoppades automatiskt!", Color.Orange1),
            ("💥", "MERGE KONFLIKTER", "Flera versioner av samma fil — Ocommittade ändringar blockerade pulls", Color.Red),
            ("🤯", ".ENV PROBLEM", "Svårt att få .env att fungera utan konflikter mellan datorer", Color.Yellow),
            ("😅", "GIT FÖRVIRRING", "\"Var är mina ändringar?!\" — \"Vem tog bort min kod?!\"", Color.Purple)
        };

        foreach (var (icon, title, desc, color) in problems)
        {
            Thread.Sleep(350);

            var panel = new Panel(Align.Center(new Markup($"[grey]{desc}[/]")))
            {
                Border = BoxBorder.Heavy,
                BorderStyle = new Style(color),
                Header = new PanelHeader($"[bold {color.ToMarkup()}] {icon} {title} [/]"),
                Padding = new Padding(2, 0),
                Width = 70
            };

            AnsiConsole.Write(Align.Center(panel));
        }

        WaitForNext();
    }

    private void ShowSlide8_WhatWeLearned()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);

        Thread.Sleep(200);

        PrintCentered("", Color.White);
        AnimateTextCentered("🧠 KUNSKAPSEXPLOSION! 🧠", Color.Yellow, 25);
        PrintCentered("", Color.White);

        Thread.Sleep(400);

        var learnings = new (string icon, string title, string desc)[] {
            ("🤝", "Samarbete", "Kommunikation är ALLT i ett team"),
            ("🔀", "Git & GitHub", "Merge-konflikter är inte världens undergång"),
            ("👀", "Code Review", "Att granska andras kod lär en massor"),
            ("🏗️", "Arkitektur", "Service-Repository pattern i praktiken"),
            ("🤖", "AI Integration", "OpenAI API för att generera scheman"),
            ("💪", "Uthållighet", "Ge inte upp när det blir svårt!")
        };

        var learnTable = new Table().Border(TableBorder.None).Centered();
        learnTable.AddColumn(new TableColumn("").Width(5).Centered());
        learnTable.AddColumn(new TableColumn("").Width(18));
        learnTable.AddColumn(new TableColumn(""));

        foreach (var (icon, title, desc) in learnings)
        {
            Thread.Sleep(250);
            learnTable.AddRow($"[yellow]{icon}[/]", $"[bold cyan]{title}[/]", $"[grey]{desc}[/]");
        }

        AnsiConsole.Write(learnTable);

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);
        AnimateTextCentered("\"No pain, no gain!\" 💪", Color.Yellow, 25);

        WaitForNext();
    }

    private void ShowSlide9_DemoTime()
    {
        AnsiConsole.Clear();

        string[] countdown = { "3", "2", "1" };
        foreach (var num in countdown)
        {
            AnsiConsole.Clear();
            var bigNum = new FigletText(num)
                .Centered()
                .Color(Color.Yellow);
            AnsiConsole.Write(bigNum);
            Thread.Sleep(500);
        }

        AnsiConsole.Clear();

        string[] demoArt = {
            @"",
            @"██████╗ ███████╗███╗   ███╗ ██████╗ ",
            @"██╔══██╗██╔════╝████╗ ████║██╔═══██╗",
            @"██║  ██║█████╗  ██╔████╔██║██║   ██║",
            @"██║  ██║██╔══╝  ██║╚██╔╝██║██║   ██║",
            @"██████╔╝███████╗██║ ╚═╝ ██║╚██████╔╝",
            @"╚═════╝ ╚══════╝╚═╝     ╚═╝ ╚═════╝ ",
            @"",
            @"████████╗██╗███╗   ███╗███████╗██╗",
            @"╚══██╔══╝██║████╗ ████║██╔════╝██║",
            @"   ██║   ██║██╔████╔██║█████╗  ██║",
            @"   ██║   ██║██║╚██╔╝██║██╔══╝  ╚═╝",
            @"   ██║   ██║██║ ╚═╝ ██║███████╗██╗",
            @"   ╚═╝   ╚═╝╚═╝     ╚═╝╚══════╝╚═╝"
        };

        Color[] rainbow = { Color.Red, Color.Orange1, Color.Yellow, Color.Green, Color.Cyan1, Color.Blue, Color.Purple };
        int colorIndex = 0;

        foreach (var line in demoArt)
        {
            PrintCentered(line, rainbow[colorIndex % rainbow.Length]);
            if (!string.IsNullOrWhiteSpace(line)) colorIndex++;
            Thread.Sleep(30);
        }

        Thread.Sleep(300);

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);

        string[] muscleFrames = { "  💪  ", " 💪💪 ", "💪💪💪", " 💪💪 ", "  💪  " };

        for (int i = 0; i < 2; i++)
        {
            foreach (var frame in muscleFrames)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                PrintCentered(frame, Color.Yellow);
                Thread.Sleep(60);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        PrintCentered("💪💪💪💪💪", Color.Yellow);
        PrintCentered("", Color.White);

        Thread.Sleep(200);

        AnimateTextCentered("🎬 ÄR NI REDO FÖR DEMON? 🎬", Color.Cyan1, 30);
        PrintCentered("", Color.White);

        var finalPanel = new Panel(
            Align.Center(new Markup("[bold yellow]Team 7 — The Debuggers[/]\n[grey]Tack för att ni lyssnade![/]")))
        {
            Border = BoxBorder.Double,
            BorderStyle = new Style(Color.Yellow),
            Padding = new Padding(3, 1),
            Width = 40
        };

        AnsiConsole.Write(Align.Center(finalPanel));

        PrintCentered("", Color.White);
        PrintCentered("[[Tryck ENTER för att avsluta presentationen]]", Color.Grey);
        Console.ReadLine();
    }

    private void DrawSlideHeader(string number, string title, Color color)
    {
        var rule = new Rule($"[bold {color.ToMarkup()}]SLIDE {number} — {title}[/]")
        {
            Style = new Style(color),
            Justification = Justify.Center
        };
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private void PrintCentered(string text, Color color)
    {
        int width = Console.WindowWidth;
        int padding = Math.Max(0, (width - text.Length) / 2);

        Console.Write(new string(' ', padding));
        AnsiConsole.MarkupLine($"[{color.ToMarkup()}]{EscapeMarkup(text)}[/]");
    }

    private string EscapeMarkup(string text)
    {
        return text.Replace("[", "[[").Replace("]", "]]");
    }

    private void AnimateTextCentered(string text, Color color, int delayPerChar)
    {
        int width = Console.WindowWidth;
        int padding = Math.Max(0, (width - text.Length) / 2);

        Console.Write(new string(' ', padding));

        foreach (char c in text)
        {
            AnsiConsole.Markup($"[{color.ToMarkup()}]{(c == '[' ? "[[" : c == ']' ? "]]" : c.ToString())}[/]");
            if (delayPerChar > 0) Thread.Sleep(delayPerChar);
        }
        Console.WriteLine();
    }

    private void WaitForNext()
    {
        AnsiConsole.WriteLine();
        int width = Console.WindowWidth;
        string text = "Tryck ENTER för nästa slide →";
        int padding = Math.Max(0, (width - text.Length) / 2);
        Console.Write(new string(' ', padding));
        AnsiConsole.MarkupLine("[grey]Tryck [yellow]ENTER[/] för nästa slide →[/]");
        Console.ReadLine();
    }
}