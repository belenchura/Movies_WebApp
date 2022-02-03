using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Entities
{
    public class User
    {
        public int cod_usuario { get; set; }
        public string txt_user { get; set; }
        public string txt_password { get; set; }
        public string txt_nombre { get; set; }
        public string txt_apellido { get; set; }
        public string nro_doc { get; set; }
        public int cod_rol { get; set; }
        public int sn_activo { get; set; }
        public string txt_desc { get; set; }
    }
}
