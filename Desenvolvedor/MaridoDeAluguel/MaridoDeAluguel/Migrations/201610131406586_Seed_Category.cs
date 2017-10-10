namespace MaridoDeAluguel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Seed_Category : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) values ('Animais e Acess�rios')");
            Sql("INSERT INTO Categories (Name) values ('M�sicas e Hobbies')");
            Sql("INSERT INTO Categories (Name) values ('Moda e Beleza')");
            Sql("INSERT INTO Categories (Name) values ('Beb�s e Crian�as')");
            Sql("INSERT INTO Categories (Name) values ('Para a Casa')");
            Sql("INSERT INTO Categories (Name) values ('Esportes')");
            Sql("INSERT INTO Categories (Name) values ('Eletr�nicos e Celulares')");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Cachorros', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Gatos', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Peixes', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roedores', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Instrumentos musicais', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Livros', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Antiguidades', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roupas e Cal�ados', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acess�rios', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roupas', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Brinquedos', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('M�veis', 5)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acess�rios esportivos', 6)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Jogos', 7)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acess�rios de celular', 7)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE ID in (1,2,3,4,5,6)");
        }
    }
}
