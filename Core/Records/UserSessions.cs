using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Records
{
    public record UserSession(string? Id, string? Name, string? Email, IList<string>? Role);
}
