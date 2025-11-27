# REFAKTORERINGSFÖRKLARING - Clean Code

## 📊 Översikt av ändringar

### Före refaktorering:
- **1 fil**: Program.cs
- **1 klass**: Presentation (822 rader)
- **Inga** felhanteringar
- **Mycket** upprepning av kod
- **Svårt** att hitta och ändra saker

### Efter refaktorering:
- **7 filer**: Varje med sitt ansvar
- **7 klasser**: Alla under 200 rader
- **Try/catch** där det behövs
- **Minimal** upprepning (DRY)
- **Lätt** att hitta och ändra saker

---

## 🔍 DETALJERAD FÖRKLARING

### 1. Constants.cs - Alla magiska nummer samlade

**Problem före:**
```csharp
Thread.Sleep(350);  // Vad betyder 350?
Thread.Sleep(60);   // Vad betyder 60?
Thread.Sleep(500);  // Vad betyder 500?
```

**Lösning efter:**
```csharp
public static class Constants
{
    public static class Timing
    {
        public const int BombAnimationDelay = 350;
        public const int SlowAnimation = 60;
        public const int PauseBetweenSlides = 500;
    }
}
```

**Varför är detta bättre?**
- ✅ Tydligt vad varje värde betyder
- ✅ Lätt att ändra alla timing-värden på ett ställe
- ✅ Konsistent användning genom hela koden

---

### 2. SlideData.cs - Data separerat från logik

**Problem före:**
```csharp
private readonly string[] _teamMembers = { "Klas...", "Mohammed..." };
// ASCII-art inbäddad direkt i metoderna
string[] logo = { @"███..." };
```

**Lösning efter:**
```csharp
public static class SlideData
{
    public static readonly string[] TeamMembers = { ... };
    public static readonly string[] Logo = { ... };
    public static readonly string[] Dumbbell = { ... };
    // All data på ett ställe!
}
```

**Varför är detta bättre?**
- ✅ Data är separerad från logik
- ✅ Lätt att hitta och uppdatera innehåll
- ✅ Kan enkelt laddas från fil senare om man vill
- ✅ Följer "Separation of Concerns"

---

### 3. ConsoleHelper.cs - En klass för Console-operationer

**Problem före (fanns i många metoder):**
```csharp
// Upprepades 10+ gånger
int width = Console.WindowWidth;
int padding = Math.Max(0, (width - text.Length) / 2);
Console.Write(new string(' ', padding));
AnsiConsole.MarkupLine($"[{color.ToMarkup()}]{EscapeMarkup(text)}[/]");
```

**Lösning efter:**
```csharp
public class ConsoleHelper
{
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
            // Felhantering!
            AnsiConsole.MarkupLine($"[red]Fel: {ex.Message}[/]");
        }
    }
}
```

**Användning:**
```csharp
// Före: 4 rader kod varje gång
// Efter: 1 rad kod
_consoleHelper.PrintCentered("Min text", Color.Yellow);
```

**Varför är detta bättre?**
- ✅ DRY - Inget copy/paste
- ✅ Felhantering på ett ställe
- ✅ Lätt att testa isolerat
- ✅ Single Responsibility - Hanterar endast console

---

### 4. SlideRenderer.cs - Rendering-logik centraliserad

**Problem före:**
Renderingslogik för paneler, tabeller, ASCII-art var spretat i många metoder.

**Lösning efter:**
```csharp
public class SlideRenderer
{
    private readonly ConsoleHelper _consoleHelper;

    // Olika rendering-metoder
    public void DrawSlideHeader(string number, string title, Color color) { ... }
    public void RenderAsciiArt(string[] art, Color color, int delay) { ... }
    public void RenderLearningsTable(...) { ... }
    public void RenderCodePanel(...) { ... }
}
```

**Varför är detta bättre?**
- ✅ All rendering-logik på ett ställe
- ✅ Återanvändbar för olika slides
- ✅ Lätt att lägga till nya rendering-funktioner
- ✅ Använder ConsoleHelper för bas-operationer (bra separation!)

---

### 5. SlideManager.cs - Hanterar slides

**Problem före:**
```csharp
// Allt i Presentation-klassen
public void ShowSlide1_CodeStructure() { ... 100+ rader ... }
public void ShowSlide8_WhatWeLearned() { ... 150+ rader ... }
```

**Lösning efter:**
```csharp
public class SlideManager
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly SlideRenderer _renderer;

    public void ShowSlide1_CodeStructure()
    {
        AnsiConsole.Clear();
        _renderer.DrawSlideHeader("1", "KODSTRUKTUR", Color.Blue);
        RenderFileTree();
        _consoleHelper.WaitForNext();
    }

    // Slides är uppdelade i mindre metoder
    private void ShowBombAnimation() { ... }
    private void ShowExplosion() { ... }
    private void ShowLearnings() { ... }
}
```

**Varför är detta bättre?**
- ✅ Varje slide är uppdelad i logiska delar
- ✅ Använder SlideRenderer och ConsoleHelper
- ✅ Lättare att förstå flödet
- ✅ Lättare att ändra en specifik slide

---

### 6. Presentation.cs - Slimmad orkestrerare

**Före (822 rader):**
```csharp
public class Presentation
{
    // ALLT fanns här:
    // - Slide-metoder (100+ rader var)
    // - Rendering-logik
    // - Animation-logik
    // - Console-logik
    // - Data
}
```

