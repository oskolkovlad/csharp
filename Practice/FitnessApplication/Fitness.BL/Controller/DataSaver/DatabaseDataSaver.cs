using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var dbContext = new FitnessDBContext())
            {
                var result = dbContext.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> items) where T : class
        {
            using(var dbContext = new FitnessDBContext())
            {
                dbContext.Set<T>().AddRange(items);
                dbContext.SaveChanges();
            }
        }
    }
}
