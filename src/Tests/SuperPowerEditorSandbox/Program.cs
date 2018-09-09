using System.Collections.Generic;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using SuperPowerEditor.Base.BizLogic.StringTable;
using SuperPowerEditor.Base.DataAccess;
using SuperPowerEditor.Base.DataAccess.Entities;
using SuperPowerEditor.Base.DataAccess.Extensions;

namespace SuperPowerEditorSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = new FbConnectionStringBuilder
            //{
            //    Database = @"D:\SteamLibrary\SteamApps\common\SuperPower 2\MODS\SP2\data\DATABASE2.GDB",
            //    ServerType = FbServerType.Embedded,
            //    UserID = "SYSDBA",
            //    Password = "masterkey",
            //    ClientLibrary = "fbembed.dll"
            //}.ToString();

            ////var dbContextOptions = new DbContextOptionsBuilder().UseFirebird(connectionString).Options;

            //SuperPowerEditorDbContext context = new SuperPowerEditorDbContext(connectionString);

            //IQueryable<Design> queryable = context.Designs.Include(design => design.CountryDesignerRef).Where(design => design.CountryDesigner == 177);

            //var sql = queryable.ToSql();

            //List<Design> designs = queryable.ToList();

            var spStringTable = new SpStringTable();
            spStringTable.Load(@"D:\Temp\SP2\data");
        }
    }
}
