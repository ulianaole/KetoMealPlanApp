namespace KetoMealPlanApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Meals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Calories = c.Int(nullable: false),
                        FatGrams = c.Int(nullable: false),
                        ProteinGrams = c.Int(nullable: false),
                        NetCarbGrams = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meals");
        }
    }
}
