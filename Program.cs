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
        // 1. Rensa konsolen så vi har en ren yta
        AnsiConsole.Clear();

        // 2. Definiera "koden" med färger (VS Dark Mode style)
        var codeMeme =
            "[rgb(86,156,214)]public void[/] [rgb(220,220,170)]Workout[/]()\n" +
            "{\n" +
            "    [rgb(86,156,214)]if[/] (!workout.IsPainful)\n" +
            "    {\n" +
            "        gains.[rgb(220,220,170)]Add[/]([rgb(86,156,214)]null[/]); [rgb(87,166,74)]// No pain, no gain[/]\n" +
            "    }\n" +
            "    [rgb(86,156,214)]else[/]\n" +
            "    {\n" +
            "        body.[rgb(220,220,170)]LevelUp[/]();\n" +
            "    }\n" +
            "}";

        // 3. Skapa panelen
        var panel = new Panel(new Markup(codeMeme))
            .Header(" GymLogic.cs ", Justify.Left)
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Grey))
            .Padding(2, 1, 2, 1);

        // 4. Räkna ut mitten vertikalt
        // Vi drar av ca 10 rader (panelens höjd) från fönstrets höjd och delar på 2
        int windowHeight = Console.WindowHeight;
        int verticalPadding = (windowHeight / 2) - 6;

        // Se till att vi inte kraschar om fönstret är pyttelitet
        if (verticalPadding < 0) verticalPadding = 0;

        // Skriv ut tomma rader för att trycka ner innehållet
        for (int i = 0; i < verticalPadding; i++)
        {
            AnsiConsole.WriteLine();
        }

        // 5. Skriv ut panelen centrerad horisontellt
        AnsiConsole.Write(
            new Align(panel, HorizontalAlignment.Center)
        );

        // 6. Instruktion för att gå vidare (lite diskret under)
        AnsiConsole.Write(new Align(
            new Markup("[grey]Tryck på valfri tangent för att fortsätta...[/]"),
            HorizontalAlignment.Center));

        // 7. Vänta på tangenttryckning (true gör att tangenten inte skrivs ut på skärmen)
        Console.ReadKey(true);

        // Här fortsätter resten av ditt program...
        AnsiConsole.MarkupLine("\n[green]Programmet fortsätter![/]");

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

        // Animated file structure - character by character
        var treeLines = new (string text, string colorMarkup)[] {
            ("📁 FitnessProgressTracker", "yellow"),
            ("│", "grey"),
            ("├─📁 Models", "green"),
            ("│  ├─ User.cs (abstrakt basklass)", "white"),
            ("│  ├─ Client.cs", "white"),
            ("│  ├─ PT.cs", "white"),
            ("│  ├─ WorkoutPlan.cs", "white"),
            ("│  ├─ DietPlan.cs", "white"),
            ("│  ├─ DailyWorkout.cs", "white"),
            ("│  ├─ DailyMealPlan.cs", "white"),
            ("│  ├─ Exercise.cs", "white"),
            ("│  ├─ ProgressLog.cs", "white"),
            ("│  └─ Appointment.cs", "white"),
            ("│", "grey"),
            ("├─📁 Services", "blue"),
            ("│  ├─ LoginService.cs", "white"),
            ("│  ├─ ClientService.cs", "white"),
            ("│  ├─ ScheduleService.cs", "white"),
            ("│  ├─ ProgressService.cs", "white"),
            ("│  ├─ AiService.cs", "white"),
            ("│  └─📁 Interfaces", "magenta1"),
            ("│     └─ IDataStore.cs", "white"),
            ("│", "grey"),
            ("├─📁 UI", "yellow"),
            ("│  ├─ Menu.cs", "white"),
            ("│  ├─ ClientMenu.cs", "white"),
            ("│  ├─ PtMenu.cs", "white"),
            ("│  └─ SpectreUIHelper.cs", "white"),
            ("│", "grey"),
            ("├─📁 Data (JSON)", "red"),
            ("│  ├─ clients.json", "white"),
            ("│  ├─ pts.json", "white"),
            ("│  ├─ workouts.json", "white"),
            ("│  ├─ diets.json", "white"),
            ("│  └─ logs.json", "white"),
            ("│", "grey"),
            ("├─ Program.cs", "white"),
            ("└─ FitnessProgressTracker.csproj", "white")
        };

        // Calculate center padding
        int boxWidth = 47;
        int windowWidth = Console.WindowWidth;
        int leftPadding = Math.Max(0, (windowWidth - boxWidth - 2) / 2);
        string padding = new string(' ', leftPadding);

        // Draw box top
        AnsiConsole.MarkupLine($"{padding}[cyan1]╭{new string('─', boxWidth)}╮[/]");

        // Animate each line character by character
        int totalLineTime = 50; // Total ms per line
        foreach (var (text, colorMarkup) in treeLines)
        {
            int textLen = text.Length;
            int rightPad = boxWidth - textLen - 1;
            if (rightPad < 0) rightPad = 0;

            // Print left border
            Console.Write($"{padding}");
            AnsiConsole.Markup($"[cyan1]│[/] ");

            // Print each character with delay
            int delayPerChar = textLen > 0 ? totalLineTime / textLen : 0;
            foreach (char c in text)
            {
                string charStr = c == '[' ? "[[" : c == ']' ? "]]" : c.ToString();
                AnsiConsole.Markup($"[{colorMarkup}]{charStr}[/]");
                if (delayPerChar > 0) Thread.Sleep(delayPerChar);
            }

            // Print right padding and border
            AnsiConsole.MarkupLine($"{new string(' ', rightPad)}[cyan1]│[/]");
        }

        //// Draw box bottom
        //AnsiConsole.MarkupLine($"{padding}[cyan1]╰{new string('─', boxWidth)}╯[/]");

        //Thread.Sleep(300);

        //AnsiConsole.WriteLine();

        //var statsTable = new Table().Border(TableBorder.Rounded).BorderColor(Color.Cyan1);
        //statsTable.AddColumn(new TableColumn("[bold]Kategori[/]").Centered());
        //statsTable.AddColumn(new TableColumn("[bold]Antal[/]").Centered());
        //statsTable.AddRow("[green]Models[/]", "10 klasser");
        //statsTable.AddRow("[blue]Services[/]", "5 klasser");
        //statsTable.AddRow("[yellow]UI[/]", "4 klasser");
        //statsTable.AddRow("[red]Data[/]", "5 JSON-filer");

        //AnsiConsole.Write(Align.Center(statsTable));

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

        // Vision panel - using Padder for centering
        int visionWidth = 44;
        int visionPad = Math.Max(0, (Console.WindowWidth - visionWidth) / 2);

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

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
        PrintCentered("", Color.White);

        // ASCII Art CRUD boxes
        string[] crudArt = {
            "  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐",
            "  │ [green]CREATE[/]  │ │  [blue]READ[/]   │ │ [yellow]UPDATE[/]  │ │ [red]DELETE[/]  │ │   [purple]AI[/]    │",
            "  │   [green]📝[/]    │ │   [blue]👁️[/]    │ │   [yellow]✏️[/]    │ │   [red]🗑️[/]    │ │   [purple]🤖[/]    │",
            "  └─────────┘ └─────────┘ └─────────┘ └─────────┘ └─────────┘"
        };

        foreach (var line in crudArt)
        {
            int width = Console.WindowWidth;
            // Approximate visible length (rough estimate accounting for markup)
            int visibleLength = 65;
            int pad = Math.Max(0, (width - visibleLength) / 2);
            Console.Write(new string(' ', pad));
            AnsiConsole.MarkupLine(line);
            Thread.Sleep(100);
        }

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

        int panelWidth = 45;
        int panelPad = Math.Max(0, (Console.WindowWidth - panelWidth) / 2);

        foreach (var (icon, name, desc, color) in tools)
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

        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
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
            Thread.Sleep(250);  // Slower animation - was 80
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

        int panelWidth = 75;
        int panelPad = Math.Max(0, (Console.WindowWidth - panelWidth) / 2);

        foreach (var (icon, title, desc, color) in problems)
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

        WaitForNext();
    }

    private void ShowSlide8_WhatWeLearned()
    {
        AnsiConsole.Clear();
        DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);

        Thread.Sleep(200);

        // Bomb animation with fuse - centered vertically
        PrintCentered("", Color.White);
        PrintCentered("", Color.White);

        string[] bombFrames = {
            "   ╭───╮\n   │💣 │  ~~~~°\n   ╰───╯",
            "   ╭───╮\n   │💣 │  ~~~°\n   ╰───╯",
            "   ╭───╮\n   │💣 │  ~~°\n   ╰───╯",
            "   ╭───╮\n   │💣 │  ~°\n   ╰───╯",
            "   ╭───╮\n   │💣 │  °\n   ╰───╯",
            "   ╭───╮\n   │💣 │ *\n   ╰───╯"
        };

        int cursorTop = Console.CursorTop;
        foreach (var frame in bombFrames)
        {
            Console.SetCursorPosition(0, cursorTop);
            foreach (var line in frame.Split('\n'))
            {
                PrintCentered(line, Color.Orange1);
            }
            Thread.Sleep(350);
        }

        // Explosion!
        Thread.Sleep(100);
        AnsiConsole.Clear();
        DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);
        PrintCentered("", Color.White);

        string[] explosion = {
            @"         *  *  *",
            @"    *    💥💥💥    *",
            @"  *   💥  BOOM!  💥   *",
            @"    *    💥💥💥    *",
            @"         *  *  *"
        };

        foreach (var line in explosion)
        {
            PrintCentered(line, Color.Yellow);
        }


        // Now show all the knowledge!
        AnsiConsole.Clear();
        DrawSlideHeader("8", "VAD HAR VI LÄRT OSS?", Color.Green);

        PrintCentered("", Color.White);
        AnimateTextCentered("🧠 KUNSKAPSEXPLOSION! 🧠", Color.Yellow, 0);
        PrintCentered("", Color.White);


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
            //Thread.Sleep(200);
            learnTable.AddRow($"[yellow]{icon}[/]", $"[bold cyan]{title}[/]", $"[grey]{desc}[/]");
        }

        AnsiConsole.Write(learnTable);

        PrintCentered("", Color.White);
        PrintCentered("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.Grey);
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

        int finalWidth = 36;
        int finalPad = Math.Max(0, (Console.WindowWidth - finalWidth) / 2);

        var finalPanel = new Panel(
            new Markup("[bold yellow]Team 7 — The Debuggers[/]\n[grey]Tack för att ni lyssnade![/]"))
        {
            Border = BoxBorder.Double,
            BorderStyle = new Style(Color.Yellow),
            Padding = new Padding(3, 1),
            Width = finalWidth
        };

        AnsiConsole.Write(new Padder(finalPanel, new Padding(finalPad, 0, 0, 0)));

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