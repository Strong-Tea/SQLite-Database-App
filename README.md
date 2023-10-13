# Задание

Разработать приложение на Windows Forms (желательно .NET Framework 4.5), при запуске ПО создается (если она отсутствует) база данных SQLite с 2 таблицами, связанных между собой: Modes и Steps. 
Modes имеет столбцы ID, Name, MaxBottleNumber, MaxUsedTips
Steps имеет столбцы ID, ModeId, Timer, Destination, Speed, Type, Volume

В ПО должна быть реализована регистрация и авторизация, возможность просмотра, удаления и редактирования таблиц, добавление строк с помощью Excel документа.
Логин должен быть уникальным и не повторяться, пароль должен содержать минимум 6 символов, из которых обязательно должна быть 1 цифра и 1 буква.
