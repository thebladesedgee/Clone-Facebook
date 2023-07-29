﻿namespace facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KişiselDatalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        e_mail = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KişiselDatalar");
        }
    }
}
