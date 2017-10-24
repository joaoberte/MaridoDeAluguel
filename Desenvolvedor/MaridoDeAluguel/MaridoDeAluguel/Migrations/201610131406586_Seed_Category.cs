namespace MaridoDeAluguel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Seed_Category : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) values ('Assist. T�cnica')");
            Sql("INSERT INTO Categories (Name) values ('Reformas')");
            Sql("INSERT INTO Categories (Name) values ('Serv. Dom�sticos')");
            Sql("INSERT INTO Categories (Name) values ('Autos')");

            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Ar Condicionado', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('C�mera', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Celular', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Computador', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Geladeira', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('V�deo Game', 1)");
            
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Chaveiro', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Decorador', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Eletricista', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Encanador', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Pedreiro', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Pintor', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Vidraceiro', 2)");

            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Bab�', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Cozinheira', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Diarista', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Limpeza Piscina', 3)");

            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Alarme', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Borracharia', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Funilaria', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Higieniza��o', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Mec�nico', 4)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE ID in (1,2,3,4)");
        }
    }
}
