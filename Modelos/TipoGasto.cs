using ControlMoney.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMoney.Modelos
{
    internal class TipoGasto
    {
        public int IdTipoEgreso { get; set; }

        public string Denominacion { get; set; }

        public static bool Guardar(TipoGasto tipoGasto, bool editar)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Denominacion", tipoGasto.Denominacion),
                new Parametro("@IdTipoEgreso", tipoGasto.IdTipoEgreso),
                new Parametro("@Editar", editar)
            };

            return DBDatos.Ejecutar("TipoEgreso_Agregar", parametros);
        }

        public static DataTable Listar()
        {
            return DBDatos.Listar("TipoEgreso_Listar");
        }
    }
}
