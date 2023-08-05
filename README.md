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
- [ ] Vse operacije za dostop do podatkov naj uporabljajo SQL poizvedbe za delo s podatkovno bazo.
- [ ] Za testiranje delovanja CRUD operacij uporabi swagger ali postman aplikacijo, za klicanje funkcij (BE API-jev). V primeru, da boš imel/a pripravljene klice BE API-jev v nekem drugem orodju, prosim, da priložiš template, kako klicati API-je.
- [ ] Zagotovi ustrezno preverjanje napak in obvladovanje izjemnih stanj v aplikaciji.
- [ ] Implementiraj tudi unit-teste za vse CRUD operacije.