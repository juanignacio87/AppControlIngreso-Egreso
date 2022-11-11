using ControlMoney.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMoney.Modelos
{
    internal class Gasto
    {
        public int IdEgreso { get; set; }

        public string Fecha { get; set; }

        public int IdTipoEgreso { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public static bool Agregar(Gasto Gasto, bool Editar)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Fecha", Gasto.Fecha),
                new Parametro("@IdTipoEgreso", Gasto.IdTipoEgreso),
                new Parametro("@Descripcion", Gasto.Descripcion),
                new Parametro("@Monto", Gasto.Monto),
                new Parametro("@IdEgreso", Gasto.IdEgreso),
                new Parametro("@Editar", Editar)
            };

            return DBDatos.Ejecutar("Egreso_Agregar", parametros);
        }
    }
}
