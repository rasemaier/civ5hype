# Civ 5 Hype 🎮

Eine Web-Anwendung zum Tracken von Civilization 5 Spielen mit Freunden. Verfolge Siege, Platzierungen und Statistiken deiner Civ 5 Runde!

## Features

- 🎯 **Spielverwaltung**: Erfasse Spiele mit bis zu 8 Spielern
- 🏛️ **Nationen-Auswahl**: Wähle für jeden Spieler die Civilization aus (alle 43 Nationen)
- 📊 **Statistiken**: Detaillierte Ranglisten und Spielerstatistiken
- 🏆 **Hall of Fame**: Top 5 Rangliste auf der Startseite (auch ohne Login sichtbar)
- 👥 **Spielerverwaltung**: Verwalte deine Spieler-Datenbank
- 📸 **Screenshots**: Lade Screenshots deiner Spiele hoch
- 💬 **Kommentare**: Füge Notizen zu jedem Spiel hinzu
- 🔐 **Authentifizierung**: Sicheres Login-System mit Rollen
- 👑 **Rollen-System**: User, Ersteller und Admin-Rollen

## Technologie

- **Framework**: ASP.NET Core Blazor Server (.NET 10)
- **Datenbank**: SQLite
- **UI**: Bootstrap 5
- **Authentifizierung**: ASP.NET Core Identity

## Installation & Setup

### Voraussetzungen

- .NET 10 SDK
- Git

### Lokale Entwicklung

1. Repository klonen:
```bash
git clone https://github.com/DEIN-USERNAME/civ5hype.git
cd civ5hype
```

2. Datenbank erstellen:
```bash
cd civ5hype
dotnet ef database update
```

3. Anwendung starten:
```bash
dotnet run
```

4. Browser öffnen: `https://localhost:5001`

## Deployment auf GitHub Pages

Diese Anwendung ist für Blazor Server konzipiert und benötigt einen Server zum Hosten. GitHub Pages unterstützt nur statische Websites. Für kostenloses Hosting empfehlen wir:

### Alternative Hosting-Optionen (kostenlos):

1. **Azure App Service** (Free Tier)
   - Kostenloser Plan verfügbar
   - Direkte Integration mit GitHub
   - SQLite wird unterstützt

2. **Railway.app**
   - Kostenloser Starter-Plan
   - Einfaches Deployment via GitHub
   - Automatische Builds

3. **Fly.io**
   - Kostenloser Tier verfügbar
   - Unterstützt .NET Anwendungen
   - Einfache CLI-Deployment

### Deployment-Schritte (Beispiel: Railway)

1. Account auf [Railway.app](https://railway.app) erstellen
2. "New Project" → "Deploy from GitHub repo"
3. Repository auswählen
4. Railway erkennt automatisch .NET und deployed die App
5. Datenbank wird automatisch erstellt

## Verwendung

### Erste Schritte

1. **Registrieren**: Erstelle einen Account
2. **Spieler anlegen**: Gehe zu "Spieler" und füge alle Mitspieler hinzu
3. **Spiel erfassen**: Klicke auf "Neues Spiel" und trage die Ergebnisse ein
4. **Statistiken ansehen**: Sieh dir die Rangliste und Statistiken an

### Rollen

- **User**: Kann Spiele und Statistiken ansehen
- **Ersteller**: Kann zusätzlich Spiele erstellen und bearbeiten
- **Admin**: Kann zusätzlich Benutzer verwalten und Rollen zuweisen

### Admin-Account erstellen

Nach der ersten Registrierung musst du manuell einen Admin erstellen:

1. Öffne die SQLite-Datenbank (`civ5hype.db`)
2. Führe folgendes SQL aus:
```sql
UPDATE AspNetUsers SET Role = 2 WHERE Email = 'deine-email@example.com';
```

Oder verwende ein SQLite-Tool wie [DB Browser for SQLite](https://sqlitebrowser.org/).

## Projektstruktur

```
civ5hype/
├── Components/
│   ├── Account/          # Authentifizierungs-Komponenten
│   ├── Layout/           # Layout-Komponenten
│   └── Pages/            # Razor-Seiten
│       ├── Games.razor   # Spielverwaltung
│       ├── Players.razor # Spielerverwaltung
│       ├── Statistics.razor # Statistiken
│       └── UserManagement.razor # Admin-Panel
├── Data/
│   ├── Models/           # Datenmodelle
│   ├── Enums/            # Enumerationen
│   └── Migrations/       # EF Core Migrations
├── Services/             # Business Logic Services
└── wwwroot/
    └── uploads/          # Hochgeladene Screenshots
```

## Mitwirken

Contributions sind willkommen! Bitte erstelle einen Pull Request oder öffne ein Issue.

## Lizenz

MIT License - siehe LICENSE Datei für Details.

## Support

Bei Fragen oder Problemen erstelle bitte ein Issue auf GitHub.

---

Viel Spaß beim Tracken deiner Civ 5 Spiele! 🎮🏆

