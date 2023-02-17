FROM mysql:latest

ENV MYSQL_DATABASE=cursoEF
ENV MYSQL_USER=cursoEFuser
ENV MYSQL_PASSWORD=cursoEFpass
ENV MYSQL_ROOT_PASSWORD=cursoEFpass

## todos los scripts en  docker-entrypoint-initdb.d/ se ejecutan automaticamente
COPY ./Database-first-example/ ./docker-entrypoint-initdb.d/