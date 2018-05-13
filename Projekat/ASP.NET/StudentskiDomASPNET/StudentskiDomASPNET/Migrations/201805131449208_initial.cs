 namespace StudentskiDomASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blagajnik",
                c => new
                    {
                        BlagajnikId = c.String(nullable: false, maxLength: 128),
                        Plata = c.Double(nullable: false),
                        BankovniRacun = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.BlagajnikId);
            
            CreateTable(
                "dbo.Konobar",
                c => new
                    {
                        KonobarId = c.String(nullable: false, maxLength: 128),
                        Plata = c.Double(nullable: false),
                        BankovniRacun = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.KonobarId);
            
            CreateTable(
                "dbo.Kuhar",
                c => new
                    {
                        KuharId = c.String(nullable: false, maxLength: 128),
                        Plata = c.Double(nullable: false),
                        BankovniRacun = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.KuharId);
            
            CreateTable(
                "dbo.Majstor",
                c => new
                    {
                        MajstorId = c.String(nullable: false, maxLength: 128),
                        Tip = c.String(),
                        Plata = c.Double(nullable: false),
                        BankovniRacun = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.MajstorId);
            
            CreateTable(
                "dbo.SefRestorana",
                c => new
                    {
                        SefRestoranaId = c.String(nullable: false, maxLength: 128),
                        Plata = c.Double(nullable: false),
                        BankovniRacun = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.SefRestoranaId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        BrojSobe = c.Int(nullable: false),
                        Kanton = c.String(),
                        Teretana = c.Boolean(nullable: false),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Jmbg = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.SefRestorana");
            DropTable("dbo.Majstor");
            DropTable("dbo.Kuhar");
            DropTable("dbo.Konobar");
            DropTable("dbo.Blagajnik");
            DropTable("dbo.Admin");
        }
    }
}
