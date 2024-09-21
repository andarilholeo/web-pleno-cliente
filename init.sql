CREATE TABLE Clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    telefone VARCHAR(15),
    data_nascimento DATE
);

CREATE TABLE Enderecos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT,
    cep VARCHAR(10),
    rua VARCHAR(255) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    complemento VARCHAR(255),
    bairro VARCHAR(50) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(id) ON DELETE CASCADE
);
