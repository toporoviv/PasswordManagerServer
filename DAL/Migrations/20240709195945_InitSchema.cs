using FluentMigrator;

namespace DAL.Migrations;

[Migration(20240709195945)]
public class InitSchema : Migration
{
    public override void Up()
    {
        Create.Table("site_password_manager")
            .WithColumn("id").AsInt64().PrimaryKey("site_password_manager_pk").Identity()
            .WithColumn("site").AsString().NotNullable()
            .WithColumn("password").AsString().NotNullable()
            .WithColumn("date").AsDateTimeOffset().NotNullable();

        Create.Table("email_password_manager")
            .WithColumn("id").AsInt64().PrimaryKey("email_password_manager_pk").Identity()
            .WithColumn("email").AsString().NotNullable()
            .WithColumn("password").AsString().NotNullable()
            .WithColumn("date").AsDateTimeOffset().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("site_password_manager");
        Delete.Table("email_password_manager");
    }
}
