# 🎬 Fitness Progress Tracker - Presentation

En animerad, färgglad konsolpresentation byggd med Spectre.Console för ert projekt!

## 🚀 Hur man kör presentationen

### Alternativ 1: Lägg till i ert befintliga projekt
1. Kopiera `Program.cs` till en ny mapp i ert projekt (t.ex. `Presentation/`)
2. Skapa en ny `.csproj`-fil eller kör som separat projekt
3. Kör med `dotnet run`

### Alternativ 2: Kör som separat projekt
1. Skapa en ny mapp: `FitnessPresentation`
2. Lägg in `Program.cs` och `FitnessPresentation.csproj`
3. Kör:
```bash
cd FitnessPresentation
dotnet restore
dotnet run
```

## 📋 Slides som ingår

| # | Slide | Innehåll |
|---|-------|----------|
| 0 | Landing Page | ASCII-art logo, teammedlemmar, projektnamn |
| 1 | Kodstruktur | Animerad trädvy över projektet |
| 2 | Planeringsfasen | Vision och CRUD-operationer |
| 3 | PT Use Cases | Alla PT-funktioner |
| 4 | Klient Use Cases | Alla klientfunktioner |
| 5 | Datahantering | Interface, generics, JSON |
| 6 | Kommunikation | Discord, Teams, GitHub |
| 7 | Kaos & Problem | Merge-konflikter, API-nyckel läcka etc |
| 8 | Vad vi lärt oss | Samarbete, Git, AI etc |
| 9 | Demo Time! | Countdown och final animation |

## 🎨 Features

- ✨ Animerad text som skrivs ut tecken för tecken
- 🌈 Rainbow/gradient färger
- 📊 Dynamiska tabeller och träd
- ⌨️ ENTER för att gå vidare
- 📐 Centrerad layout

## 💡 Tips för presentationen

1. **Maximera terminalen** innan du startar
2. Använd en **mörk bakgrund** för bästa effekt
3. Tryck ENTER i lugn takt mellan slides
4. Ha programmet redo att starta direkt efter sista sliden!

## 🛠️ Anpassa

Du kan enkelt ändra:
- Teammedlemmars namn i `_teamMembers`
- Färger på varje slide
- Animationshastighet (`Thread.Sleep` värden)
- Lägga till/ta bort slides

---

*Lycka till med presentationen! 💪*
