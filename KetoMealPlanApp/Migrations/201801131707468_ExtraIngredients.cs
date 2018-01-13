namespace KetoMealPlanApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraIngredients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraIngredients",
                c => new
                    {
                        IngredinetId = c.Int(nullable: false, identity: true),
                        Calories = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        MacroGrams = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredinetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExtraIngredients");
        }
    }
}
