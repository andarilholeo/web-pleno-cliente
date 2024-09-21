FROM mysql:8.0

ENV MYSQL_ROOT_PASSWORD=AResposta42_#
ENV MYSQL_DATABASE=clientedb

COPY init.sql /docker-entrypoint-initdb.d/

EXPOSE 3306
