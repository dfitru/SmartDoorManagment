using SmartDoor.Data;
using SmartDoor.Models;
using SmartDoor.Models.Building;
using SmartDoorManagmentSystem.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Services
{
    public class BuildingService
    {
        private readonly Guid _guid;
        //public BuildingService(Guid guid)
        //{
        //    _guid = guid;
        //}
        public bool CreateBuilding(BuildingCreate model)
        {
            var entity =
                new Building()
                {
                    BuildingName = model.BuildingName,
                    Address = model.Address
                };
            using(var ctx=new ApplicationDbContext())
            {
                ctx.Buildings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BuildingListItems> GetBuilding()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Buildings
                    .Select(
                        e =>
                        new BuildingListItems
                        {
                            BuildingId = e.BuildingId,
                            BuildingName = e.BuildingName,
                            Address = e.Address

                        }
                        );
                return query.ToArray();
            }
        }
        public BuildingDetail GetBuildingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Buildings
                    .Single(e => e.BuildingId == id);
                return
                    new BuildingDetail
                    {
                        BuildingId = entity.BuildingId,
                        BuildingName = entity.BuildingName,
                        Address = entity.Address
                    };
            }
        }
        public bool UpdateBuilding(BuildingEdit model)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Buildings
                    .Single(e => e.BuildingId == model.BuildingId);
                entity.BuildingName = model.BuildingName;
                entity.Address = model.Address;
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
