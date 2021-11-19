﻿using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IOTEST.Methods
{
   
    [UsedImplicitly]
        public class ConnectToGroup : IMethod
        {

            public async Task<string> Invoke(HttpContext context, IoContext userContext, DataControl control)
            {
                if (!control.IsOk || !context.Request.Form.ContainsKey("Key")) return "error";
                if (!await userContext.Groups.AnyAsync(x => x.Key == context.Request.Form["Key"].ToString())) return "No";
                
                var Group = await userContext.Groups.FirstAsync(x => x.Key == context.Request.Form["Key"].ToString());
                if (Group.Admin == control.UserData.Gmail || Group.Users.Any(x => x == control.UserData.Gmail)) return "Contains";
                Group.Users.Add(control.UserData.Gmail);
                userContext.Groups.Update(Group);
                await userContext.SaveChangesAsync();
                return "OK";
            }
        }
    }
