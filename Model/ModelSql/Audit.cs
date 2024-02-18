using Common.Enums;
using Model.EntityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelSql
{
    public class Audit : BasicEntity
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public ActionType ActionType { get; set; }
        public EventType EventType { get; set; }
        public int RecordID { get; set; }
        public DateTime ActionDateTime { get; set; }
        public string OldValuesJson { get; set; } // Serialized JSON representation of the old values before the action
        public string NewValuesJson { get; set; } // Serialized JSON representation of the new values after the action

        // Navigation property
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        // Helper methods to serialize/deserialize objects to/from JSON

        public void SetOldValues(object oldValues)
        {
            OldValuesJson = JsonConvert.SerializeObject(oldValues);
        }

        public T GetOldValues<T>()
        {
            return JsonConvert.DeserializeObject<T>(OldValuesJson);
        }

        public void SetNewValues(object newValues)
        {
            NewValuesJson = JsonConvert.SerializeObject(newValues);
        }

        public T GetNewValues<T>()
        {
            return JsonConvert.DeserializeObject<T>(NewValuesJson);
        }
    } 
}
