# Deployment-Anleitung 🚀

## Wichtig: Datenbank wird MIT deployed!

Diese Anwendung ist so konfiguriert, dass die SQLite-Datenbank **MIT ins Git-Repo** kommt.
Das bedeutet: Alle pushen und pullen die gleiche Datenbank.

## ⚠️ Wichtige Regeln:

### Nur eine Person macht Änderungen!
- **NUR DU** solltest Änderungen machen
- Andere Benutzer sollten nur **lesen** (Statistiken ansehen)
- Vor dem Bearbeiten: **IMMER erst `git pull`**
- Nach dem Bearbeiten: **SOFORT `git push`**

### Workflow für Änderungen:

```bash
# 1. Neueste Version holen
git pull

# 2. Anwendung starten und Änderungen machen
cd civ5hype
dotnet run

# 3. Spiele/Spieler erfassen, dann App stoppen (Ctrl+C)

# 4. Änderungen committen
cd ..
git add civ5hype/civ5hype.db
git add civ5hype/wwwroot/uploads/
git commit -m "Neue Spiele hinzugefügt"
git push
```

## 🌐 Hosting-Optionen

### Option 1: GitHub Pages mit Static Web Apps

**Problem**: GitHub Pages unterstützt nur statische Seiten, Blazor Server braucht einen Server.

**Lösung**: Nutze einen der folgenden Dienste.

### Option 2: Railway.app (Empfohlen) ⭐

**Vorteile:**
- Kostenloser Starter-Plan
- Automatisches Deployment via GitHub
- Einfache Einrichtung

**Setup:**
1. Gehe zu [railway.app](https://railway.app)
2. "New Project" → "Deploy from GitHub repo"
3. Wähle dein `civ5hype` Repository
4. Railway erkennt automatisch .NET
5. Fertig! Die DB wird automatisch mit deployed

**Wichtig bei Railway:**
- Die DB wird bei jedem Deployment überschrieben
- Immer erst lokal ändern, dann pushen
- Railway zieht automatisch die neueste DB aus Git

### Option 3: Azure App Service (Free Tier)

**Setup:**
1. Erstelle einen [Azure Account](https://azure.microsoft.com/free/)
2. Erstelle eine "Web App" (Free Tier F1)
3. Verbinde mit GitHub
4. Wähle das Repository
5. Azure deployed automatisch bei jedem Push

### Option 4: Fly.io

**Setup:**
```bash
# 1. Fly CLI installieren
winget install Fly.io.flyctl

# 2. Login
fly auth login

# 3. App erstellen
cd civ5hype
fly launch

# 4. Deployen
fly deploy
```

## 📦 Was wird deployed:

- ✅ Alle Code-Dateien
- ✅ **civ5hype.db** (Datenbank mit allen Spielen)
- ✅ **wwwroot/uploads/** (Alle Screenshots)
- ✅ Migrations
- ❌ bin/, obj/ (Build-Artefakte)
- ❌ appsettings.Development.json

## 🔄 Typischer Workflow:

### Als Admin (du):

```bash
# 1. Neueste Version holen
git pull

# 2. App starten
cd civ5hype
dotnet run

# 3. Im Browser: Spiele erfassen
# Öffne https://localhost:5001

# 4. App stoppen (Ctrl+C im Terminal)

# 5. Änderungen hochladen
cd ..
git add .
git commit -m "Spiel vom 02.01.2026"
git push
```

### Als Freund (nur lesen):

```bash
# Neueste Version holen
git pull

# App starten
cd civ5hype
dotnet run

# Im Browser ansehen: https://localhost:5001
```

## 🛡️ Backup-Strategie

### Manuelles Backup (optional):

```bash
# Backup-Ordner erstellen (einmalig)
mkdir backups

# Backup erstellen vor wichtigen Änderungen
copy civ5hype\civ5hype.db backups\civ5hype-backup.db
```

**Tipp**: Git selbst ist dein Backup! Jeder Commit speichert den Stand der DB.

## ⚠️ Konflikt-Vermeidung

### Wenn zwei Personen gleichzeitig ändern:

**Git wird einen Konflikt melden:**
```
CONFLICT (content): Merge conflict in civ5hype/civ5hype.db
```

**Lösung:**
```bash
# Option 1: Deine Version behalten
git checkout --ours civ5hype/civ5hype.db
git add civ5hype/civ5hype.db
git commit -m "Konflikt gelöst - meine Version"

# Option 2: Andere Version behalten
git checkout --theirs civ5hype/civ5hype.db
git add civ5hype/civ5hype.db
git commit -m "Konflikt gelöst - andere Version"
```

**Besser: Konflikte vermeiden!**
- Kommuniziere mit deinen Freunden
- Nur eine Person macht Änderungen
- Andere nur im Read-Only Modus

## 🎯 Zusammenfassung

### Vorteile dieser Methode:
- ✅ Alle haben immer die gleichen Daten
- ✅ Einfaches Deployment
- ✅ Keine separate Datenbank-Verwaltung nötig
- ✅ Screenshots werden auch synchronisiert

### Nachteile:
- ⚠️ Nur eine Person sollte Änderungen machen
- ⚠️ Bei vielen Änderungen: viele Git-Commits
- ⚠️ DB-Datei wird größer über Zeit

### Perfekt für:
- 👥 Kleine Gruppen (2-10 Personen)
- 🎮 Gelegentliche Spiele (nicht täglich)
- 👑 Ein Admin, der alles verwaltet
- 📊 Andere wollen nur Statistiken sehen

---

Viel Erfolg beim Hosten! 🚀

