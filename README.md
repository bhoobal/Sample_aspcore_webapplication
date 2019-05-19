# Sample_aspcore_webapplication
Sample asp.net core web application - alpine 

# This repository contains a sample asp.net core web application for learning and demo
In this i tried below
1. Read application configuration from appsettings.json
2. read variable from environment
3. Docker multistage build
4. Using alpine as base image

# Docker commands

docker build -f Dockerfile.alpine-x64 -t alpinecore:1.0 .

docker build -f Dockerfile.alpine-x64 -t alpinecore:1.0 . && docker run -it -p 8081:80 alpinecore:1.0

docker exec -it dedd102f87154 '/bin/sh' 

docker stop $(docker ps --all --format "{{.Names}}")

docker run -d -p 8081:80 alpinecore:1.0

docker build --build-arg rabbitmq=localhost -f Dockerfile.alpine-x64 -t alpinecore:1.0 .


# Git commands
git init
git add .
git commit
git push
git remote add origin git@github.com:bhoobal/Sample_aspcore_webapplication
git push origin
git push --set-upstream origin master
