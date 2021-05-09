# BookShop2

Написано приложение - магазин книг.

Книга это объект, состоящий из следующих полей
	Id
	автор
	название
	год издания

Под хранение данных используется СУБД MySQL

В уачестве UI используется настольное приложение WPF с отображением списка книг, возможностью сортировать список по любому из параметров
 и напротив кждаой строки кнопка "купить": убирает одну книгу из БД;

Общение с БД происходит через строку подключения 
using (var sqlConnection = new SqlConnection(ConnectionStringDb))...
            

Скрипт создания БД:
CREATE TABLE [dbo].[Books] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Title]  NVARCHAR (MAX) NULL,
    [Author] NVARCHAR (MAX) NULL,
    [Date]   DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);
