# SQL-Camp-Sleepaway

Camp Sleepaway
Bakgrund
Camp Sleepaway, ett mysigt amerikanskt sommarläger, har fått problem. Det går bra men det har
blivit svårt att hålla reda på vem som är/sover var, vem är ansvarig och att rätt personer får besöka
(dvs rätt anhöriga kommer på besök till lägerdeltagare).
Som det ser ut nu så känns det nästan som om folk försvinner och dyker upp utan kontroll. Föräldrar
har bland annat hotat att stämma lägret om de inte får träffa sina barn när de kommer på besök. Det
måste vara pappershanteringens fel. Därför har man kallat in AMS-konsulterna för att lösa problemet.
Uppgift
Skapa en EF Core applikation (Enkel menybaserad console app) för att hålla reda på Camp
Sleepaways gäster, släktningar och personal och byggnader.
Databas
Databasen skall innehålla minst följande tabeller och deras lämpliga relationer och constraints.
Namnge entiteter och tabeller med lämpliga plural och singularnamn
Databasen skall ge en ögonblicksbild av situationen men även kunna användas för historik
• Camper – Lägerdeltagare
• NextOfKin – Släktingar till Campers, endast dessa får besöka campers
• Councelor – Lägerledare
• Cabin – Stuga

Camper, NextOfKin och Councelors skall ha minst ett fält som inte finns i de övriga personrollerna.
Det måste finnas relationer/relationsentiteter med datum för start och stopp för när tex campern
bor i en stuga och när en councelor är ansvarig för en stuga. Datumintervallen kan variera både för
campers och för councelors.
Med start och stoppdatum avses när en camper eller councelor flyttar in/blir ansvarig för en stuga
och det datum när personen flyttar ut/ej längre är ansvarig för en stuga.
Krav på applikationen
En deltagare sover endast i en stuga men en stuga kan ha många deltagare, dock max 4 samt en
Councelor. En stuga får inte fyllas med campers om den inte har en councelor. Councelors får bytas
ut. Dessa begränsningar kan inte skapas i databasen utan måste kontrolleras med kod.
En Counselor ansvarar för en stuga och endast en.
Councelors, Cabins, Campers kan existera för sig själva utan varandra.
NextOfKin måste höra till en camper.
En camper får ha valfritt antal NextOfKin, dvs så många som man vill ange. Det är frivilligt för er som
programmerare att tillåta en NextOfKin som har flera campers eller ej.
Councelors får vara NextOfKin men då har de en egen rad i NextOfKin tabellen, personer kan ha flera
roller men då ligger de i respektive tabell som motsvarar rollen. Vi hanterar inte detta i denna
applikation.

 
