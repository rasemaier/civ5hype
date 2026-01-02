# Schnellstart-Anleitung 🚀

## Erste Schritte

### 1. Anwendung starten

```bash
cd civ5hype
dotnet run
```

Die Anwendung läuft dann auf: `https://localhost:5001`

### 2. Ersten Benutzer registrieren

1. Öffne `https://localhost:5001` im Browser
2. Klicke auf "Register"
3. Erstelle einen Account mit:
   - E-Mail
   - Passwort (mindestens 6 Zeichen)

### 3. Admin-Rechte vergeben

Nach der Registrierung musst du deinen Account zum Admin machen:

**Option A: Mit DB Browser for SQLite**
1. Lade [DB Browser for SQLite](https://sqlitebrowser.org/) herunter
2. Öffne die Datei `civ5hype/civ5hype.db`
3. Gehe zum Tab "Browse Data"
4. Wähle die Tabelle "AspNetUsers"
5. Finde deinen Benutzer und ändere die Spalte "Role" von `0` auf `2`
6. Klicke auf "Write Changes"

**Option B: Mit SQL-Befehl**
1. Öffne die Datei `civ5hype.db` mit einem SQLite-Tool
2. Führe aus:
```sql
UPDATE AspNetUsers SET Role = 2 WHERE Email = 'deine-email@example.com';
```

**Option C: Mit PowerShell (Windows)**
```powershell
cd civ5hype
sqlite3 civ5hype.db "UPDATE AspNetUsers SET Role = 2 WHERE Email = 'deine-email@example.com';"
```

### 4. Spieler anlegen

1. Melde dich an
2. Gehe zu "Spieler"
3. Klicke auf "Neuer Spieler"
4. Füge alle Mitspieler hinzu (z.B. "Max", "Anna", "Tom", etc.)

### 5. Erstes Spiel erfassen

1. Gehe zu "Spiele"
2. Klicke auf "Neues Spiel"
3. Wähle das Datum
4. Füge Spieler hinzu (Rang 1 = Gewinner)
5. Markiere den Gewinner mit dem Checkbox
6. Optional: Screenshot hochladen und Kommentar hinzufügen
7. Klicke auf "Speichern"

### 6. Statistiken ansehen

Gehe zu "Statistiken" um:
- Rangliste zu sehen
- Siegquoten anzusehen
- Platzierungsverteilungen zu analysieren

## Tipps

### Weitere Benutzer hinzufügen

1. Andere Spieler können sich selbst registrieren
2. Als Admin kannst du unter "Benutzerverwaltung" Rollen zuweisen:
   - **User**: Kann nur Daten ansehen
   - **Ersteller**: Kann Spiele erstellen und bearbeiten
   - **Admin**: Kann alles (inkl. Benutzerverwaltung)

### Screenshots hochladen

- Erlaubte Formate: JPG, PNG, GIF, WEBP
- Maximale Größe: 10 MB
- Screenshots werden in `wwwroot/uploads/screenshots/` gespeichert

### Datenbank-Backup

Sichere regelmäßig die Datei `civ5hype/civ5hype.db`:

```bash
# Windows
copy civ5hype\civ5hype.db civ5hype\backup\civ5hype-backup-2026-01-02.db

# Linux/Mac
cp civ5hype/civ5hype.db civ5hype/backup/civ5hype-backup-2026-01-02.db
```

### Entwicklungsmodus

Für Entwicklung mit Hot Reload:

```bash
cd civ5hype
dotnet watch run
```

## Problemlösung

### Port bereits belegt

Wenn Port 5001 bereits verwendet wird, ändere in `Properties/launchSettings.json`:

```json
"applicationUrl": "https://localhost:5002;http://localhost:5003"
```

### Datenbank zurücksetzen

Um von vorne zu beginnen:

```bash
cd civ5hype
rm civ5hype.db civ5hype.db-shm civ5hype.db-wal
dotnet ef database update
```

### Migration-Fehler

Falls Migrations-Probleme auftreten:

```bash
cd civ5hype
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Nächste Schritte

- Lies die vollständige [README.md](README.md) für Deployment-Optionen
- Passe das Design in `wwwroot/app.css` an
- Erweitere die Funktionalität nach Bedarf

Viel Spaß! 🎮

