using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data;

namespace Vehicle.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboBrands()
        {
            List<SelectListItem> list = _context.Brand.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione una marca",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboDocumentTypes()
        {
            List<SelectListItem> list = _context.DocumentTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un Tipo de documento",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProcedures()
        {
            List<SelectListItem> list = _context.Procedure.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un Tipo de Procedimiento",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboVehicleTypes()
        {
            List<SelectListItem> list = _context.VehicleTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un Tipo de Vehiculo",
                Value = "0"
            });

            return list;
        }
    }
}
