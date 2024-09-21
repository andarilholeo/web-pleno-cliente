# Configuração do Banco de Dados MySQL

Este documento descreve os passos necessários para criar e executar um banco de dados MySQL usando Docker.

## Criação do Banco MySQL

Na pasta raiz do projeto, você encontrará um arquivo `Dockerfile` que configura a imagem do MySQL.

### Passos para Criar a Imagem

1. **Abra o Terminal**: Navegue até a pasta raiz do projeto onde o `Dockerfile` está localizado.

2. **Crie a Imagem**: Execute o seguinte comando para criar uma imagem com as variáveis de ambiente definidas:

   ```bash
   docker build -t imagem_bancocliente_mysql .

3. **Execute o Container** : 
   ```bash
   docker run --name container_clientedb imagem_bancocliente_mysql
