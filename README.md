# 🧸 KidsPlay – MongoDB-Based Kids Activity & Wellness Web App

A full-stack **ASP.NET Core MVC** project built with **MongoDB**.  
**KidsPlay** offers a child-friendly digital platform where administrators can manage events, programs, services, testimonials, and more from a user-friendly admin panel.

---

## ✨ Key Features

- 🏠 Homepage is composed of dynamic **View Components** (Banner, About, Our Services, Programs, Events, Testimonials).  
- 🧩 **Admin panel** for managing all sections via **Areas (Admin)**.  
- 🧠 Used **generic repository and service structures** for data access and business logic layers.  
- 💡 Applied **FluentValidation** for validating DTOs across create and update operations.  
- 🗺️ **AutoMapper** is used to map between Entity and DTO models.  
- 📸 Image uploading and deletion handled via **IImageService**, saving images to local `/wwwroot/images/` path.  
- 🧵 Business logic supports **filtered queries using expressions**, enabling advanced data operations.  
- ⚙️ Dependency injection configurations placed in **ServiceCollectionExtensions** for better modularity.  
- 📁 Collection names fetched from `appsettings.json` using **IDatabaseSettings** interface for flexibility and maintainability.  
- 🔗 Although **MongoDB** is non-relational, **reference-based modeling** was used by storing `InstructorId` inside `OurProgram` documents to establish a **manual relationship**. This enabled instructor selection via dropdown during program creation.

---

## 📚 What I Learned

- What is **MongoDB**  
- **NoSQL vs SQL** concepts  
- Advantages of using **NoSQL and MongoDB**  
- MongoDB data annotations: `BsonId`, `BsonElement`, `BsonRepresentation`  
- **Reference-based modeling** (Manual Referencing)  
- Serialization issues with `DateOnly` and `TimeSpan`  
- MongoDB’s **document and collection** structure  
- **Expression-based filtering** in business layer  
- Schema enforcement is not built-in in MongoDB, so validation was handled at the application layer using **FluentValidation**

---

## 🛠️ Technologies

ASP.NET Core MVC, MongoDB, AutoMapper, FluentValidation, Generic Repository, View Components, Expression Trees, Manual Referencing, IImageService, IDatabaseSettings


![1](https://github.com/user-attachments/assets/285232c9-fae2-4048-a5a7-4fb89780fcfd)
![2](https://github.com/user-attachments/assets/72aab2fa-e96f-4cd7-a48c-c44506d1a6ec)
![3](https://github.com/user-attachments/assets/357d9321-db55-4617-9144-bcbd31e786ae)
![4](https://github.com/user-attachments/assets/92c6911c-fa6e-4648-b7bf-d50a09e839c6)
![5](https://github.com/user-attachments/assets/ce342eb0-d19a-4d8f-abcb-e073d412015c)
![6](https://github.com/user-attachments/assets/8813425f-95a1-4842-a8a7-ce6038da487d)
![7](https://github.com/user-attachments/assets/41d20551-0d57-47a7-8321-a6f5582f5e56)
![8](https://github.com/user-attachments/assets/3533b086-8a4f-4fd9-92dc-a3f677013f3b)
![9](https://github.com/user-attachments/assets/bc2724d8-3807-4a13-b905-b79e06e010a5)
![10](https://github.com/user-attachments/assets/dec21300-b866-4675-9c89-26e0f5a02a7a)
![11](https://github.com/user-attachments/assets/7be5271e-9e5b-4c3d-acaf-f88ab425c852)
![12](https://github.com/user-attachments/assets/df8a2f15-ff83-436a-804c-d4e4db23f99e)
![13](https://github.com/user-attachments/assets/2d8c5388-9576-4085-a8c4-381beaca41a5)
![14](https://github.com/user-attachments/assets/eea2fc34-7f03-4744-a7e3-e30324abbd9d)
![15](https://github.com/user-attachments/assets/4e7a5775-6020-4d49-9dec-0b630a46c9b0)
![16](https://github.com/user-attachments/assets/ab52fa8b-4ee4-4c9d-9f25-a4030f469ec5)
![17](https://github.com/user-attachments/assets/6171dd30-ede5-48ef-b531-8b803313b23b)
![18](https://github.com/user-attachments/assets/f133d3a6-18dc-424d-84c6-b9519614ad16)
