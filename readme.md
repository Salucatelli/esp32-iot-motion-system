# 📡 ESP32 IoT Motion System

Complete IoT system for motion detection using **ESP32**, **MQTT**, **RabbitMQ**, **ASP.NET Core (C#)** and **SignalR**, with real-time visualization via **pure HTML + JavaScript**.

This project demonstrates a real end-to-end architecture, integrating hardware, messaging, backend, and frontend in real time, following good development practices and asynchronous communication principles.

---

## 🧠 Architecture Overview

ESP32 + PIR Sensor
<br>
│
<br>
│ 
MQTT
<br>
▼
<br>
RabbitMQ (MQTT Broker)
<br>
│
<br>
│ AMQP
<br>
▼
<br>
ASP.NET Core Backend (SignalR)
<br>
│
<br>
│ WebSocket
<br>
▼
<br>
HTML + JavaScript Frontend

---

## ✨ Features

### ESP32
- Automatic Wi-Fi connection
- MQTT communication
- PIR sensor reading (motion detection)
- Status LED (connected / error)
- Real-time event publishing

### Backend (C# / ASP.NET Core)
- RabbitMQ message consumption (AMQP)
- Background service for continuous listening
- Real-time communication using SignalR
- CORS configuration for external frontend

### Frontend
- Pure HTML + JavaScript
- SignalR connection to the backend
- Real-time sensor state updates

---

## 🛠️ Technologies Used

| Layer        | Technology |
|--------------|------------|
| Hardware     | ESP32 |
| Firmware     | PlatformIO / Arduino |
| Messaging    | MQTT |
| Broker       | RabbitMQ (Docker) |
| Backend      | ASP.NET Core / C# |
| Real-time    | SignalR |
| Frontend     | HTML / JavaScript |

---

## 📁 Repository Structure

esp32-iot-motion-system/
<br>
│
<br>
├── firmware/
<br>
│ └── esp32/ # ESP32 firmware code
<br>
│
<br>
├── backend/
<br>
│ └── gateway/ # ASP.NET Core API + SignalR
<br>
│
<br>
├── broker/
<br>
│ └── rabbitmq/ # RabbitMQ Docker Compose + MQTT
<br>
│
<br>
├── frontend/
<br>
│ └── index.html # HTML + JS frontend
<br>
│
<br>
└── README.md

---

## Video showing it working

https://github.com/user-attachments/assets/1f7b49de-3070-42de-bdb0-79c5db89f4f3


# 🇧🇷 Versão em Portugês 

# 📡 ESP32 IoT Motion System

Sistema IoT completo para detecção de movimento utilizando **ESP32**, **MQTT**, **RabbitMQ**, **ASP.NET Core (C#)** e **SignalR**, com visualização em tempo real via **HTML + JavaScript puro**.

Este projeto demonstra uma arquitetura real de ponta a ponta, integrando hardware, mensageria, backend e frontend em tempo real, seguindo boas práticas de desenvolvimento e comunicação assíncrona.

---

## 🧠 Visão Geral da Arquitetura

ESP32 + Sensor PIR
<br>
│
<br>
│ 
MQTT
<br>
▼
<br>
RabbitMQ (Broker MQTT)
<br>
│
<br>
│ AMQP
<br>
▼
<br>
Backend ASP.NET Core (SignalR)
<br>
│
<br>
│ WebSocket
<br>
▼
<br>
Frontend HTML + JavaScript


---

## ✨ Funcionalidades

### ESP32
- Conexão automática à rede Wi-Fi
- Comunicação via MQTT
- Leitura de sensor PIR (detecção de movimento)
- LED de status (conectado / erro)
- Publicação de eventos em tempo real

### Backend (C# / ASP.NET Core)
- Consumo de mensagens do RabbitMQ (AMQP)
- Serviço em background para escuta contínua
- Comunicação em tempo real com SignalR
- Configuração de CORS para frontend externo

### Frontend
- HTML + JavaScript puro
- Conexão com backend via SignalR
- Atualização em tempo real do estado do sensor

---

## 🛠️ Tecnologias Utilizadas

| Camada       | Tecnologia |
|--------------|------------|
| Hardware     | ESP32 |
| Firmware     | PlatformIO / Arduino |
| Mensageria   | MQTT |
| Broker       | RabbitMQ (Docker) |
| Backend      | ASP.NET Core / C# |
| Real-time    | SignalR |
| Frontend     | HTML / JavaScript |

---

## 📁 Estrutura do Repositório

esp32-iot-motion-system/
<br>
│
<br>
├── firmware/
<br>
│ └── esp32/ # Código do ESP32
<br>
│
<br>
├── backend/
<br>
│ └── gateway/ # API ASP.NET Core + SignalR
<br>
│
<br>
├── broker/
<br>
│ └── rabbitmq/ # Docker Compose do RabbitMQ + MQTT
<br>
│
<br>
├── frontend/
<br>
│ └── index.html # Frontend HTML + JS
<br>
│
<br>
└── README.md

