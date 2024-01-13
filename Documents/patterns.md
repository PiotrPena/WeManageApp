# Wzorce Projektowe Zastosowane w WeManage

1. **Gateway** - `Panel` oraz klasy pochodne
   - Oddzielenie logiki przetwarzania danych od logiki samego programu.
   - Możliwość elastycznej wymiany paneli.

2. **Registry** - `NotificationList`
   - Globalny dostęp do używanych przez wszystkich użytkowników powiadomień.

3. **Identity Map** - `Notification List`
   - Zniwelowanie konieczności ciągłego pobierania z bazy tych samych danych.

4. **Money** - `Money`
   - Umożliwienie operacji na płacach pracowników z użyciem różnych walut.

5. **Record Set** - `Entities`
   - Umożliwia przetwarzanie danych bazodanowych jako obiektów w języku C#.

6. **Identity Field** - `Entities`
   - Umożliwia łatwe przetwarzanie, usuwanie, aktualizowanie i identyfikację danych bazodanowych.

7. **Foreign Key Mapping** - `Recruit/Recruitments`, `Project/ProjectDetails`
   - Umożliwia skorelowanie dla tych danych, w przypadku których konieczne jest sięganie do kilku różnych tablic, aby uzyskać pełny ich obraz.
