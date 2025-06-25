# Magazyn-Aplikacja
Projekt aplikacji dla magazynu z widokiem utworzonym w WPF i WebAPI zarządzającym bazą danych SqlServer przy pomocy Entity Framework Core

Projekt aplikacji dla magazynu, gdzie widok stworzony został poprzez WPF. Zaimplementowane zostało
poł ˛aczenie z WebAPI, utworzonym z pomoc ˛a EntityFramework i wykorzystaniem lokalnej bazy danych SQL
Server. API zarz ˛adza baz ˛a danych poprzez utworzone kontrollery, serwisy, requesty, DTO. Utworzyłem
odpowiednie end-pointy, do obsługi dodawania, edytowania, pobierania listy lub konkretnej warto´sci z bazy
danych. Nast˛epnie w aplikacji WPF utworzyłem widoki dla: menu głównego (dwa przyciski jeden dla lity
dokumentów przyj˛e´c, drugi dla listy kontrahentów), dokumentów przyj˛e´c (przycisk powrotu do menu, przycisk
do dodania i drugi do edycji dokumentu, filtrowanie listy dokumentów tekstem, lista dokumentów przyj˛ecia),
kontrahentów (przycisk powrotu do menu, przycisk do dodania i drugi do edycji kontrahenta, filtrowanie listy
kontrahentów tekstem, lista kontrahentów). Klikaj ˛ac dwukrotnie na pozycje z listy w przypadku kontrahentów
otwiera si˛e lista wszystkich dokumentów przyj˛e´c, które s ˛a przypisane dla tego kontrahenta z liczb ˛a przedmiotów
w nich zawartych. Natomiast w przypadku listy dokumentów przyj˛e´c otwiera si˛e widok dla konkretnego
dokumentu (przycisk powrotu do menu, przycisk do dodania i drugi do edycji przedmiotu, filtrowanie listy
przedmiotów tekstem, lista przedmiotów w dokumentcie). Klikni˛ecie dwukrotne w dokument przyj˛ecia po
wejsciu w liste dokumentów kontrahenta przenosi do tego samego widoku, natomiast aplikacja wykrywa, z
którego widoku został on odpalony i wraca do pierwotnego. Po klikni˛eciu dwukrotnie na pozycje w dokumencie
przyj˛ecia otwiera si˛e ostatni widok, który prezentuje informacje o konkretnym przedmiocie, z mo˙zliwo´sci ˛a edycji
go z poziomu tego widoku oraz powrotu do dokumentu przyj˛ecia.
