SET search_path TO public;
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    role INT,
    is_active BOOLEAN
);

CREATE TABLE warehouses (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL  
);

CREATE TABLE products(
	id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL, 
	unit VARCHAR(50) NOT NULL
);

CREATE TABLE access(
	id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(id), 
	warehouse_id INT REFERENCES warehouses(id)
);

CREATE TABLE warehouse_products(
	id SERIAL PRIMARY KEY,
	warehouse_id INT REFERENCES warehouses(id),
	product_id INT REFERENCES products(id),
	quantity NUMERIC(10, 2)
);


