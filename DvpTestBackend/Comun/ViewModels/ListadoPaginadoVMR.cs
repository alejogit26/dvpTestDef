using System.Collections.Generic;

namespace Comun.ViewModels
{
    public class ListadoPaginadoVMR<T>
    {
        public int cantidadTotal { get; set; }
        public IEnumerable<T> elemento { get; set; }

        public ListadoPaginadoVMR()
        {
            elemento = new List<T>();
            cantidadTotal = 0;
        }
    }
}
