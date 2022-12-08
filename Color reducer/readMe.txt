Klawiszologia:

Menu strip:
	"Load image" - naciśnięcie przycisku otwiera okno wyboru pliku graficznego; po jego wyborze, zostanie on wczytany do programu i każde z 4 okien zostanie przeładowane (z zachowaniem dotychczasowych parametrów); próba wgrania błędnego pliku zakończy się komunikatem o błędzie i przerwaniem operacji
	"Load default" - naciśniecie przycisku pokaże listę przygotowanych zdjęć pokazowych, naciśniecie dowolnego z nich spowoduje że zostanie on wczytany do programu i każde z 4 okien zostanie przeładowane (z zachowaniem dotychczasowych parametrów)
	"Choose uncertainty filter matrix" - naciśniecie przycisku pokaże listę dostępnych macierzy propagacji błędu, naciśniecie dowolnej z nich spowoduje przeładowanie kafelka okna reprezentującego algorytm propagacji błędu (ozn. "Propagation of uncertainty") w oparciu o nową macierz.
	"Change K-means epsilon value" - naciśnięcie przycisku otworzy okno umożliwiające wpisanie dopuszczalnej wartości zatrzymania działania algorytmu k-means. Wartość epsilon powinna być całkowita i nieujemna. Wpisanie wartości spełniającej te zasady i zatwierdzenie klawiszem "OK" spowoduje przeładowanie kafelka okna reprezentującego algorytm k-means w oparciu o nową wartość parametru epsilon. Podanie złej wartości spowoduje przerwanie operacji.

Suwak w prawym dolnym rogu służy do zmiany ilości kolorów, do której ograniczone zostanie oryginalne zdjęcie. Zmiana wartości suwakiem spowoduje uaktualnienie informacji o palecie po lewej stronie suwaka oraz przeładowanie wszystkich trzech okien odpowiedzialnych za reprezentacje działania poszczególnych algorytmów.

! UWAGA !
Z przyczyn niewyjaśnionych, Visual Studio czasami uznaje plik colorReduction.resx za złośliwy, ponieważ został pobrany z internetu, co w konsekwencji uniemożliwia kompilacje. Oczywiście pliku nie należy się obawiać :) Aby odblokować plik (a co za tym idzie kompilacje projektu) należy wejśc do folder z projektem, nacisnąc prawym na rzeczony plik, wybrać Właściwości, zaznaczyć na dole okienko "Odblokuj" i zapisać zmiany.