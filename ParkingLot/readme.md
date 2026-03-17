# 🚗 Parking Lot System (LLD - C#)

## 📌 Overview

This project is a **Low-Level Design (LLD)** implementation of a Parking Lot System built using **C#**.
It simulates real-world parking operations including **vehicle entry, parking allocation, ticket generation, billing, and exit flow**.

The system is designed with **extensibility, modularity, and clean architecture principles** in mind, making it suitable for interview preparation and real-world understanding.

---

## 🎯 Features

* 🚪 Entry & Exit Gate handling
* 🎟️ Ticket generation on vehicle entry
* 🅿️ Smart parking spot allocation using Strategy Pattern
* 🚗 Supports multiple vehicle types:

  * Two-Wheeler
  * Four-Wheeler
  * Heavy Vehicle
* 💰 Billing based on parking duration
* 💳 Payment simulation
* 🏢 Multi-floor parking support
* 🔄 Real-time spot availability tracking

---

## 🏗️ System Design

### Core Entities

* **ParkingLot**

  * Central system managing floors, tickets, and allocation strategy

* **Floor**

  * Contains multiple parking spots

* **ParkingSpot**

  * Represents individual parking slots with occupancy state

* **Vehicle**

  * Holds vehicle details (type, license plate)

* **Ticket**

  * Generated during entry, used for billing and exit

---

### 🚪 Gate Layer

* **EntryGate**

  * Handles vehicle entry and ticket generation

* **ExitGate**

  * Handles vehicle exit, billing, and freeing spots

---

### ⚙️ Services

* **BillingService**

  * Calculates parking fee based on duration and vehicle type

* **PaymentService (simulated)**

  * Handles payment processing

---

### 🧠 Strategy Pattern

* **ISpotAllocationStrategy**

  * Interface for pluggable parking strategies

* **SpotAllocationStrategy**

  * Default implementation (linear scan for nearest available spot)

---

## 🔄 Flow

### 🚗 Parking Flow

1. User enters through Entry Gate
2. System finds an available spot using strategy
3. Spot is marked occupied
4. Ticket is generated and returned

---

### 🚙 Unparking Flow

1. User provides Ticket ID at Exit Gate
2. System retrieves ticket
3. BillingService calculates fee
4. Payment is processed
5. Spot is freed
6. Ticket is removed from active records

---

## 📂 Project Structure

```
ParkingLot/
│
├── EntryGate.cs
├── ExitGate.cs
├── ParkingLot.cs
├── Floor.cs
├── ParkingSpot.cs
├── Vehicle.cs
├── Ticket.cs
├── BillingService.cs
├── ISpotAllocationStrategy.cs
├── SpotAllocationStrategy.cs
└── Program.cs
```

---

## ▶️ How to Run

1. Clone the repository
2. Open in Visual Studio / VS Code
3. Run the application

```bash
dotnet run
```

---

## 💡 Sample Commands

```text
park
unpark
exit
```

---

## ⚠️ Assumptions

* Single entry and exit gate (can be extended)
* Payment is simulated
* Spot allocation uses simple linear strategy
* Input configuration is basic and can be enhanced

---

## 🚀 Future Improvements

* ✅ Thread-safe operations for concurrent entry gates
* ✅ Multiple entry/exit gates support
* ✅ Advanced allocation strategies (nearest, priority-based)
* ✅ Real payment gateway integration
* ✅ Persistent storage (DB)
* ✅ REST API layer

---

## 🧠 Design Principles Used

* SOLID Principles
* Strategy Pattern
* Separation of Concerns
* Encapsulation

---

## ⭐ Why This Project?

This project demonstrates:

* Real-world system design thinking
* Clean object-oriented design
* Extensibility using design patterns
* Interview-level LLD problem solving

---

## 👨‍💻 Author

**Sourav Kumar**

---

## 📌 Note

This project is built for **learning and interview preparation purposes**, focusing on clarity of design rather than production-level optimizations.
