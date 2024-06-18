using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace d9.lcm.compat.modrinth;
public static class ModrinthApi
{
    public static JsonSerializerOptions SerializerOptions
        => new() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
}
