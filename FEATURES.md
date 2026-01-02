# Features & Funktionen 🎯

## Übersicht

Civ5Hype ist eine vollständige Web-Anwendung zum Tracken von Civilization 5 Spielen mit folgenden Hauptfunktionen:

## 🎮 Spielverwaltung

### Spiele erfassen
- Bis zu 8 Spieler pro Spiel
- Datum und Uhrzeit erfassen
- Platzierungen (Rang 1-8) festlegen
- Gewinner markieren
- Kommentare hinzufügen
- Screenshots hochladen

### Spiele bearbeiten
- Nachträgliche Bearbeitung möglich
- Spieler hinzufügen/entfernen
- Platzierungen anpassen
- Screenshots austauschen

### Spiele löschen
- Spiele können gelöscht werden
- Alle zugehörigen Daten werden entfernt

## 📊 Statistiken

### Rangliste
- Sortiert nach Anzahl der Siege
- Zeigt Gesamtzahl der Spiele
- Siegquote in Prozent
- Durchschnittliche Platzierung
- Medaillen für Top 3 (🥇🥈🥉)

### Platzierungsverteilung
- Detaillierte Aufschlüsselung pro Spieler
- Zeigt wie oft jeder Rang erreicht wurde
- Prozentuale Verteilung
- Visuelle Darstellung mit Karten

### Letzte Spiele
- Chronologische Übersicht
- Zeigt Gewinner und Teilnehmer
- Schneller Überblick über aktuelle Aktivität

## 👥 Spielerverwaltung

### Spieler anlegen
- Name erfassen
- Optional mit User-Account verknüpfen
- Erstellungsdatum wird automatisch gespeichert

### Spieler bearbeiten
- Namen ändern
- User-Verknüpfung anpassen

### Spieler löschen
- Spieler entfernen (wenn keine Spiele vorhanden)
- Warnung bei vorhandenen Spielen

## 🔐 Authentifizierung & Rollen

### Rollen-System

#### User (Rolle 0)
- Spiele ansehen
- Statistiken ansehen
- Spieler ansehen
- Eigenes Profil verwalten

#### Ersteller (Rolle 1)
- Alle User-Rechte
- Spiele erstellen
- Spiele bearbeiten
- Spiele löschen
- Spieler erstellen/bearbeiten

#### Admin (Rolle 2)
- Alle Ersteller-Rechte
- Benutzerverwaltung
- Rollen zuweisen
- Alle administrativen Funktionen

### Identity-Features
- Registrierung
- Login/Logout
- Passwort ändern
- E-Mail ändern
- 2FA (Two-Factor Authentication)
- Passkeys-Unterstützung
- Account löschen
- Externe Logins (vorbereitet)

## 📸 Screenshot-Upload

### Unterstützte Formate
- JPG/JPEG
- PNG
- GIF
- WEBP

### Features
- Maximale Dateigröße: 10 MB
- Automatische Validierung
- Eindeutige Dateinamen (GUID)
- Vorschau im Dialog
- Löschen und Ersetzen möglich
- Sichere Speicherung

## 🎨 Benutzeroberfläche

### Design
- Modernes Bootstrap 5 Design
- Responsive Layout (Mobile-friendly)
- Dunkles Navbar-Design
- Karten-basierte Layouts
- Badges für Status-Anzeigen
- Icons für bessere UX

### Navigation
- Übersichtliches Menü
- Nur relevante Links für eingeloggte User
- Admin-Bereich separat
- Breadcrumb-Navigation

### Dialoge & Modals
- Modale Dialoge für Formulare
- Inline-Bearbeitung wo sinnvoll
- Bestätigungs-Dialoge
- Fehler-Anzeigen

## 🗄️ Datenbank

### SQLite
- Leichtgewichtig
- Keine Server-Installation nötig
- Perfekt für kleine bis mittlere Datenmengen
- Einfaches Backup (eine Datei)

### Datenmodell

#### ApplicationUser
- Identity-User erweitert
- Rolle (User/Ersteller/Admin)
- Verknüpfung zu Player
- Erstellte Spiele

#### Player
- Name
- Optional User-Verknüpfung
- Erstellungsdatum
- Spiel-Teilnahmen

#### Game
- Datum
- Kommentar
- Screenshot-Pfad
- Ersteller
- Erstellungsdatum
- Spieler-Teilnahmen

#### GamePlayer
- Verknüpfung Game ↔ Player
- Rang (1-8)
- Gewinner-Flag

## 🚀 Deployment

### Unterstützte Plattformen
- Azure App Service
- Railway.app
- Fly.io
- Heroku
- Jeder .NET-fähige Hosting-Anbieter

### Anforderungen
- .NET 10 Runtime
- SQLite-Unterstützung
- Dateisystem-Zugriff für Uploads

## 🔧 Technische Features

### Performance
- Entity Framework Core mit Eager Loading
- Indizes auf häufig abgefragten Feldern
- Effiziente LINQ-Queries
- Caching wo sinnvoll

### Sicherheit
- ASP.NET Core Identity
- HTTPS erzwungen
- Antiforgery-Tokens
- SQL-Injection-Schutz durch EF Core
- File-Upload-Validierung
- Rollen-basierte Autorisierung

### Code-Qualität
- Clean Architecture
- Service-Layer-Pattern
- Repository-Pattern (via EF Core)
- Dependency Injection
- Async/Await durchgängig

## 📱 Mobile Support

- Responsive Design
- Touch-freundliche Buttons
- Optimierte Tabellen für kleine Screens
- Mobile Navigation

## 🔮 Zukünftige Features (Ideen)

- [ ] Export zu Excel/CSV
- [ ] Erweiterte Filteroptionen
- [ ] Diagramme und Charts
- [ ] Spieler-Profile mit Avatar
- [ ] Achievements/Badges
- [ ] Kommentar-System für Spiele
- [ ] Like/Reaction-System
- [ ] Notifications
- [ ] Dark Mode
- [ ] Mehrsprachigkeit (i18n)
- [ ] API für externe Tools
- [ ] Discord-Integration
- [ ] Steam-Integration

## 🐛 Bekannte Einschränkungen

- Keine Echtzeit-Updates (Seite muss neu geladen werden)
- Screenshot-Upload nur einzeln
- Keine Batch-Operationen
- Keine erweiterte Suche
- Keine Archivierung alter Spiele

## 💡 Best Practices

### Datenerfassung
- Spiele direkt nach dem Match erfassen
- Screenshots für wichtige Spiele
- Aussagekräftige Kommentare
- Korrekte Platzierungen wichtig für Statistiken

### Administration
- Regelmäßige Backups der Datenbank
- Nur vertrauenswürdige User als Admin
- Ersteller-Rolle für aktive Spieler
- User-Rolle für Zuschauer

### Performance
- Alte Screenshots regelmäßig aufräumen
- Datenbank-Größe im Auge behalten
- Bei vielen Spielen (>1000) ggf. zu SQL Server wechseln

---

Viel Spaß mit Civ5Hype! 🎮🏆

