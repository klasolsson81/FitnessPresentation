using Spectre.Console;

namespace FitnessPresentationApp;

/// <summary>
/// Innehåller all statisk data för presentationen (ASCII-art, team info, etc.).
/// Håller data separerad från presentationslogiken.
/// </summary>
public static class SlideData
{
    public static readonly string[] TeamMembers =
    {
        "Klas Olsson",
        "Mohammed Yusur",
        "Sacad Elmi",
        "Sajad Azizi",
        "Yonis Bashir"
    };

    public static readonly string CodeMeme =
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

    public static readonly string[] Logo =
    {
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

    public static readonly string[] Dumbbell =
    {
        @"",
        @"    ╔═══╗                           ╔═══╗",
        @"    ║   ║ ═══════════════════════ ║   ║",
        @"    ║   ║ ═══════════════════════ ║   ║",
        @"    ╚═══╝                           ╚═══╝",
        @""
    };

    public static readonly (string text, string colorMarkup)[] FileTreeStructure =
    {
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

    public static readonly string[] DemoArt =
    {
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

    public static readonly string[] BombFrames =
    {
        "   ╭───╮\n   │💣 │  ~~~°\n   ╰───╯",
        "   ╭───╮\n   │💣 │  ~~°\n   ╰───╯",
        "   ╭───╮\n   │💣 │  ~°\n   ╰───╯",
        "   ╭───╮\n   │💣 │  °\n   ╰───╯",
        "   ╭───╮\n   │💣 │ *\n   ╰───╯"
    };

    // Explosionsanimation - växer från liten till stor
    public static readonly string[][] ExplosionFrames =
    {
        // Frame 1 - Liten explosion
        new string[]
        {
            @"     •",
            @"    • •",
            @"     •"
        },
        // Frame 2 - Växer lite
        new string[]
        {
            @"    • * •",
            @"   * 💥 *",
            @"    • * •"
        },
        // Frame 3 - Växer mer
        new string[]
        {
            @"   • * • * •",
            @"  * • 💥 • *",
            @" • * 💥💥 * •",
            @"  * • 💥 • *",
            @"   • * • * •"
        },
        // Frame 4 - Ännu större
        new string[]
        {
            @"    * • * • * • *",
            @"  • * • 💥 • * •",
            @" * • 💥 💥💥 💥 • *",
            @"• * 💥 💥BOOM💥 💥 * •",
            @" * • 💥 💥💥 💥 • *",
            @"  • * • 💥 • * •",
            @"    * • * • * • *"
        },
        // Frame 5 - Maximal explosion!
        new string[]
        {
            @"      * • • * • • * • • *",
            @"   * • * 💥 • * • 💥 * • *",
            @"  • * 💥 • 💥💥 💥💥 • 💥 * •",
            @" * • 💥 💥 💥BOOM💥 💥 💥 • *",
            @"• * 💥 💥💥 💥💥💥💥 💥💥 💥 * •",
            @" * • 💥 💥 💥💥💥 💥 💥 • *",
            @"  • * 💥 • 💥💥 💥💥 • 💥 * •",
            @"   * • * 💥 • * • 💥 * • *",
            @"      * • • * • • * • • *"
        },
        // Frame 6 - Rök och glöd
        new string[]
        {
            @"     * • • * • • * • • * • • *",
            @"   • * 💥 • * 💥 • 💥 * • 💥 * •",
            @"  * • 💥 * 💥 💥💥 💥💥 💥 * 💥 • *",
            @" • * 💥 💥 • 💥💥💥 💥💥 • 💥 💥 * •",
            @"* • 💥 💥 💥💥 💥💥💥 💥💥 💥💥 💥 • *",
            @" • * 💥 💥 • 💥💥💥 💥💥 • 💥 💥 * •",
            @"  * • 💥 * 💥 💥💥 💥💥 💥 * 💥 • *",
            @"   • * 💥 • * 💥 • 💥 * • 💥 * •",
            @"     * • • * • • * • • * • • *"
        }
    };

    public static readonly string[] MuscleFrames =
    {
        "  💪  ",
        " 💪💪 ",
        "💪💪💪",
        " 💪💪 ",
        "  💪  "
    };

    public static readonly (string icon, string title, string desc)[] Learnings =
    {
        ("🤝", "Samarbete", "Kommunikation är ALLT i ett team"),
        ("🔀", "Git & GitHub", "Merge-konflikter är inte världens undergång"),
        ("👀", "Code Review", "Att granska andras kod lär en massor"),
        ("🏗️", "Arkitektur", "Service-Repository pattern i praktiken"),
        ("🤖", "AI Integration", "OpenAI API för att generera scheman"),
        ("💪", "Uthållighet", "Ge inte upp när det blir svårt!")
    };

    // Slide 2 - Planning
    public static readonly string[] CrudArt =
    {
        "  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐",
        "  │ [green]CREATE[/]  │ │  [blue]READ[/]   │ │ [yellow]UPDATE[/]  │ │ [red]DELETE[/]  │ │   [purple]AI[/]    │",
        "  │   [green]📝[/]    │ │   [blue]👁️[/]    │ │   [yellow]✏️[/]    │ │   [red]🗑️[/]    │ │   [purple]🤖[/]    │",
        "  └─────────┘ └─────────┘ └─────────┘ └─────────┘ └─────────┘"
    };

    // Slide 3 - PT Use Cases
    public static readonly string[] PTIcon =
    {
        @"██████╗ ████████╗",
        @"██╔══██╗╚══██╔══╝",
        @"██████╔╝   ██║   ",
        @"██╔═══╝    ██║   ",
        @"██║        ██║   ",
        @"╚═╝        ╚═╝   "
    };

    public static readonly string[] PTUseCases =
    {
        "👥 En PT ska kunna hantera sina klienter",
        "🗑️ En PT ska kunna ta bort klienter",
        "🎯 En PT ska kunna sätta mål för klienter",
        "🏋️ En PT ska kunna skapa träningsschema för klienter",
        "🥗 En PT ska kunna skapa kostschema för klienter",
        "📊 En PT ska kunna se loggar och framsteg för klienter"
    };

    // Slide 4 - Client Use Cases
    public static readonly string[] ClientIcon =
    {
        @"██╗  ██╗██╗     ██╗███████╗███╗   ██╗████████╗",
        @"██║ ██╔╝██║     ██║██╔════╝████╗  ██║╚══██╔══╝",
        @"█████╔╝ ██║     ██║█████╗  ██╔██╗ ██║   ██║   ",
        @"██╔═██╗ ██║     ██║██╔══╝  ██║╚██╗██║   ██║   ",
        @"██║  ██╗███████╗██║███████╗██║ ╚████║   ██║   ",
        @"╚═╝  ╚═╝╚══════╝╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   "
    };

    public static readonly string[] ClientUseCases =
    {
        "📋 En klient ska kunna se sina scheman",
        "⚖️ En klient ska kunna uppdatera sin vikt",
        "✅ En klient ska kunna markera pass som genomförda",
        "📈 En klient ska kunna se statistik och framgång",
        "🎯 En klient ska kunna se sina mål"
    };

    // Slide 6 - Communication Tools
    public static readonly (string icon, string name, string desc, Color color)[] CommunicationTools =
    {
        ("💬", "DISCORD", "Egen kanal för snabb kommunikation", Color.Purple),
        ("📹", "TEAMS", "Daily check-ins och stand-ups", Color.Blue),
        ("🐙", "GITHUB", "Pull Requests & Code Reviews", Color.Green)
    };

    // Slide 7 - Chaos/Problems
    public static readonly string[] ChaosText =
    {
        "!@#$%",
        "ERROR",
        "PANIC",
        "HELP!",
        "???!!"
    };

    public static readonly (string icon, string title, string desc, Color color)[] Problems =
    {
        ("🔑", "API-NYCKEL LÄCKA", "Råkade pusha .env till GitHub — Nyckeln stoppades automatiskt!", Color.Orange1),
        ("💥", "MERGE KONFLIKTER", "Flera versioner av samma fil — Ocommittade ändringar blockerade pulls", Color.Red),
        ("🤯", ".ENV PROBLEM", "Svårt att få .env att fungera utan konflikter mellan datorer", Color.Yellow),
        ("😅", "GIT FÖRVIRRING", "\"Var är mina ändringar?!\" — \"Vem tog bort min kod?!\"", Color.Purple)
    };
}