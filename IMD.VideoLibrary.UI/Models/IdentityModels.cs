﻿
namespace IMD.VideoLibrary.UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser 
    {
      
    }

    public class ApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}