How to run:
Connect Database -> Appsetings.json 
Change your sql server "DefaultConnection": "Server="yoursqlserver=FlowerDB";Trusted_Connection=True;" 
Download package 
Microsoft.EntityFrameworkCore.SqlServer" 
Microsoft.EntityFrameworkCore.Tools"
To create Database use this commands:
CREATE DATABASE FlowerDB;
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);
CREATE TABLE Flowers (
    FlowerId INT IDENTITY(1,1) PRIMARY KEY,
    FlowerName VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
INSERT INTO Categories (CategoryName)
VALUES 
    ('Roses'), 
    ('Tulips');

INSERT INTO Flowers (FlowerName, Price, CategoryId)
VALUES 
    ('Red Rose', 10.00, 1),
    ('Yellow Rose', 12.50, 1),
    ('Purple Tulip', 15.00, 2),
    ('Pink Tulip', 18.00, 2);
Add-Migration InitialCreate
Update-Database

Files explanation:
Create.cshtml: A form for adding a new flower to the inventory, including fields for name, type, price, and category.
Delete.cshtml: A view to confirm and process the deletion of a flower from the inventory.
Details.cshtml: Displays detailed information about a specific flower in the inventory.
Edit.cshtml: A form for editing the details of an existing flower in the inventory.
Index.cshtml: A view that lists all flowers in the inventory, typically with options to view, edit, or delete each entry.
FlowerInventoryContext.cs: Defines the DbContext for interacting with the database, including DbSets for Category and Flower models, and custom configurations for flower price formatting.
CategoryService.cs: Implements business logic for managing categories, including methods to add, update, delete, and retrieve categories from the database.
FlowerService.cs: Provides business logic for managing flowers, with methods to add, update, delete, and retrieve flowers, including category details. Debugging information is also included for database operations.​
ICategoryService.cs: Defines the interface for the category service, specifying the methods for managing categories.​
FlowerService.cs: Defines the interface for the flower service, specifying the methods for managing flowers.
Category.cs: Defines the Category model with properties for Id, Name, and a collection of related Flowers
Flower.cs: Defines the Flower model with properties for Id, Name, Type, Price, and a reference to the associated Category
CategoryController.cs: Manages CRUD operations for Category entities, with actions to list, view, create, edit, and delete categories​
FlowerController.cs: Manages CRUD operations for Flower entities, including handling category associations for creating or editing flowers​

Challenges Faced:I used seeding to populate my database initially, but after deleting that step and unfortunately not having a backup, I lost the ability to save new flowers and edit existing ones. Although the Chrome DevTools show that the POST request is being made successfully, the changes are not reflected in the database