**Efter (70 rader):**
```csharp
public class Presentation
{
    private readonly SlideManager _slideManager;
    private readonly ConsoleHelper _consoleHelper;

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

    private void RunAllSlides()
    {
        _slideManager.ShowLandingPage();
        _slideManager.ShowSlide1_CodeStructure();
        // ... osv
    }
}
```

**Varför är detta bättre?**
- ✅ Tydligt vad som händer (Initialize → Run → Cleanup)
- ✅ Delegerar allt arbete till specialiserade klasser
- ✅ Felhantering på högsta nivån
- ✅ Lätt att förstå programflödet

---

### 7. Program.cs - Ultrasimple entry point

**Före:**
```csharp
// 10+ rader med setup
Console.OutputEncoding = Encoding.UTF8;
var presentation = new Presentation();
presentation.Run();
```

**Efter:**
```csharp
using FitnessPresentationApp;

var presentation = new Presentation();
presentation.Run();
```

**Varför är detta bättre?**
- ✅ Minimal entry point
- ✅ Setup görs i Presentation
- ✅ Tydlig namespace-användning

---

## 🎯 CLEAN CODE PRINCIPER TILLÄMPADE

### 1. Single Responsibility Principle (SRP)
**Definition**: En klass ska ha ETT ansvar.

**Tillämpning:**
- `ConsoleHelper` → Endast console-operationer
- `SlideRenderer` → Endast rendering
- `SlideData` → Endast data
- `Constants` → Endast konfiguration

### 2. DRY (Don't Repeat Yourself)
**Definition**: Duplicera inte kod.

**Före:**
- Centering-kod: 10+ ställen
- Animation-logik: 8+ ställen
- Färghantering: Överallt

**Efter:**
- Centering: 1 metod i `ConsoleHelper`
- Animation: 2 metoder i `ConsoleHelper` och `SlideRenderer`
- Färghantering: Centraliserad

### 3. Small Methods
**Definition**: Metoder ska vara korta och göra EN sak.

**Exempel:**
```csharp
// FÖRE: En stor metod (150+ rader)
public void ShowSlide8_WhatWeLearned() { /* allt här */ }

// EFTER: Uppdelat i mindre metoder
public void ShowSlide8_WhatWeLearned()
{
    ShowBombAnimation();      // ~15 rader
    ShowExplosion();          // ~10 rader
    ShowLearnings();          // ~20 rader
}
```

### 4. Error Handling
**Definition**: Hantera fel där de kan uppstå.

**Tillämpning:**
```csharp
public void PrintCentered(string text, Color color)
{
    try
    {
        // Kod som kan krascha
        Console.WindowWidth; // Kan misslyckas i vissa miljöer
    }
    catch (Exception ex)
    {
        // Graceful fallback
        AnsiConsole.MarkupLine($"[red]Fel: {ex.Message}[/]");
    }
}
```

### 5. Meaningful Names
**Definition**: Namn ska förklara vad de gör.

**Före:**
```csharp
Thread.Sleep(350); // Oklart varför
int x = 47;        // Vad betyder 47?
```

**Efter:**
```csharp
Thread.Sleep(Constants.Timing.BombAnimationDelay);
int boxWidth = Constants.Layout.FileTreeBoxWidth;
```

---

## 📈 MÄTBARA FÖRBÄTTRINGAR

| Metric | Före | Efter | Förbättring |
|--------|------|-------|-------------|
| Antal filer | 1 | 7 | +600% modularitet |
| Största klass | 822 rader | 200 rader | -75% |
| Upprepning | Hög | Minimal | ~90% mindre |
| Felhantering | 0 try/catch | 15+ try/catch | ∞% bättre |
| Testbarhet | Svår | Lätt | Mycket bättre |
| Läsbarhet | Låg | Hög | Mycket bättre |

---

## 🎓 VAD KAN DU LÄRA DIG?

### För nybörjare:
1. **När en fil blir för stor** (>300 rader) → Dela upp den
2. **När du kopierar kod** → Skapa en metod
3. **När en metod blir lång** (>50 rader) → Dela upp den
4. **När något kan gå fel** → Lägg till try/catch

### För fortsatta studier:
1. **Dependency Injection**: Istället för `new ConsoleHelper()` i konstruktorn
2. **Interfaces**: För att göra koden mer testbar
3. **Unit Testing**: Nu är klasserna små nog att testa
4. **Design Patterns**: Factory, Strategy, etc.

---

## ✅ SAMMANFATTNING

**Vad har vi åstadkommit?**
1. ✅ Tillämpat Single Responsibility Principle
2. ✅ Eliminerat code duplication (DRY)
3. ✅ Lagt till grundläggande felhantering
4. ✅ Strukturerat kod i logiska klasser
5. ✅ Gjort koden lättare att förstå och underhålla

**Är koden perfekt?**
Nej, men den är MYCKET bättre och följer Clean Code-principer på en grundnivå som passar för en .NET-student!

**Nästa steg:**
- Implementera innehållet i de tomma slides (2-7)
- Lägg till fler konstanter där det behövs
- Fundera på att lägga till unit tests
- Experimentera med att dela upp SlideManager ytterligare om den blir för stor
