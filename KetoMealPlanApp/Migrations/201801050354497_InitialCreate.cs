namespace KetoMealPlanApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Gender = c.Int(nullable: false),
                        BodyFat = c.Double(nullable: false),
                        ActivityLevel = c.Int(nullable: false),
                        WeightLossCalories = c.Int(nullable: false),
                        FatKcalDaily = c.Int(nullable: false),
                        ProteinKcalDaily = c.Int(nullable: false),
                        NetCarbsKcalDaily = c.Int(nullable: false),
                        FatGramsDaily = c.Int(nullable: false),
                        ProteinGramsDaily = c.Int(nullable: false),
                        NetCarbsGramsDaily = c.Int(nullable: false),
                        FatPercentageDaily = c.Double(nullable: false),
                        ProteinPercentageDaily = c.Double(nullable: false),
                        NetCarbsPercentageDaily = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
