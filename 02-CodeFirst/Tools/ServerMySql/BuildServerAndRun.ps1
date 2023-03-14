## Ejecutar este fichero desde la carpeta 02-codefirst

##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='server-mysql' --format="{{.ID}}"))

##construir la imagen
docker build -t server-mysql Tools\ServerMysql\.

##iniciar el contenedor
docker run -d -p 4306:3306 server-mysql