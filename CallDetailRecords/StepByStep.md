# My Thought Process While Solving This.

0. Jeg valgte å ikke bruke noe Copilot eller GPT for denne oppgaven, for at dere skal få testet min kunnskap og ikke GPT. I et vanlig oppdrag ville jeg brukt det på deler av oppgaven for å spare tid.
1. Først lagde jeg en konsoll-applikasjon i dotnet. `dotnet new console -n CallDetailRecords`
2. Dernest kopierte inn `cdrs.json`-filen
3. Lagde en json-output som jeg kan sammenligne med programmatisk.
4. Begynte på en Utility-klasse for å gjøre hvert av stegene hver for seg, slik at de kan testes med enhetstester.
5. Måtte da lage en type for hver rad av Input-dataen, som jeg kaller `CallDetailRecord`.
6. Begynte å lure på om det var best å lage en egen type for å håntere telefonnr, siden de er på et spesifikt format, i stedet for å kun ha strings. Men har ikke fått "nok" info om forskjellige formater, feks kan det komme data med prefiks +47, 0047, hva med utenlanske nummere som har forskjellig antall siffer. Holder det til strings foreløpig.
7. Lager først "tomme" utility-funksjoner for alle tre kravene.
8. Lager så et test-prosjekt, som har tomme test-caser for alle tre kravene. 





Ønsket også at dette ikke bare skulle kjøre, men også være noe performant når det blir snakk om millarder av rader. Så jeg ville skrive kode for å generere et mye større datasett, med én million rader.
