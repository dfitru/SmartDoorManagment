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
    public class DoorService
    {
        public bool CreateDoor(DoorCreate model)
        {
            var entity =
                new Door()
                {
                    DoorName=model.DoorName,
                    FloorNumber=model.FloorNumber,
                    IsRoomInRoom=model.IsRoomInRoom,
                    BuildingId=model.BuildingId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Doors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DoorItemList> GetDoors()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Doors
                    .Select(
                        e =>
                        new DoorItemList
                        {
                            DoorId=e.DoorId,
                            DoorName=e.DoorName,
                            FloorNumber=e.FloorNumber,
                            IsRoomInRoom=e.IsRoomInRoom,
                            BuildingId=e.BuildingId,
                            BuildingName=e.Building.BuildingName,
                            Address=e.Building.Address
                        });
                return query.ToArray();
            }
        }
        public DoorDetail GetDoorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Doors
                    .SingleOrDefault(e => e.DoorId == id);
                if (entity != null)
                {
                    return new DoorDetail()
                    {
                        DoorId=entity.DoorId,
                        DoorName=entity.DoorName,
                        FloorNumber=entity.FloorNumber,
                        IsRoomInRoom=entity.IsRoomInRoom,
                        Buildingss=new BuildingListItems() { BuildingId=entity.Building.BuildingId,BuildingName=entity.Building.BuildingName,Address=entity.Building.Address}
                        //SmartKeys=new SmartKeyListItem() { }
                    };
                }
                return null;
            }
        }
        public bool UpdateDoor(DoorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Doors
                    .SingleOrDefault(e => e.DoorId == model.DoorId);

               
                    entity.DoorName = model.DoorName;
                    //entity.Floor = model.Floor;
                    entity.IsRoomInRoom = model.IsRoomInRoom;
                    entity.BuildingId = model.BuildingId;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteDoor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Doors
                    .SingleOrDefault(e => e.DoorId == id);

                if (entity != null)
                {
                    ctx.Doors.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }
}
