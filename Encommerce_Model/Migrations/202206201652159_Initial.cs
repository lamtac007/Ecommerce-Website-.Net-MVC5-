namespace Encommerce_Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID_Category = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Category);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID_Product = c.Int(nullable: false, identity: true),
                        ID_Category = c.Int(),
                        ProductName = c.String(maxLength: 50),
                        Image = c.String(maxLength: 200, unicode: false),
                        Origin = c.String(maxLength: 20),
                        Price = c.Double(nullable: false),
                        Unit = c.String(maxLength: 10),
                        Sale = c.Double(),
                        DateManufacture = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                        Description = c.String(maxLength: 50),
                        DescriptionDTS = c.String(storeType: "ntext"),
                        Update = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID_Product)
                .ForeignKey("dbo.Category", t => t.ID_Category)
                .Index(t => t.ID_Category);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID_Order = c.Int(nullable: false, identity: true),
                        ID_User = c.Int(),
                        ID_Product = c.Int(),
                        ProductName = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 10),
                        Image = c.String(maxLength: 200, unicode: false),
                        Price = c.Double(nullable: false),
                        Amount = c.Int(),
                        TotalPrice = c.Double(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Order)
                .ForeignKey("dbo.User", t => t.ID_User)
                .ForeignKey("dbo.Product", t => t.ID_Product)
                .Index(t => t.ID_User)
                .Index(t => t.ID_Product);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID_OrderDetails = c.Int(nullable: false),
                        OrderDetailsName = c.String(maxLength: 1),
                        ID_User = c.Int(),
                        ID_Order = c.Int(),
                        TotalPrice = c.Double(),
                        Status_ = c.String(maxLength: 50),
                        ODate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID_OrderDetails)
                .ForeignKey("dbo.Order", t => t.ID_Order)
                .ForeignKey("dbo.User", t => t.ID_User)
                .Index(t => t.ID_User)
                .Index(t => t.ID_Order);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID_User = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(),
                        PhoneNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID_User);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID_Fed = c.Int(nullable: false, identity: true),
                        ID_User = c.Int(),
                        FeedbackA = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ID_Fed)
                .ForeignKey("dbo.User", t => t.ID_User)
                .Index(t => t.ID_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ID_Product", "dbo.Product");
            DropForeignKey("dbo.Order", "ID_User", "dbo.User");
            DropForeignKey("dbo.OrderDetails", "ID_User", "dbo.User");
            DropForeignKey("dbo.Feedback", "ID_User", "dbo.User");
            DropForeignKey("dbo.OrderDetails", "ID_Order", "dbo.Order");
            DropForeignKey("dbo.Product", "ID_Category", "dbo.Category");
            DropIndex("dbo.Feedback", new[] { "ID_User" });
            DropIndex("dbo.OrderDetails", new[] { "ID_Order" });
            DropIndex("dbo.OrderDetails", new[] { "ID_User" });
            DropIndex("dbo.Order", new[] { "ID_Product" });
            DropIndex("dbo.Order", new[] { "ID_User" });
            DropIndex("dbo.Product", new[] { "ID_Category" });
            DropTable("dbo.Feedback");
            DropTable("dbo.User");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Order");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
