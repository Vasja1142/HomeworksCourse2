DROP TABLE Table_Gordeev;

CREATE TABLE Table_Gordeev (
Id SERIAL PRIMARY KEY,
Name VARCHAR(35) NOT NULL,
Phone VARCHAR(11) NOT NULL,
Experience INT NOT NULL,
Salary INT NOT NULL,
Adress VARCHAR(100) NOT NULL
);

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Гордеев Василий Андреевич', '843924', 3, 30000, 'Кунгур');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Потапов Емельян Святославович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Гордеев Эрик Онисимович', '84392484', 3, 30000, 'Соликамск');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Ефремов Максим Игоревич', '84392484', 3, 30000, 'Москва');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Кулаков Виктор Миронович', '84392484', 8, 30000, 'Екатеринбург');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Дементьев Виссарион Святославович', '84392484', 3, 30000, 'Пермь');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Егоров Виталий Пётрович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Якушев Карл Георгьевич', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Андреев Иван Яковлевич', '84392484', 3, 30000, 'Пермь');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Исаков Адольф Давидович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Пестов Вилен Христофорович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Кудрявцев Петр Артёмович', '84392484', 3, 30000, 'Пермь');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Орехов Остап Натанович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Дорофеев Гордей Михайлович', '84392484', 5, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Бирюков Евгений Миронович', '84392484', 3, 30000, 'Пермь');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Голубев Аввакуум Аркадьевич', '84392484', 6, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Лебедев Бенедикт Миронович', '84392484', 3, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Устинов Аввакум Парфеньевич', '84392484', 3, 30000, 'Пермь');

INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Кулаков Ибрагил Натанович', '84392484', 1, 30000, 'Пермь');
INSERT INTO Table_Gordeev (Name, Phone, Experience, Salary, Adress)
VALUES ('Филиппов Юрий Митрофанович', '84392484', 3, 30000, 'Пермь');


SELECT Name, Phone, Salary
FROM Table_Gordeev;

SELECT Name, Adress
FROM Table_Gordeev
ORDER BY Adress;

SELECT Name, Experience
FROM Table_Gordeev
WHERE Experience > 4;