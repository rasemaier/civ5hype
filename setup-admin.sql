-- Skript zum Erstellen eines Admin-Benutzers
-- Ersetze 'deine-email@example.com' mit der E-Mail des Benutzers, der Admin werden soll

-- Zeige alle Benutzer an
SELECT Id, UserName, Email, Role FROM AspNetUsers;

-- Setze einen Benutzer als Admin (Role = 2)
-- Ersetze 'deine-email@example.com' mit der tatsächlichen E-Mail
UPDATE AspNetUsers 
SET Role = 2 
WHERE Email = 'deine-email@example.com';

-- Überprüfe die Änderung
SELECT Id, UserName, Email, Role FROM AspNetUsers WHERE Email = 'deine-email@example.com';

-- Rollen-Erklärung:
-- 0 = User (Standard)
-- 1 = Creator (Kann Spiele erstellen)
-- 2 = Admin (Volle Rechte)

