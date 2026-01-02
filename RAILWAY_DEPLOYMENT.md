# Railway Deployment Anleitung 🚂

## Schritt-für-Schritt Anleitung

### 1. Änderungen committen und pushen

```bash
git add .
git commit -m "Railway deployment config"
git push
```

### 2. Railway Projekt erstellen

1. Gehe zu [railway.app](https://railway.app)
2. Klicke auf **"New Project"**
3. Wähle **"Deploy from GitHub repo"**
4. Wähle dein Repository **"civ5hype"**
5. Railway erkennt jetzt automatisch .NET dank der Config-Dateien

### 3. Warten auf Deployment

Railway wird automatisch:
- ✅ .NET 10 SDK installieren
- ✅ Das Projekt bauen (`dotnet publish`)
- ✅ Die Datenbank mit deployen (civ5hype.db)
- ✅ Die App starten

Das dauert ca. 2-3 Minuten.

### 4. URL aufrufen

Nach erfolgreichem Deployment:
1. Railway zeigt dir eine URL (z.B. `https://civ5hype-production.up.railway.app`)
2. Klicke darauf oder kopiere sie
3. Öffne die URL im Browser

### 5. Ersten Admin erstellen

Da die Datenbank mit deployed wird, sind deine lokalen Daten bereits da!

Falls nicht:
1. Registriere dich auf der deployed Seite
2. Railway bietet eine **"Database"** Ansicht
3. Oder nutze Railway CLI:

```bash
# Railway CLI installieren
npm install -g @railway/cli

# Einloggen
railway login

# Mit Projekt verbinden
railway link

# Shell öffnen
railway run bash

# Datenbank bearbeiten
sqlite3 civ5hype/civ5hype.db
UPDATE AspNetUsers SET Role = 2 WHERE Email = 'yourmail';
.quit
```

## 🔄 Updates deployen

Jedes Mal wenn du pushst, deployed Railway automatisch:

```bash
# Lokal Änderungen machen
cd civ5hype
dotnet run
# ... Spiele erfassen ...

# Committen und pushen
git add .
git commit -m "Neue Spiele hinzugefügt"
git push

# Railway deployed automatisch! 🚀
```

## ⚙️ Railway Einstellungen

### Umgebungsvariablen (optional)

Im Railway Dashboard → Settings → Variables:

```
ASPNETCORE_ENVIRONMENT=Production
```

### Custom Domain (optional)

Im Railway Dashboard → Settings → Domains:
- Füge deine eigene Domain hinzu (z.B. `civ5.deinedomain.de`)

## 🐛 Troubleshooting

### Build schlägt fehl

**Problem**: "dotnet: command not found"
**Lösung**: Die `nixpacks.toml` sollte .NET 10 installieren. Prüfe ob die Datei committed wurde.

### App startet nicht

**Problem**: "Address already in use"
**Lösung**: Die `Program.cs` nutzt jetzt automatisch den PORT von Railway.

### Datenbank leer

**Problem**: Keine Spiele/Spieler sichtbar
**Lösung**: Die `.gitignore` wurde angepasst - die DB wird jetzt mit gepusht. Mache einen neuen Commit:

```bash
git add civ5hype/civ5hype.db
git commit -m "Add database"
git push
```

### Logs ansehen

Im Railway Dashboard → Deployments → Klick auf den Build → Logs

## 📊 Kosten

Railway Free Tier:
- ✅ 500 Stunden pro Monat (ca. 20 Tage)
- ✅ Perfekt für kleine Gruppen
- ✅ Automatische Backups

Wenn du mehr brauchst:
- $5/Monat für Hobby Plan (unbegrenzt)

## 🎯 Zusammenfassung

1. ✅ Config-Dateien erstellt (railway.toml, nixpacks.toml, Procfile)
2. ✅ Program.cs angepasst für Railway PORT
3. ✅ Push zu GitHub
4. ✅ Railway verbinden
5. ✅ Automatisches Deployment
6. ✅ Fertig! 🎉

Die App ist jetzt online und alle deine Freunde können darauf zugreifen!

