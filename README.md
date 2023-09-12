# mouse-combine-backend-dotnet
This is the backend for my mouse-combinator web app. 

It implements a basic producer -> consumer -> worker scheme.

We have a simple custom API with a queue service. The client POSTs a list of the mice it wants combined, and the API attempts to queue the request. If the service is overloaded the API will return a 503 (MAYBE NOT). Otherwise, the client will receive a 202 with an associated URL pointing to the desired static resource (combined mice). The client should expect failure by default.

The consumer (worker) polls the queue service periodically for processing. If the queue has available items, it asynchronously spawns jobs that process the needed items.

{DIAGRAM HERE}

The consumer is designed to scale, ie multiple consumers should be able to be added. 

The goal of this project is to be modular and simple:

    - Down the line, it should be easy enough to replace the producer-consumer system with a message-queueing service such as RabbitMQ or Kafka.
    - This would simply require removing the queue service from the API and rewiring the endpoints
    - I probably want to separate the consumer from the Python image processor
    - The image processing job should be explictly one shot

# Codebase Architecture

This project is hosted in a monorepo format. CI/CD will be handled via Github Actions.

The workflow will essentially be GitLab flow. Feature branches will open MRs against Main, and MRs will approved once the feature is tested. 

# TODO

API documentation for external applications that wish to use this app's functionality
