#!bin/sh
echo "Aplicando namespace"
kubectl apply -f namespace.yaml
sleep 1

echo "Aplicando secret"
kubectl apply -f secret.yaml
sleep 1

echo "Aplicando configmap"
kubectl apply -f configmap.yaml
sleep 1

echo "Aplicando base statefulSet"
kubectl apply -f Base//statefulSet.yaml
echo "Aguarde o download da imagem do sqlServer 1 minuto mais ou menos"
sleep 60

echo "Aplicando base service"
kubectl apply -f Base//service.yaml
sleep 1

echo "Aplicando deplyment"
kubectl apply -f Application//deployment.yaml
sleep 1

echo "Aplicando service"
kubectl apply -f Application//service.yaml
sleep 1

echo "Aplicando base job"
kubectl apply -f Base//job.yaml
sleep 1