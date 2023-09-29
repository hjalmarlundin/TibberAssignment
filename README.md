Run application in docker:

docker build --tag 'app' .
docker run --rm -it -p 8000:8080 'app'