## Design Patterns and OOP Principles Used:

### **Strategy Pattern:**

The IEmailService interface and its concrete implementations (like SendGridEmailService, GmailEmailService, etc.)
represent the Strategy pattern. This pattern allows the algorithm's behavior to be selected at runtime. The different
strategies encapsulate different email services, which can be switched out seamlessly without affecting the clients that
use them.

### **Facade Pattern:**

The EmailServiceManager acts as a facade that simplifies the interface for clients. Clients don’t need to manage or know
about the different email services and their error-handling mechanisms.
Adapter Pattern:

If the third-party services have different APIs, each specific service implementation (SendGridEmailService,
GmailEmailService, etc.) might also act as an Adapter. This adapts the third-party email service's API to the common
IEmailService interface expected by your system.

### **Dependency Injection:**

Providing the EmailServiceManager with a list of IEmailService instances (either through the constructor or a setter
method) is an example of Dependency Injection. This promotes loose coupling and greater flexibility in the configuration
of email services.

### Singleton Pattern (Optional):

If there should only be a single instance of the EmailServiceManager throughout the application, implementing it as a
Singleton could be considered. This ensures that email sending operations are centralized and easily manageable.

### **SOLID Principles Applied:**

### **Single Responsibility Principle (SRP):**

Each class has a clear responsibility: service classes handle sending emails, while the manager orchestrates when and
how these services are used.

### **Open/Closed Principle (OCP):**

The system is open for extension but closed for modification. You can add new email services by simply creating new
classes that implement the IEmailService interface without modifying the existing manager logic.

### **Liskov Substitution Principle (LSP):**

Subtypes (different email service implementations) must be substitutable for their base type (IEmailService). This is
ensured by adhering to the interface contract.

### **Interface Segregation Principle (ISP):**

The IEmailService interface is likely small and client-specific, meaning clients will only have to know about the
SendEmail method, nothing more.

### **Dependency Inversion Principle (DIP):**

The design depends on abstractions (the IEmailService interface), not concretions (specific email services), which is
crucial for maintaining the flexibility and decoupling of the system.