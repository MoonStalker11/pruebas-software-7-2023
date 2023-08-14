namespace backend.connection
{
     public static class CategoriaProductoServicios
     {
        public static IEnumerable<T> ObtenerTodo<T> (){
            const string sql = "Select * from categoria_producto";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }
     }

}