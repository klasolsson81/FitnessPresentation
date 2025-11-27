# 📁 FILSTRUKTUR GUIDE

## Översikt av alla filer

```
FitnessPresentationApp/
│
├── 📄 Program.cs                    (4 rader)
│   └── Entry point - Startar presentationen
│
├── 📄 Presentation.cs               (~70 rader)
│   └── Huvudorkestrearen
│       ├── Initialiserar console
│       ├── Kör alla slides
│       └── Hanterar fel på högsta nivån
│
├── 📄 SlideManager.cs               (~200 rader)
│   └── Hanterar individuella slides
│       ├── ShowLandingPage()
│       ├── ShowSlide1_CodeStructure()
│       ├── ShowSlide8_WhatWeLearned()
│       └── ShowSlide9_DemoTime()
│
├── 📄 SlideRenderer.cs              (~150 rader)
│   └── Renderar UI-element
│       ├── DrawSlideHeader()
│       ├── RenderAsciiArt()
│       ├── RenderLearningsTable()
│       └── RenderCodePanel()
│
├── 📄 ConsoleHelper.cs              (~140 rader)
│   └── Console-interaktion
│       ├── PrintCentered()
│       ├── AnimateTextCentered()
│       ├── WaitForNext()
│       └── CalculateVerticalPadding()
│
├── 📄 SlideData.cs                  (~150 rader)
│   └── All statisk data
│       ├── TeamMembers[]
│       ├── Logo[]
│       ├── FileTreeStructure[]
│       └── Learnings[]
│
└── 📄 Constants.cs                  (~30 rader)
    └── Alla konstanter
        ├── Timing (animation delays)
        └── Layout (dimensioner)
```

---

## Ansvarsområden per fil

### 🎯 Program.cs
**Ansvar**: Entry point
**Gör**: Skapar Presentation och kör den
**Radantal**: 4
**Komplexitet**: Minimal

### 🎯 Presentation.cs
**Ansvar**: Orkestrera hela presentationen
**Gör**: 
- Initialiserar console-inställningar
- Kör alla slides i ordning
- Hanterar kritiska fel
**Radantal**: ~70
**Komplexitet**: Låg
**Dependencies**: SlideManager, ConsoleHelper

### 🎯 SlideManager.cs
**Ansvar**: Hantera individuella slides
**Gör**:
- Visar varje slide
- Delar upp slides i logiska delar
- Anropar ConsoleHelper och SlideRenderer
**Radantal**: ~200
**Komplexitet**: Medel
**Dependencies**: ConsoleHelper, SlideRenderer

### 🎯 SlideRenderer.cs
**Ansvar**: Rendera UI-element
**Gör**:
- Ritar headers, paneler, tabeller
- Renderar ASCII-art
- Hanterar animationer
**Radantal**: ~150
**Komplexitet**: Medel
**Dependencies**: ConsoleHelper

### 🎯 ConsoleHelper.cs
**Ansvar**: Console-operationer
**Gör**:
- Centrerar text
- Animerar tecken
- Hanterar input
- Beräknar positioning
**Radantal**: ~140
**Komplexitet**: Låg
**Dependencies**: Inga (bara System)

### 🎯 SlideData.cs
**Ansvar**: Hålla all data
**Gör**:
- Lagrar ASCII-art
- Lagrar teammedlemmar
- Lagrar alla text-konstanter
**Radantal**: ~150
**Komplexitet**: Ingen (endast data)
**Dependencies**: Inga

### 🎯 Constants.cs
**Ansvar**: Konfiguration
**Gör**:
- Definierar timing-värden
- Definierar layout-dimensioner
**Radantal**: ~30
**Komplexitet**: Ingen (endast konstanter)
**Dependencies**: Inga

---

## Dependency-graf (Vem använder vem?)

