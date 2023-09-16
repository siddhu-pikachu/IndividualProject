# Facade Design Pattern - E-Commerce App
## Overview
This project is an implementation of the Facade Design Pattern in the context of an e-commerce application. The primary goal of using the Facade pattern is to simplify and encapsulate complex interactions and subsystems, providing clients with a simple interface to interact with the system. In this case, it simplifies the process of placing orders and managing inventory.

## What is the Facade Design Pattern?
The Facade Design Pattern is a structural pattern that provides a unified and simplified interface to a set of interfaces or classes in a subsystem. It hides the complexities of the subsystem and offers a more straightforward interface for clients to work with.

## Project Description
In this e-commerce application, we have applied the Facade pattern in two main areas:

> 1. Placing Orders
The complexities of placing orders, including product validation, payment processing, and inventory management, are hidden from the client.
Clients can simply call a single method to place an order, making the process more user-friendly and less error-prone.
> 2. Inventory Management
The intricacies of maintaining the inventory, such as adding and adjusting product quantities, are abstracted from the staff.
Staff members are provided with a straightforward method to update inventory, ensuring ease of use and minimizing the risk of errors.

## Design
![alt text](https://github.com/siddhu-pikachu/IndividualProject/blob/main/UmlDiagram.PNG)

## Environment
The project builds and runs with Visual Studio Community 2022 when the required workloads are installed.
