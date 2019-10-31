namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodOptions",
                c => new
                    {
                        FoodOptionId = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                    })
                .PrimaryKey(t => t.FoodOptionId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.FoodOrders",
                c => new
                    {
                        FoodId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        FoodStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodId, t.OrderId })
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FoodFinished = c.Boolean(nullable: false),
                        DrinksFinished = c.Boolean(nullable: false),
                        Waiter_UserId = c.Int(),
                        Reservation_ReservationId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.Waiter_UserId)
                .ForeignKey("dbo.Reservations", t => t.Reservation_ReservationId)
                .Index(t => t.Waiter_UserId)
                .Index(t => t.Reservation_ReservationId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserType = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Preposition = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        GuestIP = c.String(),
                        Ober_UserId = c.Int(),
                        Receptionist_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Users", t => t.Ober_UserId)
                .ForeignKey("dbo.Users", t => t.Receptionist_UserId)
                .Index(t => t.Ober_UserId)
                .Index(t => t.Receptionist_UserId);
            
            CreateTable(
                "dbo.FoodFoodOptions",
                c => new
                    {
                        Food_FoodId = c.Int(nullable: false),
                        FoodOption_FoodOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_FoodId, t.FoodOption_FoodOptionId })
                .ForeignKey("dbo.Foods", t => t.Food_FoodId, cascadeDelete: true)
                .ForeignKey("dbo.FoodOptions", t => t.FoodOption_FoodOptionId, cascadeDelete: true)
                .Index(t => t.Food_FoodId)
                .Index(t => t.FoodOption_FoodOptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Receptionist_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Reservation_ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Ober_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Waiter_UserId", "dbo.Users");
            DropForeignKey("dbo.FoodOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.FoodOrders", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.FoodFoodOptions", "FoodOption_FoodOptionId", "dbo.FoodOptions");
            DropForeignKey("dbo.FoodFoodOptions", "Food_FoodId", "dbo.Foods");
            DropIndex("dbo.FoodFoodOptions", new[] { "FoodOption_FoodOptionId" });
            DropIndex("dbo.FoodFoodOptions", new[] { "Food_FoodId" });
            DropIndex("dbo.Reservations", new[] { "Receptionist_UserId" });
            DropIndex("dbo.Reservations", new[] { "Ober_UserId" });
            DropIndex("dbo.Orders", new[] { "Reservation_ReservationId" });
            DropIndex("dbo.Orders", new[] { "Waiter_UserId" });
            DropIndex("dbo.FoodOrders", new[] { "OrderId" });
            DropIndex("dbo.FoodOrders", new[] { "FoodId" });
            DropTable("dbo.FoodFoodOptions");
            DropTable("dbo.Reservations");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.FoodOrders");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodOptions");
        }
    }
}
