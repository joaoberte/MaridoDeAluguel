namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Seed_States : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Countries (Name) VALUES ('Brasil')");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Acre', 'AC', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Alagoas', 'AL', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Amazonas', 'AM', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Amap�', 'AP', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Bahia', 'BA', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Cear�', 'CE', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Distrito Federal', 'DF', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Esp�rito Santo', 'ES', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Goi�s', 'GO', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Maranh�o', 'MA', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Minas Gerais', 'MG', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Mato Grosso do Sul', 'MS', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Mato Grosso', 'MT', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Par�', 'PA', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Para�ba', 'PB', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Pernambuco', 'PE', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Piau�', 'PI', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Paran�', 'PR', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Rio de Janeiro', 'RJ', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Rio Grande do Norte', 'RN', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Rond�nia', 'RO', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Roraima', 'RR', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Rio Grande do Sul', 'RS', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Santa Catarina', 'SC', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Sergipe', 'SE', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('S�o Paulo', 'SP', 1)");
            Sql("INSERT INTO States (Name, UF, Country_ID) VALUES ('Tocantins', 'TO', 1)");
        }

        public override void Down()
        {

            Sql("DELETE FROM States where ID > 0 and ID < 27");
            Sql("DELETE FROM Countries where ID == 1");
        }
    }
}
