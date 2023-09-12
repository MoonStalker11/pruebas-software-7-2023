using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestEquipoMedico
    {
        public UnitTestEquipoMedico()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=UPC-GPS.mssql.somee.com;packet size=4096;user id=Moon11_SQLLogin_1;pwd=qjna5ivvzc;data source=UPC-GPS.mssql.somee.com;persist security info=False;initial catalog=UPC-GPS";
        }
        [Fact]
        public void EquipoMedico_Get_Verificar_NotNull()
        {
            var result = EquipoMedicoServicios.ObtenerTodo<EquipoMedico>();
            Assert.NotNull(result);
        }

        [Fact]
        public void EquipoMedico_GetById_Verificar_Item()
        {
            var result = EquipoMedicoServicios.ObtenerById<EquipoMedico>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void EquipoMedico_Insertar()
        {
            EquipoMedico equipoMedicoTemp = new()
            {
                NombreEquipo = "NombreEquipo Test",
                DescripcionProblema = "DescripcionProblema Test",
                EstadoReparacion = "EstadoReparacion Test"
            };

            var result = EquipoMedicoServicios.InsertEquipoMedico(equipoMedicoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void EquipoMedico_Actualizar()
        {
            EquipoMedico equipoMedicoTemp = new()
            {
                Id = 19,
                NombreEquipo = "NombreEquipo Test",
                DescripcionProblema = "DescripcionProblema Test",
                EstadoReparacion = "EstadoReparacion Test"
            };

            var result = EquipoMedicoServicios.UpdateEquipoMedico(equipoMedicoTemp);
            Assert.Equal(1, result);
        }

        [Fact]
        public void EquipoMedico_Eliminar()
        {
            var result = EquipoMedicoServicios.DeleteEquipoMedico(19);
            Assert.Equal(1, result);
        }
    }
}
