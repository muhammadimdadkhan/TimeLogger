using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Model.EntityModel;
using Model.Interface;
using Model.ModelSql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Insert(T entity, EventType eventType)
        {
            _dbSet.Add(entity);
            SaveChangesWithAudit(entity, ActionType.Insert, eventType);
        }

        public void Update(T entity, EventType eventType)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            SaveChangesWithAudit(entity, ActionType.Update, eventType);
        }

        public void Delete(int id, EventType eventType)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                SaveChangesWithAudit(entity, ActionType.Delete, eventType);
            }
        }

        public void AddRange(IEnumerable<T> entities, EventType eventType)
        {
            _dbSet.AddRange(entities);
            SaveChangesWithAudit(entities, ActionType.Insert, eventType);
        }

        public void UpdateRange(IEnumerable<T> entities, EventType eventType)
        {
            _dbSet.UpdateRange(entities);
            SaveChangesWithAudit(entities, ActionType.Update, eventType);
        }

        public void DeleteRange(IEnumerable<int> ids, EventType eventType)
        {
            var entities = _dbSet.Where(e => ids.Contains(e.Id)).ToList();
            _dbSet.RemoveRange(entities);
            SaveChangesWithAudit(entities, ActionType.Delete, eventType);
        }

        private void SaveChangesWithAudit(object entity, ActionType actionType, EventType eventType)
        {
            // Save changes to the database
            _dbContext.SaveChanges();

            // Create audit entry
            var auditEntry = CreateAuditEntry(entity, actionType,  eventType);
            _dbContext.Set<Audit>().Add(auditEntry);
            _dbContext.SaveChanges();
        }

        private Audit CreateAuditEntry(object entity, ActionType actionType, EventType eventType)
        {
            // Create audit entry based on the entity and action type
            // You need to implement this method according to your audit model
            var auditEntry = new Audit
            {
                UserID = Convert.ToInt32(entity.GetType().GetProperty("ModifiedBy")),
                Name = Convert.ToString(entity.GetType().GetProperty("Name")),
                ActionType = actionType,
                EventType = eventType,
                RecordID = Convert.ToInt32(entity.GetType().GetProperty("ID")),
                ActionDateTime = DateTime.Now,
                OldValuesJson = actionType != ActionType.Insert ? JsonConvert.SerializeObject(_dbContext.Entry(entity).OriginalValues) : null,
                NewValuesJson = actionType != ActionType.Delete ? JsonConvert.SerializeObject(entity) : null
            };
            return auditEntry;

            // Implement this method according to your audit model
            throw new NotImplementedException();
        }
    }
}
