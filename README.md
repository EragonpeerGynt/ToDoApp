# Requirements

- [x] Ustvari novo .NET Core spletno aplikacijo z imenom "ToDoApp".
- [x] Definiraj model "Task" z naslednjimi lastnostmi:
    - [x] Id (celo število)
    - [x] Naslov (besedilo)
    - [x] Opis (besedilo)
    - [x] DatumUstvarjanja (datum in čas)
    - [x] Opravljeno (logična vrednost)
- [x] Ustvari podatkovno bazo v SQL Serverju ali drugem primernem sistemu za
upravljanje podatkovnih baz.
- [x] Izvedi migracije, da ustvariš ustrezno tabelo za hranjenje nalog.
- [x] Implementiraj CRUD (Create, Read, Update, Delete) operacije za upravljanje nalog v razredu "TaskController".
- [x] Vse operacije za dostop do podatkov naj uporabljajo SQL poizvedbe za delo s podatkovno bazo.
- [x] Za testiranje delovanja CRUD operacij uporabi swagger ali postman aplikacijo, za klicanje funkcij (BE API-jev). V primeru, da boš imel/a pripravljene klice BE API-jev v nekem drugem orodju, prosim, da priložiš template, kako klicati API-je.
- [x] Zagotovi ustrezno preverjanje napak in obvladovanje izjemnih stanj v aplikaciji.
- [x] Implementiraj tudi unit-teste za vse CRUD operacije.

# Dodatna navodila:

V mapi [PostmanExamples](./PostmanExamples/) se nahaja JSON datoteka narejena preko funkcije izvoza v postmanu (V2.1), kjer definirani primeri klicev.  
V mapi [SqlScripts](./SqlScripts/) se nahaja SQL skripta namenjana ponovnemu ustvarjanju baze, ki je bila narejena za projekt.  
V mapi [ToDoAppTest](./ToDoAppTest/) se nahajajo avtomatski testi delovanja aplikacije narejeni v MStest framework-u.  
V mapi [ToDoApp](./ToDoApp/) se nahaja sama ASP.net aplikacija ki je bila narejena v okviru te naloge.  
Swagger dokumentacija je avtomatsko generirana in se po zagonu strežnika/aplikacije nahaja na "default route" (\/) spletne aplikacije.

# Uporabljene tehnologije

- SSMS 19
- MS SQL server 2022
- dotnet 7
- Visual Studio 2022