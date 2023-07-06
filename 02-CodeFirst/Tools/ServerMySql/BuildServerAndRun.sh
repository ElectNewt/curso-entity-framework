## Ejecutar este fichero desde la carpeta 02-codefirst

##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='server-postgres' --format="{{.ID}}"))

##construir la imagen
docker build -t server-postgres Tools/ServerMysql/.

##iniciar el contenedor
docker run -d -p 5432:5432 server-postgres

# mysql concurrencycheck issue
# docker run -d -p 4306:3306 server-mysql