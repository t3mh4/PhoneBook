using ContactMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ContactMicroservice.DBContext
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Contact>().HasData(
                new Contact { UUID =new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"),Name= "Perceval", Surname= "Innes", Company= "Lishan" }, 
                new Contact { UUID =new Guid("80afa69f-1e86-4831-9571-c5129aa21ab8"),Name= "Hersh", Surname= "Giron", Company= "Hulutao" }, 
                new Contact { UUID =new Guid("b64a31a9-17e6-483f-b542-db8840436416"),Name= "Lonna", Surname= "Clyne", Company= "Kebunkelapa" }, 
                new Contact { UUID =new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"),Name= "Gleda", Surname= "Ayrs", Company= "Boniewo" } 
                );
            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000001"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Mahdia" },
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000002"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Mahdia" },
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000003"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Mahdia" },
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000004"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Vallenar" },
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000005"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Vallenar" },
                new ContactInfo { UUID=new Guid("00000000-0000-0000-0000-000000000006"),ContactUUID=new Guid("5d8bfa0c-90c9-4bc8-a4f5-cfac4b2eefd9"), PhoneNumber ="",EMail="",Location= "Vallenar" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000007"),ContactUUID=new Guid("80afa69f-1e86-4831-9571-c5129aa21ab8"), PhoneNumber ="",EMail="",Location= "Zhouzai" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000008"),ContactUUID=new Guid("80afa69f-1e86-4831-9571-c5129aa21ab8"), PhoneNumber ="",EMail="",Location= "Zhouzai" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000009"),ContactUUID=new Guid("80afa69f-1e86-4831-9571-c5129aa21ab8"), PhoneNumber ="",EMail="",Location= "Clarin" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000010"),ContactUUID= new Guid("80afa69f-1e86-4831-9571-c5129aa21ab8"), PhoneNumber ="",EMail="",Location= "Clarin" },

                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000011"), ContactUUID = new Guid("b64a31a9-17e6-483f-b542-db8840436416"), PhoneNumber = "", EMail = "", Location = "Leeuwarden" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000012"), ContactUUID = new Guid("b64a31a9-17e6-483f-b542-db8840436416"), PhoneNumber = "", EMail = "", Location = "Clarin" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000013"), ContactUUID = new Guid("b64a31a9-17e6-483f-b542-db8840436416"), PhoneNumber = "", EMail = "", Location = "Leeuwarden" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000014"), ContactUUID = new Guid("b64a31a9-17e6-483f-b542-db8840436416"), PhoneNumber = "", EMail = "", Location = "Mahdia" },

                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000015"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Leeuwarden" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000016"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Zhouzai" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000017"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Vallenar" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000018"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Clarin" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000019"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Leeuwarden" },
                new ContactInfo { UUID = new Guid("00000000-0000-0000-0000-000000000020"), ContactUUID = new Guid("459e560e-d324-4de0-97d3-e6c3d8882d87"), PhoneNumber = "", EMail = "", Location = "Clarin" }


                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
