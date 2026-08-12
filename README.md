# Community Web API – Inlämningsuppgift 1

## Översikt

Detta projekt är ett **ASP.NET Core Web API** som fungerar som backend för ett community
där användare kan registrera sig, logga in och skapa blogginlägg som andra användare
kan läsa och kommentera.

Applikationen är byggd enligt objektorienterade principer och följer de riktlinjer
och arkitekturmönster som behandlats under kursen *Programmering med C# och .NET – fortsättning*.

All data lagras i en relationsdatabas och nås via ett REST-baserat API.

---

## Syfte med uppgiften

Syftet med uppgiften är att visa att jag kan:

- Skapa ett fungerande **ASP.NET Core Web API**
- Kommunicera med en databas via **Entity Framework Core**
- Arbeta objektorienterat och lagerindelat
- Implementera autentisering och behörighet
- Dokumentera och testa ett API via **Swagger** och **Postman**

---

## Använd teknik och hur den används

### ASP.NET Core Web API
Används för att skapa REST-endpoints för:
- Användare
- Inloggning
- Blogginlägg
- Kategorier
- Kommentarer

Controllers hanterar endast HTTP-logik och anropar services för affärslogik.

---

### Entity Framework Core
Används som ORM för att:
- Mappa entiteter till databastabeller
- Skapa databasen via migrations
- Utföra CRUD-operationer

Varje entitet motsvarar en tabell i databasen.

---

### SQL Server
Används som relationsdatabas för lagring av:
- Användare
- Blogginlägg
- Kommentarer
- Kategorier

---

### Repository Pattern
Repositories ansvarar för databasanrop och isolerar
databaslogik från övrig kod.

Exempel:
- UserRepository
- BlogPostRepository
- CommentRepository

---

### Service Layer
Service-lagret innehåller affärslogik såsom:
- Behörighetskontroller
- Regler (t.ex. att användare inte får kommentera sina egna inlägg)
- Logik för skapa, uppdatera och ta bort data

Controllers anropar alltid services – aldrig repositories direkt.

---

### Autentisering
Vid inloggning returneras antingen:
- ett **JWT-token**
  eller
- ett **UserId** som används i efterföljande anrop

Detta används för att identifiera inloggad användare
och säkerställa korrekt behörighet.

---

### Swagger
Swagger används för att:
- Dokumentera alla API-endpoints
- Testa API:et direkt i webbläsaren
- Visa request- och response-modeller

---

### Postman
Alla API-anrop kan testas via Postman, inklusive:
- Registrering
- Inloggning
- Skapande av blogginlägg
- Kommentarer
- Sökning
- Uppdatering och borttagning

---

## Funktionalitet

### Användare
- Skapa användarkonto (username, password, email)
- Logga in
- Uppdatera användarkonto
- Ta bort användarkonto

---

### Blogginlägg
- Skapa blogginlägg (kräver inloggning)
- Läsa alla blogginlägg (öppet)
- Uppdatera blogginlägg (endast skaparen)
- Ta bort blogginlägg (endast skaparen)

Varje blogginlägg innehåller:
- Titel
- Text
- Kategori
- Koppling till användare

---

### Kategorier
- Kategorier lagras i en egen tabell
- Varje blogginlägg tillhör en kategori
- Sökning kan ske baserat på kategori

---

### Kommentarer
- Inloggade användare kan kommentera andras inlägg
- Användare kan inte kommentera sina egna inlägg

---

### Sökfunktion
- Sökning på titel (delmatchning)
- Sökning på kategori

---

## Arkitektur

Projektet är uppbyggt enligt följande lager:

- Controllers – HTTP och API-logik
- Services – affärslogik
- Repositories – databasåtkomst
- Entities – databastabeller
- DTOs – in- och utdata

Detta ger en tydlig ansvarsfördelning och lättunderhållen kod.

---

## Köra projektet

1. Öppna lösningen i Visual Studio
2. Kontrollera connection string i `appsettings.json`
3. Kör Entity Framework migrations
4. Starta applikationen
5. Testa API:et via Swagger eller Postman

---

## Bedömning

Uppgiften bedöms med **IG** eller **G** och är obligatorisk
för att bli godkänd på kursen.

För att nå **VG på kursen** krävs godkänt resultat på denna uppgift
samt uppgift 2.
