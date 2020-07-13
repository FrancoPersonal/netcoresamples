using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerAspNetCore.Authentication
{
    public class ApiKey
    {
        public ApiKey(ApiKeyModel model)
        {
            Id = model.Id;
            Owner = model.Owner ?? throw new ArgumentNullException(nameof(Owner));
            Key = model.Key ?? throw new ArgumentNullException(nameof(Key));
            Created = model.Created;
            Roles = model.Roles ?? throw new ArgumentNullException(nameof(Roles));
        }

        public int Id { get; }
        public string Owner { get; }
        public string Key { get;  }
        public DateTime Created { get;}
        public IReadOnlyCollection<string> Roles { get; }
    }
}
