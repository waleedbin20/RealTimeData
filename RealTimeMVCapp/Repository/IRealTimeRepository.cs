using RealTimeMVCapp.Data.Entities;
using System.Collections.Generic;

namespace RealTimeMVCapp.Repository
{
    public interface IRealTimeRepository
    {
        void AddEntity(object model);
        IEnumerable<Material> GetAllMaterials();
        Material GetMaterialByID(int id);
        bool SaveAll();
    }
}