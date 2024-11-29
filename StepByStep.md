# Gjennomgang av hvordan jeg løste dette

Jeg valgte å ikke bruke noe Copilot eller GPT for denne oppgaven, for at dere skal få testet min kunnskap og ikke GPT. 🫡 
I et vanlig oppdrag ville jeg brukt det på deler av oppgaven for å spare tid. 👌 Men jeg gjorde noen Google søk for å søke opp noe syntax for LINQ, JSON reading og tuples.     

1. Først lagde jeg en konsoll-applikasjon i dotnet. `dotnet new console -n CallDetailRecords`
2. Dernest lagde jeg en `cdrs.json` fil, og kopierte inn testdata fra oppgavebeskrivelsen. 
3. Begynte på en Utility-klasse for å gjøre hvert av stegene hver for seg, slik at de kan testes med enhetstester.
4. Måtte da lage en type for hver rad av Input-dataen, som jeg kaller `CallDetailRecord`.
5. Begynte å lure på om det var best å lage en egen type for å håndtere telefonnr, siden de er på et spesifikt format, i stedet for å kun ha strings. Men har ikke fått info om forskjellige formater, feks kan det komme data med prefiks +47, 0047, hva med utenlanske nummere som har forskjellig antall siffer. Så da tenker jeg at det holder med strings i denne lille kodeoppgaven.  
6. Lager først "tomme" utility-funksjoner for alle tre kravene, med noen kommentarer på hvordan jeg kan løse dem. 
7. Lager så en test-prosjekt, som har tomme test-caser for alle tre kravene. Og lager en test-array fra dataen.
8. Og så lager jeg en konstruktør i test-klassen som lager testdataen som en riktig. Her hardkoder jeg inn for at test-filen skal være uten avhengigheter.  
9. Jeg lager tre tester for `TotalDurationToCaller`, implementerer metoden og sjekker at den returnerer riktig.   
10. Jeg gjør dette for `MostActiveCallersByNumberOfCalls` og `TotalDistinctPhoneNumbers` også. 
11. Til slutt leser jeg inn datafilen i `Program.cs` og skriver `Console.WriteLines` slik at output blir det som er ønsket.   

Ta-Da 🎉 
