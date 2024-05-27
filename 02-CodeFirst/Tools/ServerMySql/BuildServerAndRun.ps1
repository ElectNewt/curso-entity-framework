## Ejecutar este fichero desde la carpeta 02-codefirst

##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='server-mysql' --format="{{.ID}}"))

##construir la imagen
docker build -t server-mysql Tools\ServerMysql\.

##iniciar el contenedor (esto s posgress, solo que no le he cambiado el nombre)
docker run -d -p 5432:5432 server-mysql