using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace P4EXAMEN119020051.Controllers
{
    public class LocalizacionController
    {
        readonly SQLiteAsyncConnection _connection;

        public LocalizacionController(string DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.Localizacion>();
        }
    public Task<int> SaveGeo(Models.Localizacion posicion)
    {
        if (posicion.Id != 0)
            return _connection.UpdateAsync(posicion); 
        else
            return _connection.InsertAsync(posicion);
    }

    public Task<Models.Localizacion> GetLocalizaciones(int pid)
    {
            return _connection.Table<Models.Localizacion>()
            .Where(i => i.Id == pid)
            .FirstOrDefaultAsync();
    }
    public Task<List<Models.Localizacion>> GetLisLocalizaciones()
        {
            return _connection.Table<Models.Localizacion>().ToListAsync();
            
        }
    public Task<int> DeleteLocalizacion(Models.Localizacion posicion)
        {
            return _connection.DeleteAsync(posicion);
        }
    }
}
