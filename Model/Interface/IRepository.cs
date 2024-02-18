using Common.Enums;
using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IRepository<T> where T : BasicEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity, EventType eventType);
        void Update(T entity, EventType eventType);
        void Delete(int id, EventType eventType);
        void AddRange(IEnumerable<T> entities, EventType eventType);
        void UpdateRange(IEnumerable<T> entities, EventType eventType);
        void DeleteRange(IEnumerable<int> ids, EventType eventType);
    }
}
