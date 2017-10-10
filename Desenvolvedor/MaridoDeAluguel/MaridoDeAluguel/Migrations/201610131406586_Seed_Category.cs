namespace MaridoDeAluguel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Seed_Category : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) values ('Animais e Acessórios')");
            Sql("INSERT INTO Categories (Name) values ('Músicas e Hobbies')");
            Sql("INSERT INTO Categories (Name) values ('Moda e Beleza')");
            Sql("INSERT INTO Categories (Name) values ('Bebês e Crianças')");
            Sql("INSERT INTO Categories (Name) values ('Para a Casa')");
            Sql("INSERT INTO Categories (Name) values ('Esportes')");
            Sql("INSERT INTO Categories (Name) values ('Eletrônicos e Celulares')");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Cachorros', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Gatos', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Peixes', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roedores', 1)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Instrumentos musicais', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Livros', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Antiguidades', 2)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roupas e Calçados', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acessórios', 3)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Roupas', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Brinquedos', 4)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Móveis', 5)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acessórios esportivos', 6)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Jogos', 7)");
            Sql("INSERT INTO Categories (Name, ParentCategory_ID) values ('Acessórios de celular', 7)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE ID in (1,2,3,4,5,6)");
        }
    }
}
