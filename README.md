# Sample_aspcore_webapplication
Sample asp.net core web application - alpine 

# This repository contains a sample asp.net core web application for learning and demo
In this i tried below
1. Read application configuration from appsettings.json
2. read variable from environment
3. Docker multistage build
4. Using alpine as base image
5. Using config map to inject environment variables

# Yet to try
6. Using secrets
7. Use helm
8. use helm to deploy in differnt namespace


# Docker commands

docker build -f Dockerfile.alpine-x64 -t alpinecore:1.0 .

docker build -f Dockerfile.alpine-x64 -t alpinecore:1.0 . && docker run -it -p 8081:80 alpinecore:1.0

docker exec -it dedd102f87154 '/bin/sh' 

docker stop $(docker ps --all --format "{{.Names}}")

docker run -d -p 8081:80 alpinecore:1.0

docker build --build-arg rabbitmq=localhost -f Dockerfile.alpine-x64 -t alpinecore:1.0 .

# Push image to dockerhub
1. Build the image  --> docker build -f Dockerfile.alpine-x64 -t alpinecore:1.0 .

2. Tag image --> docker tag alpineaspnetcore:1.0 bhoobal/alpineaspnetcore:1.0

3. docker login  --> docker login

4. Push the image to repo  --> docker push bhoobal/alpineaspnetcore:1.0

# Git commands
git init
git add .
git commit
git push
git remote add origin git@github.com:bhoobal/Sample_aspcore_webapplication
git push origin
git push --set-upstream origin master

# Kubernetes part
I am using minikube

$ minikube start

$ minikune ip

$ minikube status

$ kubect proxy  -- to start dashboard

$ kubectl apply -f webappdeployment.yaml

$ kubectl expose deployment webapplication-deployment --type=NodePort --port 80 --target-port 80

You need to make sure pods and endpoints are exposed in services

$ kubectl describe services

$ kubectl apply -f configmapexample.yaml

$ kubectl apply -f webappdeployment.yaml






