using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstNewDatabaseSample;
using System.ComponentModel.DataAnnotations;
using CodeFirstNewDatabaseSample.Migrations;

//navn: Daniel Pat Hansen
//studieNr: 201601915
//retning: IKT


namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var db = new BloggingContext())
            {
                //Kontrol af Punkt 21 om det virkede
                var o_query = from o in db.Organizations
                    orderby o.OrganizationId
                    select o;
                foreach (var o_item in o_query)
                {
                    Console.WriteLine("Org: " + o_item.OrganizationName +" Homeland 1: " + o_item.Homelands[0].CountryName + " Homeland 2: " + o_item.Homelands[1].CountryName + " Homeland 3: " + o_item.Homelands[2].CountryName);
                }
                
               
                

                // Create og save en ny Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                //Add et nyt navn til bloggen DB
                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
                
                //Udvidelse af organizationsnavn
                Console.WriteLine("Please enter a new organization name.");
                var orgname = Console.ReadLine();

                //Add nyt navn til organizationstabellen
                var org = new Organization { OrganizationName = orgname };
                db.Organizations.Add(org);
                db.SaveChanges();

                //Færdig med første udvidelse
                
                
                //Anden udvidelse, tilsæt brugernavn til organisationen (tror jeg)
                Console.WriteLine("Enter your username, it will be added to the org");
                var username = Console.ReadLine();

                //Add nyt navn til brugertabellen
                var user = new User{Username = username, Organizations = org}; //Tilføjer med reference organizations = org
                db.Users.Add(user);
                db.SaveChanges();
                
                // Display alle Blogs fra database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                //Punkt 8, udskriv alle bruger og organizationer
                
                var u_query = from u in db.Users
                    orderby u.Username
                    select u;
                
                Console.WriteLine("Usernames, organizations and orgID");
                foreach (var u_item in u_query)
                {
                    Console.WriteLine("User: " + u_item.Username + " Org: " + u_item.Organizations.OrganizationName + " Org ID: " + u_item.Organizations.OrganizationId);
                }
                
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    //Dette er lister, Blog er i toppen
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        //En reference fra post som er en liste
        public virtual List<Post> Posts { get; set; }
    }
    //Det ligger under post
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    //Dette er en den normale metode, uden API
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        //Vi giver også blogging organizations at den kan blive sættet ind med dataerne fra main
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; } //Den her bliver kigget på fra Homelands (pga den migrations commando jeg gjorde)
        
                //Dette er API fluent metoden, tilsætter Display_name til user
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
        //Sådan bliver en reference lavet til organization, herunder ser du at den bliver lavet til en liste og vi erklærer en ny liste
        //public virtual List<Organization> Organizations { get; set; } //= new List<Organization>();
        //Referencen kan også bare være et objekt fra den gældene tabel
        public virtual Organization Organizations { get; set; }
    }
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        //reference til Country / Homeland så den kan tilgåes
        //public virtual Country Homeland { get; set; }
        public virtual List<Country> Homelands { get; set; }
        
    }
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }

        public virtual List<Organization> OrgsInCountry { get; set; }

    }
}
