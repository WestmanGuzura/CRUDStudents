using CRUDStudents.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudents.web.Data
{

    //this is our bridge between our pplication and SQL server
    // this class will be used to create the database and the tables
    // it will also be used to seed the database with initial data

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options )
        { 
        }

        // we  will use this property to access the Students table and use it in our controllers
        // this property will be used to create the Students table in the database
        // this property will be used to access the Students table in the database

        public DbSet<Students> Students { get; set; }

        /*
         What is a DbContext?
            In Entity Framework Core (EF Core), a DbContext is a class that acts as a bridge between your application and the database. It provides the following key functionalities:
            1.	Database Connection: It knows how to connect to the database using the connection string provided in the configuration.
            2.	Mapping Entities to Tables: It maps your C# classes (like Students) to database tables.
            3.	Querying and Saving Data: It allows you to query the database (e.g., retrieve students) and save changes (e.g., add, update, or delete students).
            4.	Change Tracking: It keeps track of changes made to your entities so it can generate the appropriate SQL commands to update the database.
            ---
            ApplicationDbContext in Your Project
                In your project, the ApplicationDbContext class inherits from DbContext, which means it gains all the functionality of EF Core's DbContext. Here's a breakdown of its components:
                The constructor accepts DbContextOptions<ApplicationDbContext> as a parameter. 
                This is how EF Core knows the configuration details, such as the database provider (e.g., SQL Server) and the connection string.
            •	The base(options) call passes these options to the parent DbContext class.

            •A DbSet<T> represents a table in the database. In this case:
            •	The Students property maps to a table named Students in the database.
            •	Each row in the Students table corresponds to an instance of the Students class.
            •	You can use this property to perform CRUD (Create, Read, Update, Delete) operations on the Students table.

         */
    }
}
