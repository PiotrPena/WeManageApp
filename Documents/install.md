# Dokumentacja Instalacyjno-Użytkowa

## Wymagania

Korzystanie z aplikacji wymaga zainstalowania na systemie pakietu `.NET SDK` w wersji **8.0** oraz doistalowania wymaganych pakietów (głównie `Entity Framework`). Konieczna jest również instalacja aplikacji **Microsoft SQL Server 22**. Zalecana jest również instalacja `SQL Server Management Studio`, co znacząco ułatwi ewentualne modyfikacje i konfiguracje bazy danych.

## Instalacja

Przed rozpoczęciem korzystania z programu należy odtworzyć bazę danych `WeManageDB`, której backup znajduje się w folderze `Backups`. Konieczne jest również skonfigurowanie Connection Stringów w plikach `Entities/WeManageContext.cs` oraz `appsettings.json` w taki sposób, aby możliwe było połączenie z odtworzoną bazą z poziomu aplikacji. Po wykonaniu powyższych czynności należy skompilować plik `Program.cs`, skorygować ewentualne błędy i uruchomić program korzystając z pliku binarnego `WeManageApp.exe`, znajdującego się w folderze `bin`.

## Użytkowanie

Użytkowanie programu polega na wpisywaniu odpowiednich komend w odpowiedzi na polecenia wyświetlane w konsoli systemu Windows. Możliwe jest ręczne modyfikowanie danych poprzez wykonywanie odpowiednich kwerend w aplikacji `SSMS`.

> **Uwaga**: Hasła w tabeli `Logins` nie są w żaden sposób zabezpieczone ani zaszyfrowane, zatem nie należy umieszczać w niej prawdziwych danych logowania, a samą aplikację stosować w celach testowych i edukacyjnych.