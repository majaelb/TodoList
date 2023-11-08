# Skapa en konsol-baserad att-g�ra-lista och skriv enhetstester f�r k�rnlogiken (dvs f�r hanteringen av uppgifter, inte f�r hur anv�ndaren interagerar med den).

## Applikationen ska till�ta anv�ndare att l�gga till, visa, markera som klar, och ta bort uppgifter. Skapa test-doubles f�r extern lagring (databas/filsystem) f�r att testa detta i isolation.

### Krav:

1. **TodoItem Class**: Implementera en TodoItem-klass f�r att representera en uppgift med egenskaper som Id, Title, Description och IsComplete.

2. **TodoList Class**: Skapa en TodoList-klass som hanterar en lista av TodoItem-objekt. Den h�r klassen b�r erbjuda metoder f�r att l�gga till, visa, markera uppgifter som klara och ta bort uppgifter. Du kan ocks� inkludera metoder f�r att filtrera uppgifter (t.ex. visa endast avklarade eller oavklarade uppgifter).

3. **Storage Interface**: Definiera en gr�nssnitt, t.ex. ITodoListStorage, som representerar datalagring f�r TodoList. Detta gr�nssnitt b�r inkludera metoder f�r att spara och ladda uppgifter.

4. **TodoList Tests**: Skriv enhetstester f�r TodoList-klassen med hj�lp av Moq. Mocka lagringsgr�nssnittet och se till att det anropas korrekt n�r uppgifter l�ggs till, tas bort eller markeras som klara.

5. **Konsolapplikation**: Bygg en konsolbaserad applikation som interagerar med TodoList-klassen. Applikationen b�r l�ta anv�ndare utf�ra f�ljande �tg�rder:
   - L�gg till en ny uppgift.
   - Visa uppgifter (alla uppgifter, avklarade uppgifter eller oavklarade uppgifter).
   - Markera en uppgift som klar.
   - Ta bort en uppgift.
   - Avsluta applikationen.

(OPTIONAL): Implementera en mocklagringsklass (MockTodoListStorage) som implementerar ITodoListStorage-gr�nssnittet men inte faktiskt lagrar data. Ist�llet lagrar den uppgifter i minnet. Anv�nd den h�r klassen i dina enhetstester ist�llet f�r Moq. Vilka �r f�rdelarna och nackdelarna med detta tillv�gag�ngss�tt?

## Struktur f�r uppgiften:

1. B�rja med att designa klassstrukturer och gr�nssnitt (TodoItem, TodoList, ITodoListStorage).

2. Skriv enhetstester f�r TodoList-klassen med hj�lp av Moq f�r att mocka lagringsgr�nssnittet.

3. Implementera k�rnfunktionaliteten i TodoList-klassen och se till att den interagerar korrekt med lagringsgr�nssnittet.

4. Skapa konsolapplikationen f�r anv�ndarinteraktion.

5. Testa konsolapplikationen manuellt f�r att s�kerst�lla att den fungerar som f�rv�ntat.

(OPTIONAL) Om du byggde en anpassad MockTodoListStorage, anv�nd denna mockade lagringsklass f�r datalagring under testning.
