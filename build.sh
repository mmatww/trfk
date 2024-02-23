#!/bin/bash
#docker build -f ./Dockerfile -t quay.io/marti_martinez/trfk:main --platform linux/amd64,linux/arm64 --push .
docker build -f ./Dockerfile -t quay.io/marti_martinez/trfk:main --push .