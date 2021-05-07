using SmartDoor.Data;
using SmartDoor.Models;
using SmartDoorManagmentSystem.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Services
{
    public class PersonService
    {
        private readonly Guid _userId;
        public PersonService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreatePerson (PersonCreate model)
        {
            var entity =
                new Person()
                {
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Company=model.Company
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Persons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PersonListItem> GetPerson()
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Persons
                    .Select(
                        e =>
                        new PersonListItem
                        {
                            PersonId = e.PersonId,
                            FirstName = e.FirstName,
                            LastName = e.LastName

                        }
                        );
                return query.ToArray();
            }
            
        }
        public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Persons
                    .Single(e => e.PersonId == id);
                return
                    new PersonDetail
                    {
                        PersonId = entity.PersonId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Company = entity.Company
                    };
            }
        }
        public bool UpdatePersone(PersonEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Persons
                    .Single(e => e.PersonId == model.PersonId);
                entity.PersonId = model.PersonId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Company = model.Company;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePerson(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == id);

                ctx.Persons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
