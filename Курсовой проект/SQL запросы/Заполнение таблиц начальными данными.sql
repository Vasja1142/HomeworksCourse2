
-- Добавление владельца (выполняется один раз)
INSERT INTO users (email, password, role, is_active)
VALUES ('owner@sushishop.com',
        -- Пароль 'owner_password', зашифрованный, например, с помощью bcrypt
        '$2b$12$abcdefgh1234567890abcdefgh1234567890abcdefgh1234567890a',
        1, -- 1 - Владелец
        TRUE);


-- Добавление складов
INSERT INTO warehouses (name)
VALUES ('Склад 1'),
       ('Склад 2'),
       ('Склад 3'),
       ('Склад 4');

-- Добавление продуктов
INSERT INTO products (name, unit)
VALUES ('Рис', 'кг'),
       ('Лосось', 'кг'),
       ('Нори', 'шт'),
       ('Авокадо', 'шт'),
       ('Огурец', 'шт'),
       ('Сыр Филадельфия', 'кг'),
       ('Соевый соус', 'л');

-- Добавление управляющих (пример)
-- Пароли должны быть зашифрованы!
INSERT INTO users (email, password, role, is_active)
VALUES ('manager1@sushishop.com', '$2b$12$manager1_hashed_password', 2, TRUE),
       ('manager2@sushishop.com', '$2b$12$manager2_hashed_password', 2, TRUE);

-- Назначение управляющих на склады (через таблицу access)
-- Предположим, что id пользователя manager1 = 2, а id склада 1 = 1
INSERT INTO access (user_id, warehouse_id)
VALUES (2, 1); -- manager1 управляет складом 1

-- Предположим, что id пользователя manager2 = 3, а id склада 2 = 2 и склада 3 = 3.
INSERT INTO access (user_id, warehouse_id)
VALUES (3, 2), -- manager2 управляет складом 2
       (3, 3); -- manager2 управляет складом 3


-- Добавление начальных остатков продуктов на склады (пример)
-- Склад 1
INSERT INTO warehouse_products (warehouse_id, product_id, quantity)
VALUES (1, 1, 100),  -- Рис, 100 кг
       (1, 2, 50),   -- Лосось, 50 кг
       (1, 3, 200),  -- Нори, 200 шт
       (1, 4, 50), --Авокадо
        (1,5,40),
        (1,6,40),
        (1,7,54);

-- Склад 2
INSERT INTO warehouse_products (warehouse_id, product_id, quantity)
VALUES (2, 1, 80),
       (2, 2, 40),
       (2, 3, 150),
       (2, 4, 60),
       (2,5,30);

-- Склад 3
INSERT INTO warehouse_products (warehouse_id, product_id, quantity)
VALUES (3,1,20),
        (3,4,30),
        (3,6,35);

-- Склад 4
INSERT INTO warehouse_products (warehouse_id, product_id, quantity)
VALUES (4,1,200),
       (4,7,200);