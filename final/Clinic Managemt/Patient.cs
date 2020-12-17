using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Managemt
{
    public class Patient
    {
        int id;
        string name;
        
        public Patient(int id,string name)
        {
            this.name = name;
            this.id = id;
        }
        public override string ToString()
        {
            return "ID IS : "+id.ToString()+" and Name is :"+name;
        }
        public int getID()
        {
            return id;
        }
    }
}
