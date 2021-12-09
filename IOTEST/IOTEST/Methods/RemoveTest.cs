﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace IOTEST.Methods
{
    [UsedImplicitly]
    public class RemoveTest : IMethod
    {

        public async Task<string> Invoke(HttpContext context, IoContext db, DataControl control)
        {
            if (!control.IsOk || !context.Request.Form.ContainsKey("Key")) return "error";
            var key = context.Request.Form["Key"].ToString();
            var gr = await db.Tests.FirstOrDefaultAsync(x => x.Key == key);
            db.Tests.Remove(gr);
            await db.SaveChangesAsync();
            return "Ok";
        }
    }
}