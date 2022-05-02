using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Data
{
    public class DatabaseService
    {
        //Database[] database = new Database[2]
        //{
        //    new Database(){
        //    Key = 1,
        //    Numero = "Hola"
        //    },
        //      new Database(){
        //    Key = 2,
        //    Numero = "Como estas"
        //    },
        //};
        public Database[] _data ;
        DbContextOptions<DataBaseContext> options = new DbContextOptions<DataBaseContext>();
        
        public DatabaseService()
        {

            var context = new DataBaseContext(options);
            int count = Connection(context, true);
            _data = new Database[count];

            Connection(context, false);
        }

        
        int Connection(DataBaseContext context,bool tr)
        {
            int i = 0;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                context.Database.OpenConnection();
                if (tr)
                {
                    command.CommandText = "SELECT COUNT(*) FROM data";
                }
                else
                {
                    command.CommandText = "SELECT * From data";
                }
                
                
                if (tr)
                {
                    return (Int32)command.ExecuteScalar(); 
                }
                else
                {
                    using (var result = command.ExecuteReader())
                    {

                        while (result.Read())
                        {

                            _data[i] = new Database();
                            _data[i].Id = result.GetInt32(0);
                            _data[i].Numero = result.GetString(1);
                            i++;
                        }
                        
                    }
                }
                context.Database.CloseConnection();
            }
            return i;
        }
        public  Task<Database[]> GetDataAsync()
        {
            return  Task.FromResult<Database[]>(_data);
        }
    }
}
