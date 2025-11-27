# Fitness Presentation App - Refaktorerad Kod

## 📁 Filstruktur

```
FitnessPresentationApp/
├── Program.cs              // Entry point (4 rader!)
├── Presentation.cs         // Huvudorkestrearen
├── SlideManager.cs         // Hanterar individuella slides
├── SlideRenderer.cs        // Renderar olika UI-element
├── ConsoleHelper.cs        // Console-interaktion och utilities
├── SlideData.cs           // All statisk data (ASCII-art, etc.)
└── Constants.cs           // Alla konstanter och konfiguration
```

## 🎯 Vad har förändrats?

### 1. **Single Responsibility Principle (SRP)**
Varje klass har nu ETT ansvar:
- **ConsoleHelper**: Console-operationer (centering, animation, input)
- **SlideRenderer**: Rendering av UI-element (panels, tabeller, ASCII-art)
- **SlideManager**: Visar individuella slides
- **SlideData**: Håller all data
- **Constants**: Konfigurationsvärden
- **Presentation**: Orkesterar flödet

### 2. **DRY (Don't Repeat Yourself)**
- Centering-logik: Fanns på 10+ ställen → Nu i `ConsoleHelper`
- Animation-logik: Duplicerad överallt → Nu i `ConsoleHelper` och `SlideRenderer`
- ASCII-art rendering: Upprepades → Nu i `SlideRenderer`

### 3. **Felhantering**
- `try/catch` block i alla kritiska metoder
- Graceful fallbacks om något går fel
- Huvudmetod `Run()` har övergripande felhantering

### 4. **Kodlängd**
- **Före**: 1 klass, 822 rader
- **Efter**: 7 klasser, varje med tydligt ansvar

### 5. **Konstanter istället för Magic Numbers**
```csharp
// Före
Thread.Sleep(350);

// Efter
Thread.Sleep(Constants.Timing.BombAnimationDelay);
```

## 🔍 Pedagogiska förklaringar

### Single Responsibility - Varför?
När en klass gör för mycket blir den:
- Svår att förstå
- Svår att testa
- Svår att ändra (en förändring påverkar mycket)

**Exempel från din kod:**
```csharp
// FÖRE: Presentation-klassen gjorde ALLT
public class Presentation
{
    // Visar slides
    // Animerar text
    // Hanterar färger
    // Väntar på input
    // Beräknar positioning
    // 822 rader kod!
}

// EFTER: Ansvar är uppdelat
ConsoleHelper → Console-operationer
SlideRenderer → Rendering
SlideManager → Slide-logik
```

### DRY - Varför?
När du upprepar kod:
- Måste du ändra på flera ställen vid bugfixar
- Risk för inkonsistens
- Svårare att underhålla

**Exempel:**
```csharp
// FÖRE: Centering-kod fanns på 10+ ställen
int width = Console.WindowWidth;
int padding = Math.Max(0, (width - text.Length) / 2);
Console.Write(new string(' ', padding));
// ... upprepas överallt

// EFTER: En metod gör jobbet
_consoleHelper.PrintCentered(text, color);
```

### Felhantering - Varför?
Din kod kördes direkt i konsolen utan skydd:
```csharp
// FÖRE: Ingen felhantering
Console.SetCursorPosition(0, cursorTop); // Kan krascha!

// EFTER: Säker hantering
try
{
    Console.SetCursorPosition(0, cursorTop);
}
catch (Exception)
{
    // Fallback om positionering misslyckas
}
```

## 💡 Vad du kan lära dig

1. **Separera ansvar**: När en klass blir över 200-300 rader, fundera på om den gör för mycket
2. **Extrahera metoder**: Om du kopierar/klistrar kod → skapa en metod
3. **Använd konstanter**: Inga magiska nummer i koden
4. **Felhantering**: Skydda din kod där saker kan gå fel (I/O, parsing, etc.)
5. **Testa i delar**: Mindre klasser är lättare att testa

## 🚀 Hur koden körs

```csharp
// 1. Program.cs skapar Presentation
var presentation = new Presentation();

// 2. Presentation skapar dependencies
_consoleHelper = new ConsoleHelper();
_renderer = new SlideRenderer(_consoleHelper);
_slideManager = new SlideManager(_consoleHelper, _renderer);

// 3. Kör alla slides via SlideManager
_slideManager.ShowLandingPage();
_slideManager.ShowSlide1_CodeStructure();
// ... osv
```

## 📝 Noteringar

- Slides 2-7 har placeholder-innehåll - lägg till ditt eget innehåll där
- Alla animationer och timings kan justeras i `Constants.cs`
- Lägg till fler slides genom att skapa nya metoder i `SlideManager`

## 🎓 Nästa steg för dig

1. Lägg till innehållet för de tomma slides (2-7)
2. Lägg till fler konstanter där det behövs
3. Fundera på om någon metod är för lång och kan delas upp
4. Överväg att lägga till enhetstester för `ConsoleHelper` och `SlideRenderer`
