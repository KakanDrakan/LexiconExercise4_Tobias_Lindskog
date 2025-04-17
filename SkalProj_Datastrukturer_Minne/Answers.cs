/*

1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion

Stacken och heapen lagrar olika typer av data. Stacken håller bland annat value types, metodanrop och referenser till heapen. Den
slänger bort datan efter en metod är klar.

Heapen kan lagra all typ av data, däribland reference types, som inte slängs bort automatiskt utan görs via GC. Minneshanteringen är 
därför långsammare, men data kan effektivt behållas länge för att användas senare.

2.Vad är Value Types respektive Reference Types och vad skiljer dem åt?

Value types ärver från System.ValueType och reference types ärver från System.Object. Value types kan ligga både på stacken och
heapen. Reference types kan bara ligga på heapen. Value types håller riktiga värden medan reference types bara refererar till annan data

3.Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?  

I första exemplet hanteras endast value types. x initialiseras och sätts till 3, sedan initisaliseras y och sätts till samma värde
som x. Sen sätts y till 4. När x då returneras håller den sitt värde 3, eftersom det inte ändrades.

I andra exemplet används istället reference types. En referens x sätts till ett objekt av typen MyInt och dess value sätts till 3. Sen 
initialiseras referensen y till ett objekt av samma typ, men syntaxen "y = x" gör så att y nu refereras till samma objekt som x. När då
y.MyValue sätts till 4 sätts även x.MyValue till 4 då de refererar till samma objekt.


Resterande frågor besvaras över relevant metod i Program

*/