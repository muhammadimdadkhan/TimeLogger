using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Database;
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
    public class EntityFrameworkRepository : EntityFrameworkRepositoryReadOnly, IRepository
    {
        private readonly TimeLoggerContext _DbContext;
        public EntityFrameworkRepository(
         TimeLoggerContext context
         )
         : base(context)
        {
            _DbContext = context;
        }

        public void DeleteModel<T>(int modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteModel<T>(string modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public void ExecuteRawSql(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ExecuteRawSqlAsync<T>(string sql) where T : class
        {
            throw new NotImplementedException();
        }

        public void InsertModel<T>(T model) where T : class
        {
            try
            {
                _DbContext.Set<T>().Add(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void ResetChangeTracker()
        {
            _DbContext.ChangeTracker.Clear();
        }



        public void AddRange<T>(IEnumerable<T> objects, bool IsAuditable = true) where T : class
        {
            try
            {
                if (objects.Count() > 0)
                {
                    _DbContext.AddRange(objects);
                    int count = Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void RemoveRange<T>(IEnumerable<T> objects, bool IsAuditable = true) where T : class
        {
            try
            {
                _DbContext.RemoveRange(objects);
                Save();
            }
            catch (Exception ex)
            {
            }
        }
        public void UpdateRange<T>(IEnumerable<T> objects, bool IsAuditable = true) where T : class
        {
            try
            {
                _DbContext.UpdateRange(objects);
                Save();
            }
            catch (Exception ex)
            {
            }
        }

        public int Save()
        {
            try
            {
                return _DbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return 0;
                throw ex;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    
    private void SaveChangesWithAudit(object entity, ActionType actionType, EventType eventType)
        {
            // Save changes to the database
            _DbContext.SaveChanges();

            // Create audit entry
            var auditEntry = CreateAuditEntry(entity, actionType,  eventType);
            _DbContext.Set<Audit>().Add(auditEntry);
            _DbContext.SaveChanges();
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
                OldValuesJson = actionType != ActionType.Insert ? JsonConvert.SerializeObject(_DbContext.Entry(entity).OriginalValues) : null,
                NewValuesJson = actionType != ActionType.Delete ? JsonConvert.SerializeObject(entity) : null
            };
            return auditEntry;

            // Implement this method according to your audit model
            throw new NotImplementedException();
        }
    }
}
