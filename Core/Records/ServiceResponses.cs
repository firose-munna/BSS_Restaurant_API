using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Records
{
    public class ServiceResponses
    {
        public record class GeneralResponse(string Message);

        public record class LoginResponse(string Token, string Message);
    }
}
