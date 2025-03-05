# Élet Játéka (Conway's Game of Life)  

Ez a projekt John Horton Conway híres **Élet Játéka** (*The Game of Life*) szimulációjának egy C# nyelven írt implementációja. A játék egy sejtautomata, amely egy egyszerű szabályrendszer alapján modellezi a sejtek születését, túlélését és pusztulását egy négyzetrácsos térben.  

## Játékszabályok  
- Minden cella **élő** vagy **halott** állapotban lehet.  
- Egy cella **túléli**, ha **2 vagy 3 élő szomszédja** van.  
- Egy cella **elpusztul**, ha kevesebb mint **2** (*elszigetelődés*) vagy több mint **3** (*túlnépesedés*) élő szomszédja van.  
- Egy **új sejt születik** egy üres cellában, ha pontosan **3 élő szomszédja** van.  
- A változások **minden kör végén egyszerre frissülnek**.  
