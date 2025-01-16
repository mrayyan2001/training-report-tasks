CREATE TABLE customer (
    customer_id INT NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    address VARCHAR(255) NOT NULL,
    city VARCHAR(100) NOT NULL,
    state VARCHAR(100) NOT NULL,
    country VARCHAR(100) NOT NULL,
    PRIMARY KEY (customer_id)
);


CREATE TABLE [order] (
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    shipped_date DATETIME NOT NULL,
    order_id INT NOT NULL,
    PRIMARY KEY (order_id),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);


CREATE TABLE product (
    product_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    color VARCHAR(50) NOT NULL,
    cost DECIMAL(10, 2) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (product_id)
);


CREATE TABLE product_in_order (
    quantity INT NOT NULL,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    PRIMARY KEY (order_id, product_id),
    FOREIGN KEY (order_id) REFERENCES [order](order_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id),
    UNIQUE (order_id, product_id)
);