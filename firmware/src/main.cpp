#include <Arduino.h>
#include <WiFi.h>
#include <PubSubClient.h>
#include <secrets.h>

#define SensorPin 16
#define LED_PIN 17

// 🔹 WiFi
const char *ssid = WIFI_SSID;
const char *password = WIFI_PASS;

// 🔹 MQTT (RabbitMQ)
const char *mqtt_server = MQTT_HOST;
const int mqtt_port = MQTT_PORT;
const char *mqtt_user = MQTT_USER;
const char *mqtt_pass = MQTT_PASS;
const char *mqtt_topic = "esp";

// 🔹 Blink LED
unsigned long lastBlink = 0;
const int blinkInterval = 500; // ms
bool ledState = false;

WiFiClient espClient;
PubSubClient client(espClient);

void reconnect_mqtt()
{
    while (!client.connected())
    {
        Serial.print("Conectando ao MQTT...");
        if (client.connect("esp32-client", mqtt_user, mqtt_pass))
        {
            Serial.println(" conectado!");
        }
        else
        {
            Serial.print(" falhou, rc=");
            Serial.print(client.state());
            delay(2000);
        }
    }
}

void blinkLed()
{
    digitalWrite(LED_PIN, LOW);
    delay(200);
    digitalWrite(LED_PIN, HIGH);
    delay(200);
    digitalWrite(LED_PIN, LOW);
    delay(200);
    digitalWrite(LED_PIN, HIGH);
    delay(200);
    digitalWrite(LED_PIN, LOW);
    delay(200);
    digitalWrite(LED_PIN, HIGH);
    delay(200);
    ledState = true;
}

void wifiSetup()
{
    WiFi.begin(ssid, password);

    while (WiFi.status() != WL_CONNECTED)
    {
        delay(500);
        Serial.println("Connecting to WiFi..");
    }
    Serial.println("Connected to the WiFi network");
}

void setup()
{
    Serial.begin(115200);
    delay(2000);

    // Seta o pino do LED cmo saida
    pinMode(LED_PIN, OUTPUT);
    pinMode(SensorPin, INPUT);
    digitalWrite(LED_PIN, HIGH);

    wifiSetup();

    client.setServer(mqtt_server, mqtt_port);
}

void loop()
{
    if (!client.connected())
    {
        reconnect_mqtt();
        return;
    }

    if (!ledState)
    {
        blinkLed();
    }

    client.loop();

    int motion = digitalRead(SensorPin);

    if (motion == HIGH)
    {
        digitalWrite(LED_PIN, HIGH);

        Serial.println("Movimento detectado!");
        client.publish(mqtt_topic, "movimento detectado");

        delay(3000); // evita flood
    }
    else
    {
        digitalWrite(LED_PIN, LOW);
    }
}
