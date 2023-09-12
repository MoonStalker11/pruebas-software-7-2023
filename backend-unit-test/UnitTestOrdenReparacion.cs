using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestOrdenReparacion
    {
        public UnitTestOrdenReparacion()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=UPC-GPS.mssql.somee.com;packet size=4096;user id=Moon11_SQLLogin_1;pwd=qjna5ivvzc;data source=UPC-GPS.mssql.somee.com;persist security info=False;initial catalog=UPC-GPS";
        }
        [Fact]
        public void OrdenReparacion_Get_Verificar_NotNull()
        {
            var result = OrdenReparacionServicios.ObtenerTodo<OrdenReparacion>();
            Assert.NotNull(result);
        }

        [Fact]
        public void OrdenReparacion_GetById_Verificar_Item()
        {
            var result = OrdenReparacionServicios.ObtenerById<OrdenReparacion>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void OrdenReparacion_Insertar()
        {
            OrdenReparacion ordenReparacionTemp = new()
            {
                NumeroOrden = "NumeroOrden Test",
                CostoEstimado = "CostoEstimado Test",
                IdEquipoMedico = "IdEquipoMedico Test",
                IdUsuario = "IdUsuario Test"
            };

            var result = OrdenReparacionServicios.InsertOrdenReparacion(ordenReparacionTemp);
            Assert.Equal(1, result);
        }

    }
}