```
Program.cs
    ↓
Presentation.cs
    ↓
    ├─→ ConsoleHelper.cs
    └─→ SlideManager.cs
            ↓
            ├─→ ConsoleHelper.cs
            ├─→ SlideRenderer.cs
            │       ↓
            │       └─→ ConsoleHelper.cs
            ├─→ SlideData.cs
            └─→ Constants.cs
```

**Notera**: 
- Inga cirkulära dependencies ✅
- Tydlig hierarki ✅
- Enkel att förstå ✅

---

## Hur klasserna samarbetar

### Exempel: Visa en slide med header och animerad text

```csharp
// 1. Presentation startar flödet
public void Run()
{
    _slideManager.ShowLandingPage();
}

// 2. SlideManager visar sliden
public void ShowLandingPage()
{
    _renderer.DrawSlideHeader("1", "TITEL", Color.Blue);
    _consoleHelper.AnimateTextCentered("Text", Color.Yellow, 30);
    _consoleHelper.WaitForNext();
}

// 3. SlideRenderer ritar header
public void DrawSlideHeader(string number, string title, Color color)
{
    var rule = new Rule($"SLIDE {number} — {title}");
    AnsiConsole.Write(rule);
}

// 4. ConsoleHelper animerar text
public void AnimateTextCentered(string text, Color color, int delay)
{
    foreach (char c in text)
    {
        AnsiConsole.Markup(c.ToString());
        Thread.Sleep(delay);
    }
}
```

---

## Kodstatistik

| Fil | Rader | Ansvar | Komplexitet |
|-----|-------|--------|-------------|
| Program.cs | 4 | Entry point | Minimal |
| Presentation.cs | ~70 | Orkestrering | Låg |
| SlideManager.cs | ~200 | Slide-logik | Medel |
| SlideRenderer.cs | ~150 | Rendering | Medel |
| ConsoleHelper.cs | ~140 | Console ops | Låg |
| SlideData.cs | ~150 | Data | Ingen |
| Constants.cs | ~30 | Konfiguration | Ingen |
| **TOTALT** | **~744** | - | - |

**Före**: 1 fil med 822 rader
**Efter**: 7 filer med totalt ~744 rader

---

## Var ska jag börja läsa?

Rekommenderad läsordning för att förstå koden:

1. **Program.cs** (4 rader)
   - Start här för att se entry point

2. **Constants.cs** (30 rader)
   - Se vilka konfigurationsvärden som finns

3. **SlideData.cs** (150 rader)
   - Se vilken data som används (hoppa över ASCII-art)

4. **ConsoleHelper.cs** (140 rader)
   - Förstå grundläggande console-operationer

5. **SlideRenderer.cs** (150 rader)
   - Se hur UI-element renderas

6. **Presentation.cs** (70 rader)
   - Se programmets huvudflöde

7. **SlideManager.cs** (200 rader)
   - Djupdyk i hur slides fungerar

---

## Tips för vidareutveckling

### Om du vill lägga till en ny slide:
1. Lägg till data i `SlideData.cs` (om behövs)
2. Skapa metod i `SlideManager.cs`
3. Anropa metoden från `Presentation.cs`

### Om du vill ändra animations-hastighet:
1. Ändra i `Constants.cs` → `Timing`
2. Allt annat uppdateras automatiskt!

### Om du vill lägga till ny rendering-funktion:
1. Lägg till metod i `SlideRenderer.cs`
2. Använd från `SlideManager.cs`

### Om du vill ändra team-medlemmar:
1. Ändra i `SlideData.cs` → `TeamMembers`
2. Allt annat uppdateras automatiskt!

---

## Felhantering

Varje klass som interagerar med console har try/catch:

```
ConsoleHelper.cs       → try/catch i alla metoder
SlideRenderer.cs       → try/catch i rendering-metoder
SlideManager.cs        → try/catch i slide-metoder
Presentation.cs        → övergripande try/catch i Run()
```

Detta gör att om något går fel fortsätter programmet ändå (graceful degradation).
