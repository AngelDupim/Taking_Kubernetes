#!bin/sh

eval $(minikube -p minikube docker-env)

echo "Iniciando API"

docker build -f src/AngelSystem_Estacionamento/Dockerfile -t estacionamento/api-estacionamento:1.0.0 .

echo "Finalizado API"

sleep 3

echo "Executar Script"

docker build -f src/AngelSystem_Estacionamento/AngelSystem_Estacionamento.ExecutarScript/Dockerfile -t estacionamento/scripts-estacionamento:1.0.0 .

echo "Executar Script"