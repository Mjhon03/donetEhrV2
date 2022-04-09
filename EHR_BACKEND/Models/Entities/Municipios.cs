using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Municipios
    {
        BaseData db = new BaseData();

        private int _idmunicipio = 0;
        
        public int idmunicipio { get { return _idmunicipio; } set { _idmunicipio = value; } }   

        private string _nombre = ""; 
        public string nombre { get { return _nombre; } set { _nombre = value;} }

        private int _departamento = 0;

        public int departamento { get { return _departamento; } set { _departamento = value;} }



        public IEnumerable<Municipios> GetAllMunicipality(string sql)
        {
            DataTable dt = db.getTable(sql);
            List<Municipios> MunicipioList = new List<Municipios>();
            MunicipioList = (from DataRow dr in dt.Rows
                             select new Municipios()
                             {
                                 idmunicipio = Convert.ToInt32(dr["idmunicipio"]),
                                 nombre = dr["nombre"].ToString(),
                                 departamento = Convert.ToInt32(dr["departamento"]),
                             }).ToList();

            return MunicipioList;
        }

        public IEnumerable<Municipios> GetMunicipalityById(string sql)
        {
            DataTable dt = db.getTable(sql);
            List<Municipios> MunicipioList = new List<Municipios>();
            MunicipioList = (from DataRow dr in dt.Rows
                             select new Municipios()
                             {
                                 idmunicipio = Convert.ToInt32(dr["idmunicipio"]),
                                 nombre = dr["nombre"].ToString(),
                                 departamento = Convert.ToInt32(dr["departamento"]),
                             }).ToList();
            return MunicipioList;
        }

    }
}
