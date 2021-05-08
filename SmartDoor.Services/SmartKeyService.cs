using SmartDoor.Data;
using SmartDoor.Models;
using SmartDoor.Models.SmartKey;
using SmartDoorManagmentSystem.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Services
{
    public class SmartKeyService
    {
        private readonly Guid _userId;
        public SmartKeyService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSmartKey(SmartKeyCreate modle)
        {
            var entity =
                new SmartKey()
                {
                    OwnerID = _userId,
                    Name = modle.Name,
                    KeyRecived = modle.KeyRecived,
                    CreateDate = DateTimeOffset.Now,
                    PersonId = modle.PersonId,
                    DoorId = modle.DoorId

                };
            using(var ctx=new ApplicationDbContext())
            {
                ctx.SmartKeys.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SmartKeyListItem> GetSmartKeys()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SmartKeys
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e=>
                        new SmartKeyListItem
                        {
                            KeyId=e.KeyId,
                            Name=e.Name,
                            KeyRecived=e.KeyRecived,
                            CreateDate=e.CreateDate,
                            PersoneId=e.PersonId,
                            DoorId=e.DoorId
                        });
                return query.ToArray();

            }
        }
        public SmartKeyDetail GetKeyById(int id)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SmartKeys
                    .Single(e => e.KeyId == id && e.OwnerID == _userId);
                return
                    new SmartKeyDetail
                    {
                        KeyId = entity.KeyId,
                        Name = entity.Name,
                        KeyRecived = entity.KeyRecived,
                        CreateDate = entity.CreateDate,
                        Persons = new PersonListItem() { PersonId = entity.Person.PersonId,FirstName=entity.Person.FirstName,LastName=entity.Person.LastName },
                        Doors=new DoorItemList() {DoorId=entity.Door.DoorId,DoorName=entity.Door.DoorName,FloorNumber=entity.Door.FloorNumber,
                            IsRoomInRoom=entity.Door.IsRoomInRoom,
                            BuildingId=entity.Door.Building.BuildingId,BuildingName=entity.Door.Building.BuildingName,Address=entity.Door.Building.Address }
                    };
            }
        }
    }
}
