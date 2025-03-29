-- Создание ролей
CREATE ROLE owner;
CREATE ROLE manager;

-- Назначение прав роли "Владелец"
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO owner;
GRANT owner TO postgres; -- Назначаем роль "владелец" текущему пользователю postgres

-- Назначение прав роли "Начальник" (пример)
GRANT SELECT, INSERT, UPDATE, DELETE ON users TO manager;
-- Доступ к таблице employees (SELECT, INSERT, UPDATE, DELETE), но только для сотрудников, которых он создал

CREATE USER owner_user WITH PASSWORD 'owner_password' IN ROLE owner;
CREATE USER manager1 WITH PASSWORD 'manager1_password' IN ROLE manager;