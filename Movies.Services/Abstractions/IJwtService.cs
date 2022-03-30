using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Services.Abstractions
{
    public interface IJwtService
    {
        string GenerateJwtToken(string userName);
    }
}
